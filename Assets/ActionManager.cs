using UnityEngine;
using UnityEngine.SceneManagement;

public class ActionManager : MonoBehaviour
{
    public void QuitApplication()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(Scenes.Game.ToString(), LoadSceneMode.Single);
    }
}
