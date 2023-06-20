using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleFuel : MonoBehaviour
{
    bool ishandlingFuel;
    Touch touch;
    float speed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        ishandlingFuel = false;   
    }

    // Update is called once per frame
    void Update()
    {
        if (touch.tapCount > 0)
        {
            if (ishandlingFuel)
            {
                MoveFuel(ResourceManager.Instance.GetInstantiatedFuel());
            }
        }
    }

    public void SetIsHandlingFuel(bool isHandling)
    {
        ishandlingFuel = isHandling;
    }
    public bool IsHandlingFuel()
    {
        return ishandlingFuel;
    }
    void MoveFuel(GameObject fuel)
    {
        switch (fuel.transform.name)
        {
            case "log(Clone)":
                {
                    print("moving log");
                    touch = Input.GetTouch(0);
                    fuel.transform.position = new Vector3(
                                 fuel.transform.position.x + touch.deltaPosition.x * speed,
                                 fuel.transform.position.y,
                                 fuel.transform.position.z + touch.deltaPosition.y * speed);
                    break;
                }
            case "crumbled paper(Clone)":
                {
                    touch = Input.GetTouch(0);
                    fuel.transform.position = new Vector3(
                                fuel.transform.position.x + touch.deltaPosition.x * speed,
                                fuel.transform.position.y,
                                fuel.transform.position.z + touch.deltaPosition.y * speed);
                    break;
                }
            default:
                break;
        }
    }
    public void DropFuel()
    {
        print("drop fuel");
        ResourceManager.Instance.GetInstantiatedFuel().GetComponent<Rigidbody>().useGravity = true;
        ishandlingFuel = false;
        switch (ResourceManager.Instance.GetInstantiatedFuel().transform.name)
        {
            case "log(Clone)":
                {
                    ResourceManager.Instance.GetInstantiatedFuel().transform.GetComponent<CapsuleCollider>().enabled = true;
                    ResourceManager.Instance.GetInstantiatedFuel().transform.GetComponent<LogStats>().SetIsBurning(true);
                    break;
                }
            case "crumbled paper(Clone)":
                {
                    ResourceManager.Instance.GetInstantiatedFuel().transform.GetComponent<SphereCollider>().enabled = true;
                    ResourceManager.Instance.GetInstantiatedFuel().transform.GetComponent<PaperStats>().SetIsBurning(true);
                    break;
                }
            default:
                break;
        }
    }
}
