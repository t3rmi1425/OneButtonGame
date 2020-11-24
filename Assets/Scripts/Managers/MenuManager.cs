using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void _GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void _LoadGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitToDestop()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
        #endif

        Application.Quit();
    }
}
