using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : MonoBehaviour
{
    public Animator animator;
    public ParticleSystem ps;
    private string currentState;
    public int hp;
    private float DestroyTime;
    public Transform playerTransform;
    public float speed;
    public float DFrame;
    public Transform BossTransform;
    public Rigidbody2D rb2d;
    public bool IsRight = false;
    [HideInInspector]
    public bool bossKilled = false;
    // Start is called before the first frame update
    void Start()
    {
        DFrame = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.x < this.transform.position.x && IsRight) {
            Flip();
        }
        if (playerTransform.position.x > this.transform.position.x && !IsRight) {
            Flip();
        }
        if (hp == 0) {
            speed = 0;
            DestroyTime = Time.time;
            hp -= 1;
            ps.Play();
        }
        if (hp == -1 && Time.time - DestroyTime >= 2) {
            Destroy(this.gameObject);
            bossKilled = true;
        }
        if (hp != 0) {
            BossIa();
        }
    }
    // AI for the boss
    void BossIa()
    {
        if (playerTransform.position.x >= 75) {
            BossTransform.position = Vector2.MoveTowards(BossTransform.position, playerTransform.position, speed * Time.deltaTime);
        }
    }

    void ChangeAnimationState(string newState)
    {
        if (currentState == newState)
            return;

        currentState = newState;
        animator.Play(newState);
        ps.Play();
    }

    private void Flip()
    {
        IsRight = !IsRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    // Manage damages
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Bullet" && hp > 0 && Time.time - DFrame >= 1) {
            hp -= 1;
            DFrame = Time.time;
        }
        if (hp == 1) {
            speed = 1f;
            BossTransform.position = new Vector2(BossTransform.position.x, 0);
            //Physics.IgnoreCollisions = false;
            //rb2d.isKinematic = false;
            ChangeAnimationState("KingIdle");
        }
        if (hp == 4) {
            speed = 2.5f;
            //Physics.IgnoreCollisions = true;
            //rb2d.isKinematic = true;
            ChangeAnimationState("QueenIdle");
        }
        if (hp == 8) {
            speed = 1.5f;
            ChangeAnimationState("RookIdle");
        }
        if (hp == 12) {
            speed = 1f;
            ChangeAnimationState("KnightIdle");
        }
    }
}
