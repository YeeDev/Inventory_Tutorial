using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Player_Controller : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0;

    bool hHold;
    bool vHold;
    bool hPressLast;
    bool facingLeft;
    Vector2 moveDirection;
    Animator anm;
    Rigidbody2D rg2D;

    //Set your variables during Awake to avoid "racing" issues.
    private void Awake()
    {
        rg2D = GetComponent<Rigidbody2D>();
        anm = GetComponent<Animator>();
    }

    private void Update()
    {
        CheckButtonPressedLast();
        SetMoveDirection();
        WalkAnimation();
        CheckIfFlipSprite();
    }

    //FixedUpdate uses a different counter from Update.
    //It is a fixed counter and is used for physics calculations.
    //Great for moving objects but not for reading input.
    //You don't need to use deltaTime, it is frame independent.
    private void FixedUpdate()
    {
        rg2D.velocity = moveDirection * moveSpeed;
    }

    //This method creates a simulated D-Pad style movement.
    //Allowing two keys to be pressed at a time.
    //There's no "stuck" movement that might be a little uncomfortable for some.
    //If you are curious about this, check the "Stuck Control" scene and compare with this.
    private void CheckButtonPressedLast()
    {
        hHold = Input.GetButton("Horizontal");
        vHold = Input.GetButton("Vertical");

        if (hHold && !vHold || vHold && Input.GetButtonDown("Horizontal")) { hPressLast = true; }
        if (vHold && !hHold || hHold && Input.GetButtonDown("Vertical")) { hPressLast = false; }
    }

    private void SetMoveDirection()
    {
        moveDirection.x = hPressLast ? Input.GetAxisRaw("Horizontal") : 0;
        moveDirection.y = !hPressLast ? Input.GetAxisRaw("Vertical") : 0;
    }

    private void WalkAnimation()
    {
        LockAnimationAxis();

        //A simple way to check if something is moving.
        //Square magnitude uses math to get a vector's squared length.
        //If all values of a vector are 0, then it will return 0.
        //Since it's a squared operation it will always return a positive value.
        //Don't use the magnitude method it uses way too many resources...
        anm.SetBool("Walking", moveDirection.sqrMagnitude > 0);
    }

    //Combined with Blend Trees...
    //This systems creates a simple top down view style animation.
    private void LockAnimationAxis()
    {
        if (moveDirection.x != 0)
        {
            anm.SetFloat("H Axis", 1);
            anm.SetFloat("V Axis", 0);
        }
        if (moveDirection.y != 0)
        {
            anm.SetFloat("V Axis", moveDirection.y);
            anm.SetFloat("H Axis", 0);
        }
    }

    //If not checking the movedirection Y axis...
    //The sprite will flip weirdly when moving in the vertical axis.
    private void CheckIfFlipSprite()
    {
        if (facingLeft && (moveDirection.x > 0 || moveDirection.y != 0))
        {
            FlipSprite();
        }
        else if (!facingLeft && moveDirection.x < 0)
        {
            FlipSprite();
        }
    }

    private void FlipSprite()
    {
        facingLeft = !facingLeft;
        Vector2 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}
