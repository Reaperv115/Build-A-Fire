using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpawnFuel : MonoBehaviour
{
    List<GameObject> fuel;
    List<GameObject> fires;
    GameObject wood, paper, instantiatedFuel, spottoDrop, instantiatedspottoDrop;
    Touch touch;
    float speed = 0.01f;

    [SerializeField]
    Button rotateUp, rotateDown, rotateLeft, rotateRight, spawnWood, spawnPaper, placeFuel;
    bool controllingFuel;
    

    Vector3 center;

    [SerializeField]
    Transform fuelspawnPos;
    [SerializeField]
    GameObject firePit;

    GameObject fuelX, fuelY, fuelZ;
    GameObject fire, litFire;

    RaycastHit hit;

    

    float scaleX, scaleY, scaleZ;
    float elapsedTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        rotateUp.gameObject.SetActive(false);
        rotateDown.gameObject.SetActive(false);
        rotateLeft.gameObject.SetActive(false);
        rotateRight.gameObject.SetActive(false);
        placeFuel.gameObject.SetActive(false);
        spottoDrop = Resources.Load<GameObject>("Spot To Drop");
        fuelX = GameObject.Find("Fuel Scale X");
        fuelX.SetActive(false);
        fuelY = GameObject.Find("Fuel Scale Y");
        fuelY.SetActive(false);
        fuelZ = GameObject.Find("Fuel Scale Z");
        fuelZ.SetActive(false);
        fire = Resources.Load<GameObject>("fire");
        fuel = new List<GameObject>();
        fires = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (controllingFuel)
            {
                ActivatingFuelUI();
                ResizeFuel(instantiatedFuel);
                MoveFuel(instantiatedFuel);   
            }
            else
            {
                DeactivatingFuelUI();
                touch = Input.GetTouch(0);
                //if (Physics.Raycast(Camera.main.ScreenPointToRay(touch.position), out hit))
                //{
                //    // checking if you're tapping on fuel and you haven't already lit a fire. cant be setting rock on fire
                //    if (!GameObject.Find("fire(Clone)") && fuel.Count > 0 && hit.transform.tag.Equals("fuel"))
                //    {
                //        litFire = Instantiate(fire, hit.point, fire.transform.rotation, hit.transform);
                //        litFire.GetComponent<Burn>().SetIsBurning(true);
                //    }
                //}
            }
        }
        
    }

    public void SpawnWood()
    {
        wood = Resources.Load<GameObject>("log");
        controllingFuel = true;
        instantiatedFuel = Instantiate(wood, fuelspawnPos.position, wood.transform.rotation);
        fuelX.GetComponent<Slider>().value = instantiatedFuel.transform.localScale.x;
        fuelY.GetComponent<Slider>().value = instantiatedFuel.transform.localScale.y;
        fuelZ.GetComponent<Slider>().value = instantiatedFuel.transform.localScale.z;
    }
    public void SpawnPaper()
    {
        paper = Resources.Load<GameObject>("crumbled paper");
        controllingFuel = true;
        instantiatedFuel = Instantiate(paper, fuelspawnPos.position, paper.transform.rotation);
        for (int i = 0; i < instantiatedFuel.transform.childCount; ++i)
            instantiatedFuel.transform.GetChild(i).name = "crumbled paper(Clone)";
        fuelX.GetComponent<Slider>().value = instantiatedFuel.transform.localScale.x;
        fuelY.GetComponent<Slider>().value = instantiatedFuel.transform.localScale.y;
        fuelZ.GetComponent<Slider>().value = instantiatedFuel.transform.localScale.z;
    }

    public GameObject GetFuel()
    {
        return instantiatedFuel;
    }

    public void SetControllingFuel(bool isControlling)
    {
        controllingFuel = isControlling;
    }

    public void PlacedInThePit(GameObject gas)
    {
        fuel.Add(gas);
    }
    public void Lit(GameObject go)
    {
        fires.Add(go);
    }

    public GameObject GetFireInst()
    {
        return litFire;
    }

    public int NumFires()
    {
        return fires.Count;
    }

    void ActivatingFuelUI()
    {
        rotateUp.gameObject.SetActive(true);
        rotateDown.gameObject.SetActive(true);
        rotateLeft.gameObject.SetActive(true);
        rotateRight.gameObject.SetActive(true);
        placeFuel.gameObject.SetActive (true);
        spawnWood.gameObject.SetActive(false);
        spawnPaper.gameObject.SetActive(false);
        fuelX.SetActive(true);
        fuelY.SetActive(true);
        fuelZ.SetActive(true);
    }
    void DeactivatingFuelUI()
    {
        rotateUp.gameObject.SetActive(false);
        rotateDown.gameObject.SetActive(false);
        rotateLeft.gameObject.SetActive(false);
        rotateRight.gameObject.SetActive(false);
        placeFuel.gameObject.SetActive(false);
        spawnWood.gameObject.SetActive(true);
        spawnPaper.gameObject.SetActive(true);
        fuelX.SetActive(false);
        fuelY.SetActive(false);
        fuelZ.SetActive(false);
    }
    void MoveFuel(GameObject fuel)
    {
         switch (fuel.transform.name)
                    {
                        case "log(Clone)":
                            {
                            touch = Input.GetTouch(0);
                            fuel.transform.position = new Vector3(
                                         fuel.transform.position.x + touch.deltaPosition.x * speed,
                                         fuel.transform.position.y,
                                         fuel.transform.position.z + touch.deltaPosition.y * speed);

                                if (Physics.Raycast(instantiatedFuel.GetComponent<CapsuleCollider>().bounds.center, Vector3.down, out hit, Mathf.Infinity))
                                {
                                    
                                    if (touch.phase.Equals(TouchPhase.Ended)) instantiatedspottoDrop = Instantiate(spottoDrop, hit.point, spottoDrop.transform.rotation);
                                    else Destroy(instantiatedspottoDrop);
                                }
                                break;
                            }
                        case "crumbled paper(Clone)":
                            {
                            touch = Input.GetTouch(0);
                            fuel.transform.position = new Vector3(
                                        fuel.transform.position.x + touch.deltaPosition.x * speed,
                                        fuel.transform.position.y,
                                        fuel.transform.position.z + touch.deltaPosition.y * speed);
                                if (Physics.Raycast(instantiatedFuel.GetComponent<SphereCollider>().bounds.center, Vector3.down, out hit, Mathf.Infinity))
                                {
                                    
                                    if (touch.phase.Equals(TouchPhase.Ended)) instantiatedspottoDrop = Instantiate(spottoDrop, hit.point, spottoDrop.transform.rotation);
                                    else Destroy(instantiatedspottoDrop);
                                }
                                break;
                            }
                        default:
                            break;
                    }
    }
    void ResizeFuel(GameObject fuelGo)
    {
        scaleX = fuelX.GetComponent<Slider>().value;
        scaleY = fuelY.GetComponent<Slider>().value;
        scaleZ = fuelZ.GetComponent<Slider>().value;
        fuelGo.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
    }
}
