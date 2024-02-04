using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicManager : MonoBehaviour
{
    public int playerScore;
    public int playerRecordScore;
    public Text playerScoreText;
    public Text playerRecordScoreText;
    public GameObject gameOverScreen;
    public EventManager eventManager;

    private const string playerRecordScorePropertyName = "playerHighScore";

    private void Start()
    {
        UpdatePlayerRecordScore(PlayerPrefs.GetInt(playerRecordScorePropertyName));
    }

    [ContextMenu("Increase Score")]
    public void AddScore(int scoreToAdd = 1)
    {
        playerScore += scoreToAdd;
        playerScoreText.text = playerScore.ToString();
        eventManager.EmitScoreUpEvent();
        EvaluateHighScore();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    private void EvaluateHighScore()
    {
        if (playerScore > playerRecordScore)
        {
            UpdatePlayerRecordScore(playerScore);
        }
    }

    private void UpdatePlayerRecordScore(int newScore)
    {
        playerRecordScore = newScore;
        PlayerPrefs.SetInt(playerRecordScorePropertyName, newScore);
        playerRecordScoreText.text = $"HS: {newScore}";
    }
}
