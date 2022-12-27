using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    float speed = 1000f;
    Rigidbody rb;
    [SerializeField] GameObject firePit;
    bool isMoving = false;
    Vector3 touchPosition;
    Quaternion deltaRotation;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Debug.Log(isMoving);
        
        transform.LookAt(firePit.transform);
        foreach(Touch touch in Input.touches)
        {
            if (touch.phase.Equals(TouchPhase.Moved))
            {
                isMoving = true;
                touchPosition = touch.deltaPosition;
            }
            if (touch.phase.Equals(TouchPhase.Ended))
                isMoving = false;
                
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        deltaRotation = Quaternion.Euler(touchPosition * Time.deltaTime);
        rb.MoveRotation(deltaRotation);
        if (isMoving)
            Move(touchPosition);
        rb.velocity = Vector3.zero;
    }

    void Move(Vector3 t)
    {
        rb.AddForce(t * speed * Time.deltaTime);
    }
}
