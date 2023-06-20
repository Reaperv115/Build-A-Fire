using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogStats : MonoBehaviour
{
    float health;
    bool canbeBurned;
    GameObject fire, fireInst, originalFire;
    List<GameObject> fires;
    ParticleSystem firePS;
    Vector3 collision;
    private List<ParticleCollisionEvent> collisionEvents;

    ParticleSystem.MinMaxCurve firestartlifeTime;
    ParticleSystem.MainModule main;
    ParticleSystem.EmissionModule emission;
    ParticleSystem.ShapeModule shape;

    float heat;
    private float tmpslT;
    private float tmpsS;
    private float tmpRad;

    bool burn;

    // Start is called before the first frame update
    void Start()
    {
        fires = new List<GameObject>();
        burn = false;
        heat = 0.0f;
        health = 100f;
        canbeBurned = false;
        fire = Resources.Load<GameObject>("fire");
        originalFire = GameObject.Find("fire");
    }

    private void Update()
    {
        

        if (heat <= 1f && fires.Count > 0)
        {
            
            print("fanning the flame");
            FanTheFlame();
        }

        if (canbeBurned)
        {
            if (health <= 75f)
            {
                    fireInst = Instantiate(fire, originalFire.GetComponent<Burn>().GetIntersectionPoint(), fire.transform.rotation, transform);
                    fires.Add(fireInst);
                
            }
        }
    }

    public void FanTheFlame()
    {
            foreach (GameObject ps in fires)
            {
                firePS = ps.GetComponent<ParticleSystem>();
                main = firePS.main;
                heat += .005f;
                tmpslT = main.startLifetime.constant;
                tmpslT += Time.deltaTime * heat;
                main.startLifetime = tmpslT;
                if (heat > 1f)
                {
                    tmpsS = main.startSize.constant;
                    tmpsS += (Time.deltaTime * heat / .5f);
                    main.startSize = tmpsS;
                }
                if (heat > 2f)
                {
                    var shape = firePS.shape;
                    tmpRad = shape.radius;
                    tmpRad += (Time.deltaTime * heat / .9f);
                    shape.radius = tmpRad;
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
