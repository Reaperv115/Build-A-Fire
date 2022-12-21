using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    float speed = 10f;
    [SerializeField] GameObject firePit;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach(Touch touch in Input.touches)
        {
            transform.Translate(touch.deltaPosition * speed * Time.deltaTime);
            transform.LookAt(firePit.transform);
        }
    }
}
