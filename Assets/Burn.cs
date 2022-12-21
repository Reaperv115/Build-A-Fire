using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burn : MonoBehaviour
{
    GameObject camera;
    ParticleSystem firePS;
    List<ParticleCollisionEvent> collisionEvents;

    GameObject litFire;

    bool isBurning;

    ParticleSystem.EmissionModule emission;
    ParticleSystem.ShapeModule shape;
    float heat;
    float heatX, heatY;
    ParticleSystem.MinMaxCurve firestartlifeTime;
    ParticleSystem.MainModule main;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        firePS = GetComponent<ParticleSystem>();
        emission = this.GetComponent<ParticleSystem>().emission;
        shape = this.GetComponent<ParticleSystem>().shape;
        camera = GameObject.Find("Main Camera");
        main = firePS.main;
        heat = main.startLifetime.constant;
    }

    // Update is called once per frame
    void Update()
    {
        if (isBurning)
        {
            heat += Time.deltaTime;
            int tmp = ((int)heat);
            if ((tmp % 2).Equals(0))
            {
                Debug.Log(main.startLifetime.constant);
                if (main.startLifetime.constant > 4f)
                {
                    this.shape.radius += heat;
                    if (!Physics.SphereCast(transform.position, shape.radius, Vector3.up, out hit)) return;
                    else
                    {
                        if (hit.transform.tag.Equals("fuel"))
                        {
                            IgniteFire(hit.transform.gameObject);
                        }
                    }                    
                }
                else
                {
                    main.startLifetime = heat;
                    
                }
            }
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        IgniteFire(other);   
    }

    public void SetIsBurning(bool isburning)
    {
        isBurning = isburning;
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
}
