using Unity.VisualScripting;
using UnityEngine;

public class TrackLerp : MonoBehaviour
{
    public string targetName = "TrackedObject";
    public float smoothTime = 0.1f;

    private GameObject target;
    private Transform targetTransform;
    private float lerpTime;

    void Start()
    {
        target = GameObject.Find(targetName);
        targetTransform = target.GetComponent<Transform>();
    }

    void Update()
    {
        lerpTime += Time.deltaTime;
        lerpTime = Mathf.Clamp01(lerpTime);

        
        transform.SetPositionAndRotation(
            new Vector3(
            Mathf.Lerp(transform.position.x, targetTransform.position.x, lerpTime),
            Mathf.Lerp(transform.position.y, targetTransform.position.y, lerpTime),
            Mathf.Lerp(transform.position.z, targetTransform.position.z, lerpTime)
            ), 
            Quaternion.Euler(
            Mathf.Lerp(transform.eulerAngles.x, targetTransform.eulerAngles.x, lerpTime),
            Mathf.Lerp(transform.eulerAngles.y, targetTransform.eulerAngles.y, lerpTime),
            Mathf.Lerp(transform.eulerAngles.z, targetTransform.eulerAngles.z, lerpTime)
            ));
    }
}
