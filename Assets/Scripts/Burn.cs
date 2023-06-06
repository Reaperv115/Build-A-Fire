using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burn : MonoBehaviour
{
    GameObject camera;
    ParticleSystem firePS;
    List<ParticleCollisionEvent> collisionEvents;

    GameObject litFire;

    bool beginBurning;

    ParticleSystem.EmissionModule emission;
    ParticleSystem.ShapeModule shape;
    float heat;
    float heatX, heatY;
    ParticleSystem.MinMaxCurve firestartlifeTime;
    ParticleSystem.MainModule main;
    RaycastHit hit;

    // tmp variable used for
    // initially getting the fire started
    float tmp = 0f;

    // Start is called before the first frame update
    void Start()
    {
        firePS = GetComponent<ParticleSystem>();
        emission = this.GetComponent<ParticleSystem>().emission;
        shape = this.GetComponent<ParticleSystem>().shape;
        camera = GameObject.Find("Main Camera");
        main = firePS.main;
        heat = main.startLifetime.constant;
        beginBurning = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public ParticleSystem.MainModule GetMainPS()
    {
        return main;
    }
    
    void IgniteFire(GameObject other)
    {
        int collcount = firePS.GetSafeCollisionEventSize();
        collisionEvents = new List<ParticleCollisionEvent>(collcount);
        int eventCount = firePS.GetCollisionEvents(other, collisionEvents);
        for (int i = 0; i < eventCount; ++i)
        {
            switch (other.transform.name)
            {
                case "log(Clone)":
                    {
                        if (other.GetComponent<LogStats>().CanItBeBurned().Equals(true))
                        {
                            other.GetComponent<LogStats>().SetHealth(other.GetComponent<LogStats>().GetHealth() - .00002f);
                            if (other.GetComponent<LogStats>().GetHealth() <= 0)
                            {
                                Destroy(other);
                            }
                            if (other.GetComponent<LogStats>().GetHealth() < 80 && other.GetComponent<LogStats>().GetNumFires() > 0)
                            {
                                litFire = Instantiate(this.gameObject, collisionEvents[i].intersection, this.transform.rotation, other.transform);
                                other.GetComponent<LogStats>().SetHealth(other.GetComponent<LogStats>().GetHealth() - .00002f);
                            }
                        }
                        break;
                    }
                case "crumbled paper(Clone)":
                    {
                        if (other.GetComponent<PaperStats>().CanItBeBurned().Equals(true))
                        {
                            other.GetComponent<PaperStats>().SetHealth(other.GetComponent<PaperStats>().GetHealth() - .0002f);
                            if (other.GetComponent<PaperStats>().GetHealth() <= 0)
                            {
                                Destroy(other);
                            }
                            if (other.GetComponent<PaperStats>().GetHealth() < 80 && other.GetComponent<PaperStats>().GetNumFires() > 0 && other.GetComponent<PaperStats>().CanItBeBurned().Equals(true))
                            {
                                litFire = Instantiate(this.gameObject, collisionEvents[i].intersection, this.transform.rotation, other.transform);
                                other.GetComponent<PaperStats>().SetHealth(other.GetComponent<PaperStats>().GetHealth() - .0002f);
                            }
                        }
                        break;
                    }
                default:
                    break;
            }
        }
    }

    public void LightFire()
    {
        beginBurning = true;
    }
}
