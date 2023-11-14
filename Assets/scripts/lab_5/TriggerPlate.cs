using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlate : MonoBehaviour
{
    private float gravityValue = -9.81f;
    public float multiplier = 3.0f;
    private float jumpHeight = 1.0f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            NewMov newMov = other.GetComponent<NewMov>();
            if (newMov != null) newMov.ThrowPlayer(new Vector3(0, Mathf.Sqrt(jumpHeight * -3.0f * gravityValue) * multiplier, 0));
        }
    }
}