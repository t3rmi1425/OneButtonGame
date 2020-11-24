using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using OneButtonGame.player;

public class GameManager : MonoBehaviour
{
    #region Variables
    [SerializeField, Header("Text")]
    private Text coins;
    [SerializeField]
    private Text coinsDeath, coinsDisplay;
    [SerializeField]
    private Text jumps;
    [SerializeField]
    private Text jumpsDeath;  
    [SerializeField, Space]
    public PlayerController player;

    [SerializeField, Header("Menus")]
    private GameObject winMenu;
    [SerializeField]
    private GameObject deathMenu;
    #endregion


    private void Start()
    {
        player = FindObjectOfType<PlayerController>(); 
        DisableMenusAtStart();
    }

    private void Update()
    {
        DisplayEndGameStats();
        
    }

    #region General Game Methods
    #region Menu Management
    /// <summary>
    /// makes sure the menus are disabled on start
    /// </summary>
    private void DisableMenusAtStart()
    {
        winMenu.SetActive(false);
        deathMenu.SetActive(false);
    }

    /// <summary>
    /// Called when the player reaches the goal to activate the Win menu and pause the game
    /// </summary>
    public void WinMenu()
    {
        winMenu.SetActive(true);
        player.isPlaying = false;
        Time.timeScale = 0;
    }

    /// <summary>
    /// Called when the player dies to activate the death menu and pause the game
    /// </summary>
    public void DeathMenu()
    {
        deathMenu.SetActive(true);
        player.isPlaying = false;
        Time.timeScale = 0;
    }

    #endregion

    #endregion

    /// <summary>
    /// Displays the stats at end of game
    /// </summary>
    public void DisplayEndGameStats()
    {
        coins.text = string.Format("You collected {0} coins!", player.CoinAmount);
        jumps.text = string.Format("You jumped {0} times!", player.JumpAmount);
        coinsDeath.text = string.Format("You collected {0}", player.CoinAmount, "!");
        jumpsDeath.text = string.Format("You jumped {0}", player.JumpAmount, "!");

        coinsDisplay.text = string.Format("{0}", player.coinAmount);
    }
}
