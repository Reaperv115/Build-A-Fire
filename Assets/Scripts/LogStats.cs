using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogStats : MonoBehaviour
{
    float health;
    int numofFires;
    bool canbeBurned;
    GameObject fire, fireInst;
    Vector3 collision;
    // Start is called before the first frame update
    void Start()
    {
        health = 100f;
        numofFires = 3;
        canbeBurned = false;
        fire = GameObject.Find("fire");
    }

    private void Update()
    {
        if (canbeBurned)
        {
            print("Health: " +  health);
            if (health <= 75f)
            {
                fireInst = Instantiate(fire, fire.GetComponent<Burn>().GetIntersectionPoint(), fire.transform.rotation);
                StartCoroutine("fireInst.GetComponent<Burn>().FanTheFlame");
            }
        }
    }


    public void SetHealth(float nHealth)
    {
        health = nHealth;
    }

    public float GetHealth()
    {
        return health;
    }

    public void SetCollisionIntersection(Vector3 col)
    {
        collision = col;
    }

    public bool CanItBeBurned()
    {
        return canbeBurned;
    }
    public void SetIsBurning(bool isBurning)
    {
        canbeBurned = isBurning;
    }
}
