using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveCamera : MonoBehaviour
{
    float speed = 10f;
    [SerializeField] GameObject firePit;
    [SerializeField] LayerMask mask;
    Vector3 touchPosition;
    CharacterController characterController;

    float zoomSpeed = 0.1f;
    float zoomminBound = 0.1f;
    float zoommaxBound = 90f;


    bool moveCamera = false;

    HandleFuel handleFuel;
    GameObject adjustCamera;
    // Start is called before the first frame update
    void Start()
    {
        adjustCamera = GameObject.Find("Move Camera");
        handleFuel = GameObject.Find("UI Canvas").GetComponent<HandleFuel>();
        characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        transform.LookAt(GameManager.instance.GetIgnite().gameObject.transform);

        // checking to see if a UI element was touched
        if (IsPointerOverUIObject())
        {
        }
        else
        {
            if (moveCamera)
            {
                // zooming in and out
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

                    // checking to stay inside zoom-in bounds
                    if (GetComponent<Camera>().fieldOfView < zoomminBound)
                        GetComponent<Camera>().fieldOfView = zoomminBound;

                    // checking for zoom-out bounds
                    if (GetComponent<Camera>().fieldOfView > zoommaxBound)
                        GetComponent<Camera>().fieldOfView = zoommaxBound;
                }
                else
                {
                    // getting the delta position for moving
                    // the camera
                    foreach (Touch touch in Input.touches)
                    {
                        if (touch.phase.Equals(TouchPhase.Moved))
                        {
                            touchPosition = touch.deltaPosition;
                        }
                        if (touch.phase.Equals(TouchPhase.Ended))
                        {
                            touchPosition = Vector3.zero;
                        }

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
        if (moveCamera) Move(touchPosition);
    }

    void Move(Vector3 t)
    {
        float x = t.x;
        float y = t.y;
        float z = t.z;
        Vector3 move = transform.right * x + transform.up * y + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);
    }

    public bool GetIsAdjustingCamera()
    {
        return moveCamera;
    }

    public void SetIsAdjustingCamera(bool isadjusting)
    {
        moveCamera = isadjusting;
    }
    public HandleFuel GetHandleFuel()
    {
        return handleFuel;
    }
}
