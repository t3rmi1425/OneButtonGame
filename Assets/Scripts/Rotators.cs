using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Rotators : MonoBehaviour
{
    [SerializeField]
    private PlayerController player;
    [SerializeField]
    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            // flips player depending on the direction of the arrow
            player.isRight = !sprite.flipX;
            player.isLeft = sprite.flipX;

            //if (sprite.flipX == false)
            //{
            //    player.isRight = true;
            //    player.isLeft = false;
            //}
            //else if(sprite )
             
        }
    }
}
