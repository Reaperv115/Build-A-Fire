using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustParticles : MonoBehaviour
{
    Burn burn;
    // Start is called before the first frame update
    void Start()
    {
        burn = GameObject.Find("fire").GetComponent<Burn>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementParticleLifetime()
    {
        burn.IncreaseHeat();
    }

    public void DecrementParticleAttributes()
    {
        burn.DecreaseHeat();
    }
}
