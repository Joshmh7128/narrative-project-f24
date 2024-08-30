using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // movement input vector, and our movement vector
    [SerializeField] Vector2 input, move;
    [SerializeField] float movespeed = 5; // our movement speed
    [SerializeField] Vector2 playerSize; // the size of our player in world space
    [SerializeField] Animator playerAnimator; // the player's animator

    // runs 50 times per second
    private void FixedUpdate()
    {
        // core stack
        ProcessMovementInput();
        // check and apply movement
        ApplyMovement();
    }

    /// <summary>
    /// turns our key presses into the input vector, and the move vector
    /// </summary>
    void ProcessMovementInput()
    {
        // reset our input before we calculate it
        input = Vector2.zero;

        // turn our keys into input
        // move up
        if (Input.GetKey(KeyCode.W))
        {
            // animation for the player
            playerAnimator.Play("player-walk-up");
            input.y += 1;
        }
        // move down
        if (Input.GetKey(KeyCode.S))
            input.y -= 1;
        // move right
        if (Input.GetKey(KeyCode.D))
            input.x += 1;
        // move left
        if (Input.GetKey(KeyCode.A))
            input.x -= 1;

        // setting animations using the inputs
        if (input.y == 1) playerAnimator.Play("player-walk-up");
        else
        if (input.y == -1) playerAnimator.Play("player-walk-down");
        else
        if (input.x == 1) playerAnimator.Play("player-walk-right");
        else
        if (input.x == -1) playerAnimator.Play("player-walk-left");
        // set our idle animation
        if (input == Vector2.zero) playerAnimator.Play("player-idle");

        // normalize input before we use it
        if (input.x + input.y > 1)
            input *= 0.5f;

        // after the vector is processed, calculate our movement vector
        move = input;
        move *= movespeed;
        move *= Time.deltaTime; // will automatically use either deltaTime or fixedDeltaTime depending on where it is called

    }

    /// <summary>
    /// Checks the move vector to see if we are able to move to that position
    /// </summary> 
    bool CanMove()
    {
        // then check to see if there is anything at that point
        if (Physics2D.BoxCast(transform.position, playerSize, 0, move, move.magnitude))
        {
            return false;
        }

        return true;
    }

    /// <summary>
    /// Moves our player by the movement vector, if the space we want to go to is free
    /// </summary>
    void ApplyMovement()
    {
        // if we can move to the position of the move vector
        if (CanMove())
        {
            // apply the movement vector to our position
            transform.position += (Vector3)move;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, playerSize);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, move);
        Gizmos.DrawWireCube(transform.position + (Vector3)move, playerSize);
    }
}
