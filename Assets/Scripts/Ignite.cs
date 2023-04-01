using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ignite : MonoBehaviour
{
    [SerializeField]
    Transform ignition;
    GameObject fire, fireInst;
    // Start is called before the first frame update
    void Start()
    {
        fire = Resources.Load<GameObject>("fire");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LightFire()
    {
        fireInst = Instantiate(fire, ignition.position, fire.transform.rotation);
        GameManager.instance.SetFireRef(fireInst);
    }
}
