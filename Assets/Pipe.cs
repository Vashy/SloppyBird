using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float deadZone = -30f;
    public float verticalSpeed = 0f; // Genereted by PipeSpawner
    public EventManager eventManager;

    private float verticalDirection = Direction.Up;
    private const float maxHeight = 5f;
    private bool isDisabled = false;

    private void OnEnable()
    {
        eventManager = GameObject.FindGameObjectWithTag(Tags.EventManager.ToString()).GetComponent<EventManager>();
        eventManager.birdDeadEvent.AddListener(HandleBirdDeadEvent);
    }

    void Update()
    {
        //transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        if (isDisabled)
        {
            return;
        }

        transform.position = transform.position + new Vector3(-1 * moveSpeed, CalculateYPoint()) * Time.deltaTime;
        if (transform.position.x < deadZone)
        {
            Debug.Log("Pipe deleted");
            Destroy(gameObject);
        }
    }

    private float CalculateYPoint()
    {
        if (transform.position.y > maxHeight)
        {
            verticalDirection = Direction.Down;
        }
        else if (transform.position.y < -maxHeight)
        {
            verticalDirection = Direction.Up;
        }

        return verticalDirection * verticalSpeed;
    }

    private void HandleBirdDeadEvent()
    {
        isDisabled = true;
    }
}

class Direction
{
    public const float Up = 1;
    public const float Down = -1;
}
