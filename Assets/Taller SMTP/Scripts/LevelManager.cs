using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject PauseMenu;
    bool isPaused = false;
    void Start()
    {
        PauseMenu.SetActive(false);
        GameManager.CursorVisible(false);
        GameManager.GamePause(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            PauseMenuVisible(isPaused);
        }
    }

    public void PauseMenuVisible(bool state)
    {
        PauseMenu.SetActive(state);
        GameManager.GamePause(state);
        GameManager.CursorVisible(state);
    }
}