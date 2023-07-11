using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinController : MonoBehaviour
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
    public LayerMask groundLayer;
    
    public Transform dustPosition;
    public Transform diamondPosition;
    
    public bool canSlide = true;
    public static bool isDead;
    public bool isGrounded;
    public bool isSliding;

    // Double Jump
    bool doubleJump;

    // Coyote Time
    float hangTime = 0.03f;
    float hangTimeCounter;

    // Jump Buffer
    // float jumpBufferLength = 0.01f;
    // public float jumpBufferCounter;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update() {
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.8f, 0.1f), CapsuleDirection2D.Horizontal, 0, groundLayer);
        
        if (isGrounded)
            canSlide = true;

        animator.SetBool("isJumping", !isGrounded);
        animator.SetFloat("yVelocity", rb.velocity.y);
        animator.SetBool("isSliding", isSliding);    
    }

    void FixedUpdate() {
        /* coyote time */
        if (isGrounded) {
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
        if (isSliding) {
            slideTimeCounter -= Time.fixedDeltaTime;
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(0, 0);
            canSlide = false;
        }

    }

    public void Jump() {
        ResetSlide();    
        if (hangTimeCounter > 0f) { /* coyote time */
        // if (jumpBufferCounter >= 0f || hangTimeCounter >= 0f) /* jump buffer + coyote time */
            AudioManager.Instance.PlayJumpSFX();
            rb.velocity = new Vector2(0, jumpForce);
            /* double jump */
            doubleJump = true;

            /* counter to avoid a second jump due to coyote time */
            hangTimeCounter = 0f;

            /* counter to avoid a second jump due to jump buffer */
            // jumpBufferCounter = 0f;

        } else if (doubleJump) {
            AudioManager.Instance.PlayJumpSFX();
            rb.velocity = new Vector2(0, jumpForce);
            doubleJump = false;       
        }
    }

    public void ReleaseJump() {
        if (rb.velocity.y > 0)
            rb.velocity = new Vector2(0, rb.velocity.y * 0.6f);
    }

    public void Slide() {
        if (!isSliding && canSlide) {
            AudioManager.Instance.PlaySlideSFX();
            GameManager.Instance.velocity = GameManager.Instance.slideVelocity;
            isSliding = true;
            
            GameObject dust = DustPool.instance.GetPooledOject();
            if (isGrounded) {
                dust.transform.position = dustPosition.position;
                dust.SetActive(true);
            }
        }
    }

    public void ResetSlide() {
        DustPool.instance.StopDustEffect();
        isSliding = false;
        rb.gravityScale = 7f;
        GameManager.Instance.velocity = GameManager.Instance.baseVelocity;
        slideTimeCounter = slideTime;
    }

    public IEnumerator DamagePlayer() {
        // CameraShake.Instance.StartShaking();
        sr.color = new Color(1f, 0, 0, 1f);
        yield return new WaitForSeconds(0.2f);
        sr.color = new Color(1f, 1f, 1f, 1f);

        for (int i=0; i < 3; i++) {
            sr.enabled = false;
            yield return new WaitForSeconds(0.15f);
            sr.enabled = true;
            yield return new WaitForSeconds(0.15f);
        }
    }

    public void GainDiamond() {
        // Debug.Log("Gain Diamond");
        GameObject diamond = DiamondPool.instance.GetPooledOject();
        diamond.transform.position = diamondPosition.position;
        diamond.SetActive(true);
        StartCoroutine(StopDiamondEffect());
    }

    public IEnumerator StopDiamondEffect() {
        yield return new WaitForSeconds(1.0f);
        DiamondPool.instance.StopDiamondEffect(); 
        }  

}

