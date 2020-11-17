using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int coinAmount;
    [SerializeField]
    private int jumpAmount;

    [SerializeField]
    private Text coins, jumps, winCoins, winJump;
    [SerializeField]
    private GameObject playMenu, deathMenu, winMenu;

    PlayerController player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        Time.timeScale = 0;
        playMenu.SetActive(true);
        deathMenu.SetActive(false);
        winMenu.SetActive(false);
    }

    private void Update()
    {
        DisplayEndGameStats();
    }

    /// <summary>
    ///  starts the game when called
    /// </summary>
    public void GameHasStarted()
    {
        Time.timeScale = 1;
        playMenu.SetActive(false);
    }

    /// <summary>
    /// kills player
    /// </summary>
    public void PlayerDeath()
    {
        deathMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void PlayerWin()
    {
        winMenu.SetActive(true);
        Time.timeScale = 0;
    }

    /// <summary>
    /// Restarts Game
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        #region Exit Playmode
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        #endregion
        Application.Quit();
    }

    /// <summary>
    /// Displays the stats at end of game
    /// </summary>
    public void DisplayEndGameStats()
    {
        coinAmount = player.moneyReward;
        jumpAmount = player.jumpCount;

        coins.text = string.Format("You collected {0}", coinAmount, "!");
        jumps.text = string.Format("You jumped {0}", jumpAmount, "!");

        winCoins.text = string.Format("You collected {0}", coinAmount, "!");
        winJump.text = string.Format("You jumped {0}", jumpAmount, "!");
    }
}
