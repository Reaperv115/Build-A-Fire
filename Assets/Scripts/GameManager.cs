using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    GameObject fireRef;
    
    Transform ignition;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        ignition = GameObject.Find("Ignition").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetFireRef(GameObject fireref)
    {
        fireRef = fireref;
    }
    public GameObject GetFireRef()
    {
        return fireRef;
    }
    public Transform GetIgnite() 
    {
        return ignition;
    }
}
