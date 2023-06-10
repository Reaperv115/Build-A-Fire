using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
    ParticleSystem.MinMaxCurve firestartlifeTime;
    ParticleSystem.MainModule main;
    RaycastHit hit;

    float tmpRad;
    float tmpslT;
    float tmpsS;

    // Start is called before the first frame update
    void Start()
    {

        heat = 0.0f;
        
        firePS = GetComponent<ParticleSystem>();
        main = firePS.main;
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
        
    }

    public void LightFire()
    {
        beginBurning = true;
    }
    public void IncreaseHeat()
    {
        heat += .05f;
        tmpslT = main.startLifetime.constant;
        tmpslT += Time.deltaTime * heat;
        print("start life: " + tmpslT);
        main.startLifetime = tmpslT;
        if (heat > 1f)
        {
            tmpsS = main.startSize.constant;
            tmpsS += (Time.deltaTime * heat / .5f);
            print("start size: " + tmpsS);
            main.startSize = tmpsS;
        }
        if (heat > 2f)
        {
            var shape = firePS.shape;
            tmpRad = shape.radius;
            tmpRad += (Time.deltaTime * heat / .9f);
            print("radius: " + tmpRad);
            shape.radius = tmpRad;
        }
    }
    public void DecreaseHeat()
    {
        heat -= .001f;
        tmpslT = main.startLifetime.constant;
        tmpslT += Time.deltaTime * heat;
        print("start life: " + tmpslT);
        main.startLifetime = tmpslT;
        if (heat > 1f)
        {
            tmpsS = main.startSize.constant;
            tmpsS += (Time.deltaTime * heat / .5f);
            print("start size: " + tmpsS);
            main.startSize = tmpsS;
        }
        if (heat > 2f)
        {
            var shape = firePS.shape;
            tmpRad = shape.radius;
            tmpRad += (Time.deltaTime * heat / .9f);
            print("radius: " + tmpRad);
            shape.radius = tmpRad;
        }
    }

    public void SetHeat(float nHeat)
    {
        heat = nHeat;
    }
    public float GetHeat()
    {
        return heat;
    }
}
