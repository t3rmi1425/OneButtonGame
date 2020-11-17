using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    PlayerController player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();  
    }

    /// <summary>
    /// Destroys coin
    /// </summary>
    public void DestroyCoin()
    {
        Destroy(this.gameObject);
    }

    /// <summary>
    /// Adds coins to player
    /// </summary>
    /// <param name="_moneyAmt">the coin amount when coin is collected</param>
    public void AddMoneyToPlayer(int _moneyAmt)
    {
        player.moneyReward += _moneyAmt;
    }
}
