using UnityEngine;
using UnityEngine.UI;
using OneButtonGame.player;

public class LevelSelection : MonoBehaviour
{
    [SerializeField]
    private GameObject[] level;
    private int index;
    private int restart_Index;
    public int levelNumber = 1;
    
    [SerializeField]
    private Text displaylevel;
    [SerializeField]
    public GameObject destroy;
    [SerializeField]
    private GameObject winMenu, deathMenu;

    [SerializeField]
    private GameObject[] level_restart;
    [SerializeField]
    private GameObject level_restart_destroy;

    [SerializeField]
    PlayerController player;

    private void Start()
    {
        Time.timeScale = 1f;
        index = 0;
        restart_Index = 0;
        levelNumber = 1;

        //level_restart = FindObjectOfType<AssignLevel>().gameObject;
        level_restart_destroy = FindObjectOfType<AssignLevel>().gameObject;
        player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        DisplayLevel();
    }

    /// <summary>
    /// spawns a new level in place of the old one
    /// </summary>
    public void SpawnNextLevel()
    {
        // if level is below max level number
        if (levelNumber < 6)
        {
            // destroy old level
            Destroy(destroy);
            // spawn next level
            Instantiate(level[index], transform.position, Quaternion.identity);
            
            // add to index to prime the next level
            index++;
            restart_Index++;
            // add to the level number
            levelNumber++;
            
            // set time to 1
            Time.timeScale = 1f;
            // turn off win menu
            winMenu.SetActive(false);
            
            // assign the level ready to be destroyed on completetion
            destroy = FindObjectOfType<AssignLevel>().gameObject;
            // reset the coins
            player.coinAmount = 0;
        } 
    }

    // spawns a fresh copy of the current level for the player
    public void RestartLevel()
    {
       
        //SceneManager.LoadScene("GameScene"); 
        
        
        #region Assign levels to objects
        level_restart_destroy = FindObjectOfType<AssignLevel>().gameObject;
        #endregion


        // destroy the old level
        Destroy(level_restart_destroy);
        // reset the coins
        player.coinAmount = 0;
        // set time to 1
        Time.timeScale = 1f;
        // turn off death menu
        deathMenu.SetActive(false);
        // spawn a fresh level
        Instantiate(level_restart[restart_Index], transform.position, Quaternion.identity);
        destroy = FindObjectOfType<AssignLevel>().gameObject;

    }

    private void DisplayLevel()
    {
        displaylevel.text = string.Format("level: {0} / 6", levelNumber);
    }
}
