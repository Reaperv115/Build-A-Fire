using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdjustCamera : MonoBehaviour
{
    [SerializeField] GameObject cam;

    Button movecamerabtn;
    HandleFuel handleFuel;
    // Start is called before the first frame update
    void Start()
    {
        movecamerabtn = GetComponent<Button>();
        movecamerabtn.onClick.AddListener(IsAdjustingCamera);

        handleFuel = GameObject.Find("UI Canvas").GetComponent<HandleFuel>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        
    }

    public void IsAdjustingCamera()
    {
        cam.GetComponent<MoveCamera>().SetIsAdjustingCamera(true);
        cam.GetComponent<MoveCamera>().GetHandleFuel().SetIsHandlingFuel(false);
    }
    
}
