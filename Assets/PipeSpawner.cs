using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2;
    public EventManager eventManager;

    private float timer = 0;
    private float heightOffset = 10;
    private bool isDisabled = false;

    void Start()
    {
        eventManager.birdDeadEvent.AddListener(HandleBirdDeadEvent);
        SpawnPipe();
    }

    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnPipe();
            timer = 0;
        }
    }

    void SpawnPipe()
    {
        if (isDisabled)
        {
            return;
        }

        float highestPoint = transform.position.y + heightOffset;
        float lowestPoint = transform.position.y - heightOffset;
        GameObject instantiatedPipe = Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
        Pipe pipeScript = instantiatedPipe.GetComponent<Pipe>();
        pipeScript.verticalSpeed = Random.Range(7f, 21f);
    }

    private void HandleBirdDeadEvent()
    {
        isDisabled = true;
    }
}
