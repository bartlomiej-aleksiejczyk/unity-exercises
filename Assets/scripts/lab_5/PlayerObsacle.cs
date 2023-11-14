using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObsacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("obsacle"))
        {
            Debug.Log("Gracz siê zderzy³ siê z przeszkod¹!");
        }
    }
}
