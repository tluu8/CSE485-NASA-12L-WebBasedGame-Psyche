using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMouse : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 target;
    private bool isMoving = false;

    void Start()
    {
        target = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
            isMoving = true;
        }
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, target) < 0.01f)
            {
                transform.position = target; // Snap directly to target
                isMoving = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name); // This will log the name of the collided object

        if (collision.gameObject.CompareTag("Floor"))
        {
            target = transform.position; // Set the current position as the target
            isMoving = false;
        }
    }
}