using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class moveTriangle : MonoBehaviour
{
    GameObject go;
    Camera aCam;
    // Start is called before the first frame update
    void Start()
    {
        go = GetComponent<GameObject>();
        aCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {    
        Mouse mouse = Mouse.current;
        if (mouse.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePosition = mouse.position.ReadValue();
            go.transform.position = mousePosition;
            
        }
    }
}
