using UnityEngine;
using UnityEngine.EventSystems;

public class RotateLogLeft : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool isRotating;
    [SerializeField]
    GameObject buttonsController;

    float speed = 25f;
    // Start is called before the first frame update
    void Start()
    {
        isRotating = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isRotating);
        if (isRotating)
        {
            buttonsController.GetComponent<ButtonCentral>().GetFuelInst().transform.Rotate(0f, 0f, -speed * Time.deltaTime);
            
        }
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        isRotating = true;
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
       isRotating = false;
    }
}
