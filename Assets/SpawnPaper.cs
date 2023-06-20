using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPaper : MonoBehaviour
{
    GameObject paper, paperInst;
    GameObject fuelSpawn;
    HandleFuel handleFuel;
    // Start is called before the first frame update
    void Start()
    {
        paper = ResourceManager.Instance.GetPaper();
        fuelSpawn = GameObject.Find("Fuel Spawn");
        handleFuel = GameObject.Find("UI Canvas").GetComponent<HandleFuel>();
        GetComponent<Button>().onClick.AddListener(SpawnCrumbledPaper);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCrumbledPaper()
    {
        paperInst = Instantiate(paper, fuelSpawn.transform.position, paper.transform.rotation);
        ResourceManager.Instance.SetInstantiatedFuel(paperInst);
        handleFuel.SetIsHandlingFuel(true);
    }

    GameObject GetPaperInst()
    {
        return paperInst;
    }
}
