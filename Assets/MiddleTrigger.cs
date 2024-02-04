using UnityEngine;

public class MiddleTrigger : MonoBehaviour
{
    private const int birdLayer = 3;
    public LogicManager logic;
    public Bird birdScript;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag(Tags.Logic.ToString()).GetComponent<LogicManager>();
        birdScript = GameObject.FindGameObjectWithTag(Tags.Bird.ToString()).GetComponent<Bird>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == birdLayer && birdScript.IsAlive)
        {
            logic.AddScore(1);
        }
    }
}
