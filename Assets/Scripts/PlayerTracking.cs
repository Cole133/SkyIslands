using UnityEngine;

public class PlayerTracking : MonoBehaviour
{
    public Transform target;      
    public float smoothSpeed = 5f;
    public Vector3 offset = new Vector3(0f, 0f, -1f);
    public float snapThreshold = 0.01f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothed = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothed;
    }
}
