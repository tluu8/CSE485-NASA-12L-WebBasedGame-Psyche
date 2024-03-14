using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCleanser : MonoBehaviour
{
    private void Awake()
    {
        for (int i = 0; i < Object.FindObjectsOfType<KeepObj>(true).Length; i++)
        {
            Object.FindObjectsOfType<KeepObj>(true)[i].gameObject.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
