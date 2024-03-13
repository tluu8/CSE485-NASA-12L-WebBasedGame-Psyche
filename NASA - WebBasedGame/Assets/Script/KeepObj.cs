using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepObj : MonoBehaviour
{
    [HideInInspector]
    public string nameID;

    private void Awake()
    {
        nameID = name;
    }
    // Start is called before the first frame update
    void Start()
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
