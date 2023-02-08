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
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
                    rb.velocity = Vector3.zero;
                }
                
            }
        
        
        transform.LookAt(firePit.transform);
        
        Debug.DrawRay(transform.position, Vector3.up * 40f, Color.blue, Mathf.Infinity);
        Debug.DrawRay(transform.position, Vector3.down * 40f, Color.blue, Mathf.Infinity);
        Debug.DrawRay(transform.position, Vector3.left * 40f, Color.blue, Mathf.Infinity);
        Debug.DrawRay(transform.position, Vector3.right * 40f, Color.blue, Mathf.Infinity);
        CollisionDetection();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isMoving)
            Move(touchPosition);
    }

    void Move(Vector3 t)
    {
        if (tooClose)
        {
            float rbSpeeed = 1000f;
            rb.AddForce(t * rbSpeeed * Time.deltaTime);
            transform.Translate(t * speed * Time.deltaTime);
        }
        else
            transform.Translate(t * speed * Time.deltaTime);
    }

    void CollisionDetection()
    {
        if (Physics.Raycast(transform.position, Vector3.up, out hit, 40f, mask))
        {
            float distance = Vector3.Distance(transform.position, hit.point);
            Debug.Log(hit.transform.name);
            Debug.Log(distance);
            if (distance < 2f)
            {
                tooClose = true;
            }
            else
                tooClose = false;
        }
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 40f, mask))
        {
            float distance = Vector3.Distance(transform.position, hit.point);
            Debug.Log(hit.transform.name);
            Debug.Log(distance);
            if (distance < 2f)
            {
                tooClose = true;
            }
            else
                tooClose = false;
        }
        if (Physics.Raycast(transform.position, Vector3.left, out hit, 40f, mask))
        {
            float distance = Vector3.Distance(transform.position, hit.point);
            Debug.Log(hit.transform.name);
            Debug.Log(distance);
            if (distance < 2f)
            {
                tooClose = true;
            }
            else
                tooClose = false;
        }
        if (Physics.Raycast(transform.position, Vector3.right, out hit, 40f, mask))
        {
            float distance = Vector3.Distance(transform.position, hit.point);
            Debug.Log(hit.transform.name);
            Debug.Log(distance);
            if (distance < 2f)
            {
                tooClose = true;
            }
            else
                tooClose = false;
        }
    }
}
