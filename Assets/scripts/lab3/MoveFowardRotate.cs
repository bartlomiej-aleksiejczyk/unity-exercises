using UnityEngine;

public class MoveForwardRotate : MonoBehaviour
{
    public float speed = 1f;
    public float rotationStep = 1f;
    public float angle = 90f;
    private Vector3 targetPosition;
    private Quaternion targetRotation;

    public enum State
    {
        Moving,
        Rotating
    }
    private State currentState;

    void Start()
    {
        targetPosition = transform.position + transform.forward * 10f;
        targetRotation = Quaternion.Euler(0f, transform.eulerAngles.y + angle, 0f);
        currentState = State.Moving;
    }

    void Update()
    {
        switch (currentState)
        {
            case State.Moving:
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

                if (transform.position == targetPosition)
                {
                    currentState = State.Rotating;
                }
                break;

            case State.Rotating:
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationStep);

                if (transform.rotation == targetRotation)
                {
                    targetPosition = transform.position + transform.forward * 10f;
                    targetRotation = Quaternion.Euler(0f, transform.eulerAngles.y + angle, 0f);
                    currentState = State.Moving;
                }
                break;
        }
    }
}
