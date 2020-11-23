using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    [SerializeField]
    private GameObject[] level;
    private int index;
    public int levelNumber = 1;

    [SerializeField]
    private Text displaylevel;
    [SerializeField]
    public GameObject destroy;
    [SerializeField]
    private GameObject winMenu;

    private void Start()
    {
        index = 0;
        levelNumber = 1;
    }

    private void Update()
    {
        DisplayLevel();
    }

    public void SpawnNextLevel()
    {
        if (levelNumber < 6)
        {
            Destroy(destroy);
            Instantiate(level[index], transform.position, Quaternion.identity);   
         
            destroy = FindObjectOfType<AssignLevel>().gameObject;
            index++;
            levelNumber++;

            Time.timeScale = 1f;
            winMenu.SetActive(false);
        } 
        
        
    }

    private void DisplayLevel()
    {
        displaylevel.text = string.Format("level: {0} / 6", levelNumber);
    }
}
