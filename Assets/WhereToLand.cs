using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhereToLand : MonoBehaviour
{
    RaycastHit hit;
    GameObject spottoDrop, instantiatedspottoDrop;

    Vector3 oldworldPoint, newworldPoint;
    Touch touch;

    [SerializeField]
    GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        spottoDrop = Resources.Load<GameObject>("Spot To Drop");
    }

    // Update is called once per frame
    void Update()
    {
        oldworldPoint = newworldPoint;
        newworldPoint = touch.position;
        if (!newworldPoint.Equals(oldworldPoint))
        {
            newworldPoint = touch.position;
            newworldPoint.z = Mathf.Abs(Camera.main.transform.position.z);

            if (Physics.Raycast(GetComponent<CapsuleCollider>().bounds.center, Vector3.down, out hit, Mathf.Infinity))
            {
                instantiatedspottoDrop = Instantiate(spottoDrop, hit.point, spottoDrop.transform.rotation);
            }
        }
    }
}
