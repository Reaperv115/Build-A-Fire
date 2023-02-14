using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    float speed = 10f;
    [SerializeField] GameObject firePit;
    [SerializeField] LayerMask mask;
    bool isMoving = false;
    bool tooClose;
    Vector3 touchPosition;
    Quaternion deltaRotation;
    RaycastHit hit;
    Rigidbody rb;
    CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
        tooClose = false;
    }
    void Update()
    {
        Debug.Log("Close: " + tooClose);
            foreach(Touch touch in Input.touches)
            {
                if (touch.phase.Equals(TouchPhase.Moved))
                {
                    isMoving = true;
                    touchPosition = touch.deltaPosition;
                }
                if (touch.phase.Equals(TouchPhase.Ended))
                {
                    isMoving = false;
                }
                
            }
        
        
        transform.LookAt(firePit.transform);
        
        Debug.DrawRay(transform.position, Vector3.up * 40f, Color.blue, Mathf.Infinity);
        Debug.DrawRay(transform.position, Vector3.down * 40f, Color.blue, Mathf.Infinity);
        Debug.DrawRay(transform.position, Vector3.left * 40f, Color.blue, Mathf.Infinity);
        Debug.DrawRay(transform.position, Vector3.right * 40f, Color.blue, Mathf.Infinity);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isMoving)
            Move(touchPosition);
    }

    void Move(Vector3 t)
    {
        float x = t.x;
        float y = t.y;
        float z = t.z;
        Vector3 move = transform.right * x + transform.up * y + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);
        //if (tooClose)
        //{
        //    float rbSpeeed = 1000f;
        //    transform.Translate(t * speed * Time.deltaTime);
        //}
        //else
        //    transform.Translate(t * speed * Time.deltaTime);
    }
}
