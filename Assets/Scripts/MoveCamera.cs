using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveCamera : MonoBehaviour
{
    float speed = 10f;
    [SerializeField] GameObject firePit;
    [SerializeField] LayerMask mask;
    bool isMoving = false;
    Vector3 touchPosition;
    CharacterController characterController;

    float zoomSpeed = 0.1f;
    float zoomminBound = 0.1f;
    float zoommaxBound = 40f;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        transform.LookAt(GameManager.instance.GetIgnite().gameObject.transform);
        if (IsPointerOverUIObject())
        {
            print("clicked UI");
        }
        else
        {
            if (Input.touchCount >= 2)
            {
                Vector2 currtouch0, currtouch1, prevtouch0, prevtouch1;
                currtouch0 = Input.GetTouch(0).position;
                currtouch1 = Input.GetTouch(1).position;
                prevtouch0 = currtouch0 - Input.GetTouch(0).deltaPosition;
                prevtouch1 = currtouch1 - Input.GetTouch(1).deltaPosition;

                float oldtouchDistance = Vector2.Distance(prevtouch0, prevtouch1);
                float newtouchDistance = Vector2.Distance(currtouch0, currtouch1);
                float deltaDistance = oldtouchDistance - newtouchDistance;
                GetComponent<Camera>().fieldOfView += deltaDistance * zoomSpeed;
                GetComponent<Camera>().fieldOfView = Mathf.Clamp(GetComponent<Camera>().fieldOfView, zoomminBound, zoommaxBound);
                if (GetComponent<Camera>().fieldOfView < zoomminBound)
                    GetComponent<Camera>().fieldOfView = .1f;
                if (GetComponent<Camera>().fieldOfView > 40f)
                    GetComponent<Camera>().fieldOfView = 40f;
            }
            else
            {
                foreach (Touch touch in Input.touches)
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
            }
        }
        
    }
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
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
    }
}
