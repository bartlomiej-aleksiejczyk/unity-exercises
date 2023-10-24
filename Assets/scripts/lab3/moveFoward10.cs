using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveForward10 : MonoBehaviour
{
    public float speed = 1f;
    private Vector3 start;
    private Vector3 end;

    void Start()
    {
        start = transform.position;
        end = start + transform.forward * 10f;
    }

    void Update()
    {
        float t = Mathf.PingPong(Time.time * speed, 1f);
        transform.position = Vector3.Lerp(start, end, t);
    }
}
