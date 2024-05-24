using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move2D1 : MonoBehaviour
{
    public bool isGrounded;
    public bool isJumping;
    public float moveSpeed = 5f;
    public float jumpHeight = 10f;
    public int jumps = 0;
    public int maxJumps = 2;
    public bool ExtraJump;

    private bool facingRight;


    public int health = 100;

    private GameMaster gm;

    public Transform BossPoint;

    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        transform.position = gm.lastCheckPoint;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        FlipChar(horizontal);
        
    }
    void Update()
    {
        if (isGrounded)
        {
            jumps = 0;

        }
        if (Input.GetButtonDown("Jump") && (jumps < maxJumps))
        {
            Jump();
            jumps = maxJumps;
        }
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 dir = new Vector2(x, y);
        Walk(dir);
        
    }

    private void Walk(Vector2 dir)
    {
        rb.velocity = (new Vector2(dir.x * moveSpeed, rb.velocity.y));
    }

    void Jump()
    {
        rb.velocity += Vector2.up * jumpHeight;
        jumps = jumps + 1;
    }

    

    
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.tag == "ExtraJump")
        {
            jumps = 0;
            Destroy(other.gameObject);
            DontDestroyOnLoad(other.gameObject);
        }
    }


    private void FlipChar(float horizontal)
    {
        if(horizontal > 0 && facingRight || horizontal < 0 && !facingRight)
        {
            facingRight = !facingRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("spikes"))
        {
            Die();
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.LogError("You are dead");
    }

    
}

