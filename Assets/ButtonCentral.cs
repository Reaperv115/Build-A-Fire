using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCentral : MonoBehaviour
{
    GameObject woodButton, paperButton, placefuelButton;
    GameObject fuelrotcontrols;
    [SerializeField]
    Transform fuelSpawn;
    GameObject fuelInst;
    bool hasPlaced;
    // Start is called before the first frame update
    void Start()
    {
        hasPlaced = true;
        woodButton = GameObject.Find("wood");
        if (woodButton)
            woodButton.GetComponent<Button>().onClick.AddListener(SpawnWood);
        placefuelButton = GameObject.Find("Place Fuel");
        if (placefuelButton)
        {
            placefuelButton.GetComponent<Button>().onClick.AddListener(PlaceFuel);
            placefuelButton.gameObject.SetActive(false);
        }
        fuelrotcontrols = GameObject.Find("Fuel Rotation Controls");
        for (int i = 0; i < fuelrotcontrols.transform.childCount; ++i)
            fuelrotcontrols.transform.GetChild(i).gameObject.SetActive(false);
        paperButton = GameObject.Find("paper");
        paperButton.GetComponent<Button>().onClick.AddListener(SpawnPaper);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnWood()
    {
        if (hasPlaced)
        {
            GameObject wood = Resources.Load<GameObject>("log");
            fuelInst = Instantiate(wood, fuelSpawn.position, wood.transform.rotation);
            placefuelButton.gameObject.SetActive(true);
            ToggleFuelRotationUI(true);
            hasPlaced = false;
        }
        else
            return;
    }
    public void SpawnPaper()
    {
        if (hasPlaced)
        {
            GameObject paper = Resources.Load<GameObject>("crumbled paper");
            fuelInst = Instantiate(paper, fuelSpawn.position, paper.transform.rotation);
            placefuelButton.gameObject.SetActive(true);
            ToggleFuelRotationUI(true);
            hasPlaced = false;
        }
        else
            return;
    }

    public void PlaceFuel()
    {
        fuelInst.GetComponent<Rigidbody>().useGravity = true;
        placefuelButton.gameObject.SetActive(false);
        ToggleFuelRotationUI(false);
        hasPlaced = true;
    }
    public GameObject GetFuelInst()
    {
        return fuelInst;
    }
    void ToggleFuelRotationUI(bool toggle)
    {
        for (int i = 0; i < fuelrotcontrols.transform.childCount; ++i)
            fuelrotcontrols.transform.GetChild(i).gameObject.SetActive(toggle);
    }
}
