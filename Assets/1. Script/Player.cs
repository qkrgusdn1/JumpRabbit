using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float currentJumpPower;
    public float maxJumpPower;
    Rigidbody2D rb;
    public GameObject body;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public bool isGrounded;
    Animator animator;
    PlatformPrefab landedPlatforms;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    public void Init()
    {

    }
    public void Jump()
    {
        if (rb != null && isGrounded)
        {
            animator.SetInteger("StateID", 2);
            animator.Play("Jump");
            rb.AddForce(Vector3.one * currentJumpPower);
            currentJumpPower = 0;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(isGrounded)
                animator.SetInteger("StateID", 1);
        }
        else if(Input.GetKey(KeyCode.Space))
        {
            animator.Play("JumpReady");
            if(currentJumpPower <= maxJumpPower)
            {
                currentJumpPower += DataBaseManager.Instance.jumpPowerIncrease;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Jump();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((groundLayer & (1 << collision.gameObject.layer)) != 0)
        {
            isGrounded = true;
            animator.SetInteger("StateID", 0);
            rb.velocity = Vector2.zero;

            CameraManager.Instance.OnFollow(transform.position);

            if(collision.transform.parent.TryGetComponent(out PlatformPrefab platform))
            {
                platform.OnLoding();

                if(landedPlatforms != platform)
                {
                    ScoreManager.Instance.AddBonus(DataBaseManager.Instance.BonusValue, transform.position);
                }
                else
                {
                    ScoreManager.Instance.ResetBonus();
                }
            }

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if ((groundLayer & (1 << collision.gameObject.layer)) != 0)
        {
            isGrounded = false;
        }
    }



}
