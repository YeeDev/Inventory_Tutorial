using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Stuck_Controller : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0;

    bool facingLeft;
    Vector2 moveDirection;
    Animator anm;
    Rigidbody2D rg2D;

    private void Awake()
    {
        rg2D = GetComponent<Rigidbody2D>();
        anm = GetComponent<Animator>();
    }

    private void Update()
    {
        SetDirection();
        WalkAnimation();
        CheckIfFlipSprite();
    }

    //This makes the movement far less fluid.
    //You can make this a little longer to prevent one side for feeling that way.
    //But to create a completely fluid control you'll require another solution.
    private void SetDirection()
    {
        moveDirection.x = Input.GetButton("Horizontal") && !Input.GetButton("Vertical") ? Input.GetAxisRaw("Horizontal") : 0 ;
        moveDirection.y = !Input.GetButton("Horizontal") && Input.GetButton("Vertical") ? Input.GetAxisRaw("Vertical") : 0;
    }

    private void FixedUpdate()
    {
        rg2D.velocity = moveDirection * moveSpeed;
    }

    private void WalkAnimation()
    {
        LockAnimationAxis();

        anm.SetBool("Walking", moveDirection.sqrMagnitude > 0);
    }

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
