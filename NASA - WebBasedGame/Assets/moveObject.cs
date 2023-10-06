using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class moveObject : MonoBehaviour
{
    Rigidbody2D rigid;

    

    // Start is called before the first frame update
    void Start()
    {
        //rigid = GetComponent<Rigidbody2D>();
    }

    Camera aCamera;

    void Awake()
    {
        aCamera = Camera.main;
       rigid = GetComponent<Rigidbody2D>();
    }

    void OnMouseDown()
    {
        //GameObject theObject = GetComponent<GameObject>();

        //MoveDirection direction = MoveDirection.Left;

        //rigid.MovePosition(Input.mousePosition);
    }

    // Update is called once per frame
    void Update()
    {
        Mouse mouse = Mouse.current;
        if (mouse.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePosition = mouse.position.ReadValue();
            rigid.transform.position = mousePosition;
        }
    }
}
