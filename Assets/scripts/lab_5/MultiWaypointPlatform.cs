using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiWaypointPlatform : MonoBehaviour
{
    private bool isMoving = false;
    public List<Transform> targetLocats;
    public float speed = 1.0f;
    private Vector3 startPosition;
    private int currentCollIndex = 0;
    private bool direct = true;

    void Start()
    {
        Debug.Log("platforma uniwersalna czeka na pasa¿era...");
        startPosition = transform.position;
        targetLocats.Insert(0, new GameObject("StartPosition").transform);
        targetLocats[0].position = startPosition;
    }

    void Update()
    {
        if (isMoving) MovePlatform();

    }
    void MovePlatform()
    {
        if (targetLocats.Count == 0) return;
        Vector3 targetPosition = targetLocats[currentCollIndex].position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (transform.position == targetPosition){
            if (direct){
                Debug.Log("przod: " + currentCollIndex);

                if (currentCollIndex < targetLocats.Count - 1)
                    currentCollIndex++;
                else{
                    direct = false;}}
            else {
                Debug.Log("tyl: " + currentCollIndex);
                if (currentCollIndex > 0) currentCollIndex--;
                else {
                    isMoving = false;
                    direct = true;
                }}}}

    private void OnTriggerEnter(Collider coll)
    {
        Debug.Log("jakieœ rigidbody jest na platformie...");
        Debug.Log("Imie rigidbody: " + coll.name);

        if (coll.CompareTag("Player") && !isMoving)
        {
            Debug.Log("Platforma rusza...");
            isMoving = true;
        }
    }
}
