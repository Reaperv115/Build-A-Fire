using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveFuel : MonoBehaviour
{
    [SerializeField] GameObject cam;
    Button movefuelBtn;
    GameObject movecameraBtn;
    GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("UI Canvas");
        movecameraBtn = GameObject.Find("Move Camera");
        movefuelBtn = GetComponent<Button>();
        movefuelBtn.onClick.AddListener(BeginMovingFuel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeginMovingFuel()
    {
        if (ResourceManager.Instance.GetInstantiatedFuel())
        {
            canvas.GetComponent<HandleFuel>().SetIsHandlingFuel(true);
            cam.GetComponent<MoveCamera>().SetIsAdjustingCamera(false);
        }
    }
}
