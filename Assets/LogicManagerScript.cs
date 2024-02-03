using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LogicManagerScript : MonoBehaviour
{
    public int playerScore;
    public int playerRecordScore;
    public Text playerScoreText;
    public Text playerRecordScoreText;
    public GameObject gameOverScreen;
    public GameObject soundManager;

    private SoundManagerScript soundManagerScript;

    private void Start()
    {
        soundManagerScript = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManagerScript>();
        UpdatePlayerRecordScore(PlayerPrefs.GetInt("playerHighScore"));
    }

    [ContextMenu("Increase Score")]
    public void AddScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        playerScoreText.text = playerScore.ToString();
        soundManagerScript.PlaySound(SoundType.Score);
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
        PlayerPrefs.SetInt("playerHighScore", newScore);
        playerRecordScoreText.text = $"HS: {newScore}";
    }
}
