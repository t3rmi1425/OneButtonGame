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
        private string text;
        public bool debug = false;

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
            AnimatePlayer();
        }
        #endregion

        #region PlayerControls
        private void AnimatePlayer()
        {
            float heading = Mathf.Atan2(rb2d.velocity.x, rb2d.velocity.y) * Mathf.Rad2Deg; // gets the heading of the character
            Quaternion rotation = Quaternion.Euler(0, 0, -heading); // sets the rotation towards the heading
            
            if (rb2d.velocity.magnitude > 6f)
            {
                // rotates the character if it has moved
                transform.rotation = rotation; 
                // gets the scale of the character
                Vector3 scale = gameObject.transform.localScale;
                // sets the scale based off the magnitude of the characters velocity 
                scale.y = Mathf.Lerp(scale.y, Mathf.Clamp(rb2d.velocity.magnitude * 0.1f, 1f, 2f), 20 * Time.deltaTime);
                // sets the characters scale
                gameObject.transform.localScale = scale;
            }
            else 
            { 
                gameObject.transform.localScale = Vector3.one; // resets the scale when the character isnt moving  
                transform.rotation = Quaternion.Euler(0, 0, 0); // else reset to 0
            } 
            
            text = string.Format("Heading: {0}\nRotation: {1}\nMagneto: {2}\nVelocity: {3}", heading, rotation, rb2d.velocity.magnitude, rb2d.velocity);
        }
        
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
            }
            else if (isRight)
            {
                // flips the player to move Right
                currentSpeed = speed;
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

        private void OnGUI()
        {
            if (debug)
            {
                GUI.Box(new Rect(500, 250, 150, 100), text);
                Debug.Log(text);
            }
        }
    }
}

