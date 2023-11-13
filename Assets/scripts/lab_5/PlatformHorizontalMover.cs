using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHorizontalMover : MonoBehaviour
{
    private bool isMoving = false;
    private bool moveToTarget = true;
    public Transform targetLocat;
    public float speed = 1.0f;
    private Vector3 startPosition;
    private Vector3 endPosition;


    void Start()
    {
        Debug.Log("platforma czeka na pasa¿era...");
        startPosition = transform.position;
        if (targetLocat != null){
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
            if (moveToTarget){
                moveToTarget = false;
            }
            else{
                isMoving = false;
            }
        }
    }
    private void OnTriggerEnter(Collider coll)
    {
        Debug.Log("jakieœ rigidbody jest na platformie...");
        Debug.Log("Imie rigidbody: " + coll.name);

        if (coll.CompareTag("Player") && !isMoving)
        {
            Debug.Log("Platforma rusza...");
            isMoving = true;
            moveToTarget = true;
        }
    }
}
