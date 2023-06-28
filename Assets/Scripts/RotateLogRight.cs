using UnityEngine;
using UnityEngine.EventSystems;

public class RotateLogRight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool isRotating;
    [SerializeField]
    GameObject buttonsController;

    float speed = 50f;
    // Start is called before the first frame update
    void Start()
    {
        isRotating = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isRotating)
        {
            ResourceManager.Instance.GetInstantiatedFuel().transform.Rotate(0f, 0f, speed * Time.deltaTime);
            
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
