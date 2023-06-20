using UnityEngine;
using UnityEngine.EventSystems;

public class RotateLogDown : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool isRotating;

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
            ResourceManager.Instance.GetInstantiatedFuel().transform.Rotate(-speed * Time.deltaTime, 0f, 0f);
            
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
