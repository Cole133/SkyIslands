using UnityEngine;

public class ClickedMovment : MonoBehaviour
{
    [Header("Movment")]
    public float moveSpeed = 3f;
    private Vector3 targetPosition;
    private bool isMoving = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movment();
    }

    public void Movment()
    {
        if (isMoving)
        {
            float step = moveSpeed * Time.deltaTime;
            float distance = Vector3.Distance(transform.position, targetPosition);

            // Move the player toward the target
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            // Snap exactly and stop moving if close enough
            if (distance < 0.01f)
            {
                transform.position = targetPosition;
                isMoving = false;
            }
        }
    }

    public void SetTargetPosition(Vector3 position)
    {
        targetPosition = position;
        isMoving = true;
    }
}
