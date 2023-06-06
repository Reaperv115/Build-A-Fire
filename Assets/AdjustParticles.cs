using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustParticles : MonoBehaviour
{
    ParticleSystem fireSystem;
    float particlestartlifeTime;
    ParticleSystem.MainModule mainModule;
    // Start is called before the first frame update
    void Start()
    {
        fireSystem = GameManager.instance.GetFireRef().GetComponent<ParticleSystem>();
        mainModule = fireSystem.main;
        particlestartlifeTime = mainModule.startLifetime.constant;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(particlestartlifeTime);
        mainModule.startLifetime = particlestartlifeTime;
    }

    public void IncrementParticleLifetime()
    {
        particlestartlifeTime += 1f;
        
        Debug.Log("incrementing life time");
    }
}
