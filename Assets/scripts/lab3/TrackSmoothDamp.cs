using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSmoothDamp : MonoBehaviour
{
    public string targetName = "TrackedObject";
    public float smoothTime = 0.1f;

    private GameObject target;
    private Transform targetTransform;
    private Vector3 positionVelocity;
    private Vector3 rotationVelocity;

    void Start()
    {
        target = GameObject.Find(targetName);
        targetTransform = target.GetComponent<Transform>();
    }

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, targetTransform.position, ref positionVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(Vector3.SmoothDamp(transform.eulerAngles, targetTransform.eulerAngles, ref rotationVelocity, smoothTime));
    }
}
