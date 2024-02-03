using UnityEngine;

public class MiddleTriggerScript : MonoBehaviour
{
    private const int birdLayer = 3;
    public LogicManagerScript logic;
    public BirdScript birdScript;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
        birdScript = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == birdLayer && birdScript.IsAlive)
        {
            logic.AddScore(1);
        }
    }
}
