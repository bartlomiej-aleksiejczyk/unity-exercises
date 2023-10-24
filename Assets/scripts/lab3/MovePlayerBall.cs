using UnityEngine;

public class MovePlayerBall : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 force = new Vector3(horizontal, 0, vertical) * speed;
        rigidBody.AddForce(force);
    }
}
