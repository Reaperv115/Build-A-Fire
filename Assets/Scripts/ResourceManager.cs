using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;

    GameObject log;
    GameObject paper;
    GameObject instantiatedFuel;
    private void Start()
    {
        if (Instance == null)
            Instance = this;
        log = Resources.Load<GameObject>("log");
        paper = Resources.Load<GameObject>("crumbled paper");
    }

    public GameObject GetLog()
    {
        return log;
    }
    public GameObject GetPaper()
    {
        return paper;
    }
    public GameObject GetInstantiatedFuel()
    {
        return instantiatedFuel;
    }
    public void SetInstantiatedFuel(GameObject fuel)
    {
        instantiatedFuel = fuel;
    }
}
