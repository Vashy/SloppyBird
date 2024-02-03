using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float moveFactor;
    public bool IsAlive { get; private set; } = true;
    public GameObject soundManager;

    private SoundManagerScript soundManagerScript;
    private LogicManagerScript logic;

    private const float minAllowedHeight = -20;
    private const float maxAllowedHeight = 17;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
        soundManagerScript = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManagerScript>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }

        if (IsAlive && Input.GetKeyDown(KeyCode.Space))
        {
            myRigidBody.velocity = Vector2.up * moveFactor;
        }

        if (IsAlive && IsOverScreen())
        {
            die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsAlive)
        {
            die();
        }
    }

    private bool IsOverScreen()
    {
        return gameObject.transform.position.y < minAllowedHeight || gameObject.transform.position.y > maxAllowedHeight;
    }

    private void die()
    {
        logic.GameOver();
        IsAlive = false;
        soundManagerScript.PlaySound(SoundType.Death);
    }
}
