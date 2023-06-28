using UnityEngine;
using UnityEngine.EventSystems;

public class RotateLogUp : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool isRotating;

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
            ResourceManager.Instance.GetInstantiatedFuel().transform.Rotate(speed * Time.deltaTime, 0f, 0f);
            
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
