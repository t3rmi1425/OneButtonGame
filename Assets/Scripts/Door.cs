using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OneButtonGame.player;

public class Door : MonoBehaviour
{
    private PlayerController player;
    [SerializeField]
    private int coins;
    [SerializeField]
    private int unlockCost = 3;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        OpenDoor();
    }

    private void OpenDoor()
    {
        coins = player.CoinAmount;
        
        if (coins >= unlockCost)
        {
            this.gameObject.SetActive(false);
        }
    }
}
