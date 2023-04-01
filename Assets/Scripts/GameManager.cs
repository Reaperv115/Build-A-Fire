using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    bool focusCamera;

    GameObject fireRef;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        focusCamera = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetFireRef(GameObject fireref)
    {
        fireRef = fireref;
        if (fireref)
            focusCamera = true;
    }
    public GameObject GetFireRef()
    {
        return fireRef;
    }

    public bool GetFocusCamera()
    {
        return focusCamera;
    }
}
