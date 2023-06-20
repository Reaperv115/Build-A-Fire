using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnWood : MonoBehaviour
{
    GameObject wood, woodInst;
    GameObject fuelSpawn;
    HandleFuel handleFuel;
    // Start is called before the first frame update
    void Start()
    {
        wood = ResourceManager.Instance.GetLog();
        fuelSpawn = GameObject.Find("Fuel Spawn");
        handleFuel = GameObject.Find("UI Canvas").GetComponent<HandleFuel>();
        GetComponent<Button>().onClick.AddListener(SpawnLog);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnLog()
    {
        woodInst = Instantiate(wood, fuelSpawn.transform.position, wood.transform.rotation);
        ResourceManager.Instance.SetInstantiatedFuel(woodInst);
        handleFuel.SetIsHandlingFuel(true);
    }

    GameObject GetLogInst()
    {
        return woodInst;
    }
}
