using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool IsPaused = false;
    void Start() { }
    void Update() { }
    public void LoadScene(string MyScene)
    {
        SceneManager.LoadScene(MyScene);
    }
    public static void CursorVisible(bool state)
    {
        Cursor.visible = state;
    }
    public static void GamePause(bool state)
    {
        IsPaused = state;
        if (state)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}