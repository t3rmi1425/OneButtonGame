using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OneButtonGame.player
{
    public class PlayerController : PlayerStats
    {
        #region Variables
        #region PlayerControls
        [Header("Player Controls")]
        [SerializeField, Tooltip("Controls how high the player can jump")]
        private float jumpHeight;
        [SerializeField, Tooltip("Controls how much the character goes foward while jumping")]
        public float speed;
        private float currentSpeed = 3.5f;
        [SerializeField]
        private Rigidbody2D rb2d;
        #endregion

        #region Misc
        [SerializeField, Header("Misc")]
        private int jumpCount = 1;
        public bool isPlaying = false;
        SoundManager soundMan;
        [SerializeField]
        LayerMask wall;
        [SerializeField]
        private SpriteRenderer player;
        #endregion

        #region Scripts
        [Header("Scripts")]
        [SerializeField]
        private Coins coin;
        [SerializeField]
        public GameManager gm;
        #endregion

        #region PlayerDirection
        [Header("PlayerDirection")]
        public bool isLeft;
        public bool isRight;
        #endregion
        #endregion

        #region Methods
        #region Start and Update
        private void Start()
        {
            #region Assigning components
            rb2d = GetComponent<Rigidbody2D>();
            gm = FindObjectOfType<GameManager>();
            gm.player = this.gameObject.GetComponent<PlayerController>();
            soundMan = FindObjectOfType<SoundManager>();
            #endregion

            currentSpeed = speed;
        }

        private void Update()
        {
            PlayerMove();
        }
        #endregion

        #region PlayerControls
        private void PlayerMove()
        {
            bool canJump = Input.GetKeyDown(KeyCode.Space) && isPlaying;
            if (canJump)
            {
                // if the player jumps they will be pushed in their current direction
                rb2d.velocity = new Vector2(currentSpeed, jumpHeight);
                // as well as have the amount of times jump is pressed displayed
                AmountOfJumpsMade(jumpCount);
            }
            if (isLeft)
            {
                // flips the player to move left
                currentSpeed = -speed;
                player.flipX = true;
            }
            else if (isRight)
            {
                // flips the player to move Right
                currentSpeed = speed;
                player.flipX = false;
            }
        }
        #endregion

        #region Collision stuff
        private void OnTriggerEnter2D(Collider2D other)
        {
            #region Spikes
            print("I hit" + other.name);
            // if the player hits a spike 
            if (other.gameObject.CompareTag("Spike"))
            {
                print("I hit" + other.name);
                //kill the player
                gm.DeathMenu();
            }
            #endregion

            #region Coin Collection
            // if the collision is with a Coin
            if (other.gameObject.CompareTag("Coins"))
            {
                // assigns the coin gameobject to the variable
                coin = other.gameObject.GetComponent<Coins>();
                // plays coin sound
                soundMan.coinEffect.Play();
                // calls method to add a coin to the stats
                CollectCoin(coin.coinCost);
                // calls method to destroy object
                coin.DestroyCoin();
            }
            #endregion

            #region Goal
            // if player hits the goal
            if (other.gameObject.CompareTag("Goal"))
            {
                // call win method
                gm.WinMenu();
            }
            #endregion
        }
        #endregion
        #endregion
    }
}

