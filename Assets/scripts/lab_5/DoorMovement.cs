using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMovement : MonoBehaviour
{
    private bool isMoving = false;
    private bool moveToTarget = true;
    public Transform targetLocat;
    public float speed = 1.0f;
    private Vector3 startPosition;
    private Vector3 endPosition;


    void Start()
    {
        startPosition = transform.position;
        if (targetLocat != null)
        {
            endPosition = targetLocat.position;
        }
    }

    void Update()
    {
        if (isMoving)
        {
            MovePlatform();
        }
    }
    void MovePlatform()
    {
        Vector3 newPosition = moveToTarget ? endPosition : startPosition;
        transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);

        if (transform.position == newPosition)
        {

            isMoving = false;

        }
    }
    private void OnTriggerEnter(Collider coll)
    {
        Debug.Log("Ktoœ jest przed drzwiami...");
        Debug.Log("Compare tag" + coll.CompareTag("Player"));
        Debug.Log("Is moving" + isMoving);

        if (coll.CompareTag("Player") && !isMoving)
        {
            Debug.Log("Drzwi siê otwieraj¹...");
            isMoving = true;
            moveToTarget = true;
        }
    }
}
