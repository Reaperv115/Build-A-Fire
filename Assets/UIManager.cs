using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    GameObject[] buttons;
    HandleFuel handleFuel;
    // Start is called before the first frame update
    void Start()
    {
        buttons = new GameObject[transform.childCount];
        for (int i = 0; i < buttons.Length; ++i)
        {
            buttons[i] = transform.GetChild(i).gameObject;
        }
        buttons[2].SetActive(false);
        buttons[3].SetActive(false);
        handleFuel = GetComponent<HandleFuel>();
    }

    // Update is called once per frame
    void Update()
    {
        if (handleFuel.IsHandlingFuel())
        {
            buttons[3].SetActive(true);
            buttons[2].SetActive(true);
            buttons[0].SetActive(false);
            buttons[1].SetActive(false);
            buttons[4].SetActive(false);
            buttons[5].SetActive(false);
        }
        else
        {
            buttons[2].SetActive(false);
            buttons[3].SetActive(false);
            buttons[0].SetActive(true);
            buttons[1].SetActive(true);
            buttons[4].SetActive(true);
            buttons[5].SetActive(true);
        }
    }
}
