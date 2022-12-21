using UnityEngine;
using UnityEngine.EventSystems;

public class RotateLogUp : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
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
            buttonsController.GetComponent<ButtonCentral>().GetFuelInst().transform.Rotate(speed * Time.deltaTime, 0f, 0f);
            
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
