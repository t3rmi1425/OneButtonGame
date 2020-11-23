using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int coinCost = 1;

    /// <summary>
    /// Destroys coin
    /// </summary>
    public void DestroyCoin()
    {
        Destroy(this.gameObject);
    }
}
