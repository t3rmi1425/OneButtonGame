using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OneButtonGame.player
{
    public class PlayerStats : MonoBehaviour
    {
        #region Properties
        public int CoinAmount  {  get => coinAmount; }
        public int JumpAmount  {  get => jumpAmount; }
        #endregion

        [SerializeField, Header("Inventory Stats")]
        private int coinAmount;
        [SerializeField]
        private int jumpAmount;

        #region Methods
        /// <summary>
        /// Adds coin to the player stats
        /// </summary>
        /// <param name="_addCoin">the amount of coin to add</param>
        public void CollectCoin(int _addCoin)
        {
            coinAmount += _addCoin;
        }  

        /// <summary>
        /// counts the amount of jumps made
        /// </summary>
        public void AmountOfJumpsMade(int _jumpAmount)
        {
            jumpAmount += _jumpAmount;    
        }
        #endregion
    }
}
