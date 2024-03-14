using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class KeepObj : MonoBehaviour
{
    [HideInInspector]
    public string nameID = "";

    private void Awake()
    {
        if (nameID == "")
        {
            nameID = name + SceneManager.GetActiveScene().name;
        }  
        if (SceneManager.GetActiveScene().name == "TitleMenuScene" || SceneManager.GetActiveScene().name == "IntroductionScene")
        {
            Destroy(gameObject);
        }
        Debug.Log(nameID + " is accounted for.");
        //Debug.Log("This Scene is called: " + SceneManager.GetActiveScene().name + " with " + Object.FindObjectsOfType<KeepObj>(true).Length + " total objects.");
    }

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "TitleMenuScene" || SceneManager.GetActiveScene().name == "IntroductionScene")
        {
            Destroy(gameObject);
        }
        else
        {
            for (int i = 0; i < Object.FindObjectsOfType<KeepObj>().Length; i++)
            {
                if (Object.FindObjectsOfType<KeepObj>()[i] != this)
                {
                    if (Object.FindObjectsOfType<KeepObj>()[i].nameID == nameID)
                    {
                        Destroy(gameObject);
                    }
                }
            }
            DontDestroyOnLoad(gameObject);
        }
        
    }

    public void MenuCheck()
    {
        if (SceneManager.GetActiveScene().name == "TitleMenuScene" || SceneManager.GetActiveScene().name == "IntroductionScene")
        {
            gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "GameScene3")
        {
            
            //Debug.Log(nameID + " is here in this scene.");
        }
        if (SceneManager.GetActiveScene().name == "TitleMenuScene" || SceneManager.GetActiveScene().name == "IntroductionScene")
        {
            Destroy(gameObject);
        }
        //Debug.Log("This Scene is called: " + SceneManager.GetActiveScene().name);
    }


}
