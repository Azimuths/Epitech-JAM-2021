using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bool isGrounded;
    Transform myTransform;
    public float speed;
    public float jump;
    public Animator animator;
    private Vector2 direction;
    public bool achievementIdle = false;
    public bool achievementHiking = false;
    private bool FacingRight;
    public short IsAttacking;
    private float delay;
    private string currentState;
    Rigidbody2D PlayerBody;
    Collider2D playerCollider;
    public Transform firePoint;
    private bool isDying;

    public bool isDead = false;
    public float playerHp = 1;

    private AchievementPlayer achievementPlayer;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();
        PlayerBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        FacingRight = true;
        IsAttacking = 0;
        ChangeAnimationState("Player_Idle");
        achievementPlayer = GetComponent<AchievementPlayer>();
    }
    // Update is called once per frame
    void Update()
    {
        if (achievementIdle != false) {
            if (isDead == false)
            {
                TakeInput();
                Direction();
            }
        }
        if (playerHp <= 0 || transform.position.y < -7)
        {
            isDead = true;
        }
        Animate();
    }

    //check for collisions on collider without "is trigger" (pawns)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerHp -= 1;
        }
    }

    //check for collisions on collider with "is trigger" (boss)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerHp -= 1;
        }
    }

    private void LateUpdate() {
        this.transform.rotation = Quaternion.identity;
    }
    void TakeInput()
    {
        direction = Vector2.zero;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true && achievementHiking != false && IsAttacking == 0)
        {
            ChangeAnimationState("Player_Jump");
            Jump();
            if (achievementPlayer && !achievementPlayer.hasJumped)
            {
                achievementPlayer.hasJumped = true;
            }
        }
        if (Input.GetKey(KeyCode.Q) && IsAttacking == 0)
        {
            direction += Vector2.left;
            if (FacingRight == true)
            {
                Flip();
            }
            achievementPlayer.stepCounter += Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D) && IsAttacking == 0)
        {
            direction += Vector2.right;
            if (FacingRight == false)
            {
                Flip();
            }
            achievementPlayer.stepCounter += Time.deltaTime;
        } else {
        }
    }

    void Direction()
    {
        myTransform.Translate(new Vector3(direction.x, direction.y, 0) * Time.deltaTime * speed);
    }
    void Jump()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        FacingRight = !FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        firePoint.Rotate(0f, 180f, 0f);
    }

    void Animate()
    {
        if (isDead == true)
        {
            if (isDying == false)
            {
                isDying = true;
                ChangeAnimationState("Player_Suicide");
                Invoke("Respawn", 10f);
            }
        }
        else
        {
            if (isGrounded == true)
            {
                if (IsAttacking == 1)
                {
                    IsAttacking = 2;
                    ChangeAnimationState("Player_Attack");
                    Invoke("StopAttacking", 0.3f);
                }
                else if (IsAttacking == 0)
                {
                    if ((Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.D)) && achievementIdle)
                    {
                        ChangeAnimationState("Player_Run");
                    }
                    else
                    {
                        ChangeAnimationState("Player_Idle");
                    }
                }
            }
            else
            {
                if (PlayerBody.velocity.y >= 0.2)
                    ChangeAnimationState("Player_Jump");
                else if (PlayerBody.velocity.y <= -0.2)
                    ChangeAnimationState("Player_Fall");
            }
        }
    }

    void StopAttacking()
    {
        IsAttacking = 0;
    }

    void ChangeAnimationState(string newState)
    {
        if (currentState == newState)
            return;

        currentState = newState;

        animator.Play(newState);
    }
    public void Respawn()
    {
        isDead = false;
        isDying = false;
        ChangeAnimationState("Player_Idle");
        transform.position = new Vector3(-7, 1, 0);
        playerHp = 1;
    }
}
