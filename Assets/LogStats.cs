using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogStats : MonoBehaviour
{
    float health;
    int numofFires;
    bool canbeBurned;
    // Start is called before the first frame update
    void Start()
    {
        health = 100f;
        numofFires = 3;
        canbeBurned = false;
    }

    public void SetHealth(float nHealth)
    {
        health = nHealth;
    }

    public float GetHealth()
    {
        return health;
    }

    public int GetNumFires()
    {
        return numofFires;
    }

    public void SetNumFires(int numfires)
    {
        numofFires = numfires;
    }

    public bool CanItBeBurned()
    {
        return canbeBurned;
    }
}
