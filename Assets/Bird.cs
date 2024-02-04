using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float moveFactor;
    public bool IsAlive { get; private set; } = true;
    public GameObject soundManager;
    public EventManager eventManager;

    private LogicManager logic;

    private const float minAllowedHeight = -20;
    private const float maxAllowedHeight = 17;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(Scenes.Menu.ToString(), LoadSceneMode.Single);
        }

        if (IsAlive && Input.GetKeyDown(KeyCode.Space))
        {
            myRigidBody.velocity = Vector2.up * moveFactor;
        }

        if (IsAlive && IsOverScreen())
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsAlive)
        {
            Die();
        }
    }

    private bool IsOverScreen()
    {
        return gameObject.transform.position.y < minAllowedHeight || gameObject.transform.position.y > maxAllowedHeight;
    }

    private void Die()
    {
        logic.GameOver();
        IsAlive = false;
        eventManager.EmitBirdDeadEvent();
    }
}
