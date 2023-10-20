using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMouse : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 target;
    private bool isMoving = false;
    private float fixedY = -3.495f;  // The fixed Y-coordinate when touching the floor

    void Start()
    {
        target = transform.position;
        transform.position = new Vector3(transform.position.x, fixedY, transform.position.z);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.y = fixedY;  // Set the Y-coordinate to the fixed value
            target.z = transform.position.z;  // Keep the original Z-coordinate
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
