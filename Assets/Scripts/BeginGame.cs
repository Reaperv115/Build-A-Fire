using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BeginGame : MonoBehaviour
{
    GameObject scenerydropDown;
    int dropdownValue = 0;

    List<TMP_Dropdown.OptionData> scenes = new List<TMP_Dropdown.OptionData>();
    // Start is called before the first frame update
    void Start()
    {
        scenerydropDown = GameObject.Find("Change Scenery");
        
        
        for (int i = 1; i < SceneManager.sceneCountInBuildSettings; ++i)
        {
            string name = System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
            Debug.Log(name);
            scenes.Add(new TMP_Dropdown.OptionData(name));
        }
        scenerydropDown.GetComponent<TMP_Dropdown>().AddOptions(scenes);
    }

    // Update is called once per frame
    void Update()
    {
        dropdownValue = scenerydropDown.GetComponent<TMP_Dropdown>().value;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(scenes[dropdownValue].text);
        Debug.Log(scenerydropDown.GetComponent<TMP_Dropdown>().options[dropdownValue].text);
    }
}
