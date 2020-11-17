using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    #region Variables
    public int moneyReward = 0;
    [SerializeField]
    private int rewardAmount = 1;
    public Coins coin;
    public int jumpCount;


    [SerializeField, Tooltip("Controls how high the player can jump")]
    private float jumpHeight;
    [SerializeField, Tooltip("Controls how much the character goes foward while jumping")]
    public float forwardPush;
    public float currentForwardPush;
    [SerializeField]
    private Rigidbody2D rb2d;
    [SerializeField]
    LayerMask wall;


    public SpriteRenderer player;
    public GameManager gm;


    public bool isLeft;
    public bool isRight;
    #endregion

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        gm = FindObjectOfType<GameManager>();
        currentForwardPush = forwardPush;
    }

    private void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.velocity = new Vector2(currentForwardPush, jumpHeight);
            jumpCount ++;
        }
        if (isLeft)
        {
            currentForwardPush = -forwardPush;

            player.flipX = true;
        }
        else if (isRight)
        {
            currentForwardPush = forwardPush;

            player.flipX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("I hit" + other.name);
        if (other.gameObject.CompareTag("Wall"))
        {
            print("I hit" + other.name);

            gm.PlayerDeath();
        }

        if (other.gameObject.CompareTag("Coins"))
        {
            coin = other.gameObject.GetComponent<Coins>();
            coin.AddMoneyToPlayer(rewardAmount);
            coin.DestroyCoin();
        }

        if (other.gameObject.CompareTag("Goal"))
        {
            gm.PlayerWin();
        }
    }
}
