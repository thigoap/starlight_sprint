using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitController : MonoBehaviour
{
    // https://www.youtube.com/watch?v=XhwRYNie-aI
    // https://www.youtube.com/watch?v=8QPmhDYn6rk&t=664s

    Rigidbody2D rb;
    SpriteRenderer sr;
    int jumpForce = 20;
    float slideTime = 0.4f;
    float slideTimeCounter;
    
    public Animator animator;
    public Transform groundCheck;
    public GameObject lifePosition;
    public LayerMask groundLayer;
    
    public bool canSlide = true;
    public static bool isDead;
    public bool isGrounded;
    public bool isSliding;

    public GameObject skinPosition;

    // Double Jump
    bool doubleJump;

    // Coyote Time
    float hangTime = 0.03f;
    float hangTimeCounter;

    // Jump Buffer
    // float jumpBufferLength = 0.01f;
    // public float jumpBufferCounter;
    
    string skinName;
    SkinController skinController;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        skinName = PlayerPrefs.GetString("selectedSkin");
        skinController = GameObject.Find("Player " + skinName + "(Clone)").GetComponent<SkinController>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.8f, 0.1f), CapsuleDirection2D.Horizontal, 0, groundLayer);
        
        if (isGrounded)
            canSlide = true;

        animator.SetBool("isJumping", !isGrounded);
        animator.SetFloat("yVelocity", rb.velocity.y);
        animator.SetBool("isSliding", isSliding);  

        // Debug.Log(transform.position);
        // Debug.Log("skin" + skinController.transform.position);
        if (skinController.transform.position.y != transform.position.y)
            transform.position = skinController.transform.position;
        
    }

    void FixedUpdate()
    {
        /* coyote time */
        if (isGrounded)
        {
            hangTimeCounter = hangTime;
        } else {
            hangTimeCounter -= Time.fixedDeltaTime;
        }

        /* jump buffer */
        // if (isJumping)
        // {
        //     jumpBufferCounter = jumpBufferLength;
        // } else if (jumpBufferCounter > 0f) {
        //     jumpBufferCounter -= Time.fixedDeltaTime;
        // } else {
        //     jumpBufferCounter = -1f;
        // }     

        /* slide */
        if (isSliding)
        {
            slideTimeCounter -= Time.fixedDeltaTime;
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(0, 0);
            canSlide = false;
        }

    }

    public void Jump()
    {
        ResetSlide();    
        if (hangTimeCounter > 0f) /* coyote time */
        // if (jumpBufferCounter >= 0f || hangTimeCounter >= 0f) /* jump buffer + coyote time */
        {
            rb.velocity = new Vector2(0, jumpForce);
            /* double jump */
            doubleJump = true;

            /* counter to avoid a second jump due to coyote time */
            hangTimeCounter = 0f;

            /* counter to avoid a second jump due to jump buffer */
            // jumpBufferCounter = 0f;

        } else if (doubleJump)
        {
            rb.velocity = new Vector2(0, jumpForce);
            doubleJump = false;       
        }
    }

    public void ReleaseJump()
    {
        if (rb.velocity.y > 0)
            rb.velocity = new Vector2(0, rb.velocity.y * 0.6f);
    }

    public void Slide()
    {
        if (!isSliding && canSlide)
        {
            isSliding = true;
        }
    }

    public void ResetSlide()
    {
        isSliding = false;
        rb.gravityScale = 7f;
        slideTimeCounter = slideTime;
    }

    

    public IEnumerator DamagePlayer()
    {
        CameraShake.Instance.StartShaking();
        sr.color = new Color(1f, 0, 0, 1f);
        yield return new WaitForSeconds(0.2f);
        sr.color = new Color(1f, 1f, 1f, 1f);

        for (int i=0; i < 3; i++)
        {
            sr.enabled = false;
            yield return new WaitForSeconds(0.15f);
            sr.enabled = true;
            yield return new WaitForSeconds(0.15f);
        }
        if (PlayerHealth.life == 0)
        {
            sr.enabled = false;
            HideLife();
        }
    }

    public IEnumerator RecoverKit()
    {
        lifePosition.SetActive(false);
        for (int i=0; i < 3; i++)
        {
            sr.enabled = false;
            yield return new WaitForSeconds(0.15f);
            sr.enabled = true;
            yield return new WaitForSeconds(0.15f);
        }   
    }

    public void ShowLife()
    {
        lifePosition.SetActive(true);
    }
    public void HideLife()
    {
        lifePosition.SetActive(false);
    }
    

}
