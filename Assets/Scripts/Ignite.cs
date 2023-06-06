using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ignite : MonoBehaviour
{
    Transform ignition;
    GameObject fire, fireInst;
    // Start is called before the first frame update
    void Start()
    {
        ignition = this.transform;
        fire = Resources.Load<GameObject>("fire");
        GameManager.instance.SetFireRef(fire);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LightFire()
    {
        fireInst = Instantiate(fire, ignition.position, fire.transform.rotation);
    }
}
