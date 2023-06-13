using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceFuel : MonoBehaviour
{
    [SerializeField]
    GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DropFuel()
    {
        camera.GetComponent<SpawnFuel>().GetFuel().GetComponent<Rigidbody>().useGravity = true;
        camera.GetComponent<SpawnFuel>().SetControllingFuel(false);
        camera.GetComponent<SpawnFuel>().PlacedInThePit(camera.GetComponent<SpawnFuel>().GetFuel());
        switch (camera.GetComponent<SpawnFuel>().GetFuel().transform.name)
        {
            case "log(Clone)":
                {
                    camera.GetComponent<SpawnFuel>().GetFuel().transform.GetComponent<CapsuleCollider>().enabled = true;
                    camera.GetComponent<SpawnFuel>().GetFuel().GetComponent<LogStats>().SetIsBurning(true);
                    break;
                }
            case "crumbled paper(Clone)":
                {
                    camera.GetComponent<SpawnFuel>().GetFuel().transform.GetComponent<SphereCollider>().enabled = true;
                    break;
                }
            default:
                break;
        }
    }
}
