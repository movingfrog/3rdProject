using UnityEngine;
using UnityEngine.SceneManagement;

public class PlyaerMove : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rb;
    Animator ani;
    private bool IsChange = false;
    void Start()
    {
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& !IsChange)
        {
            IsChange = true;
            rb.gravityScale *= -1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            IsChange = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DieZone"))
        {
            SceneManager.LoadScene("SecondWorld");
        }
    }

    void Move()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        float h = Input.GetAxisRaw("Horizontal");

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            if(h >= 0)
            {
                sprite.flipX = false;
            }
            else
                sprite.flipX = true;
            ani.SetBool("IsMove", true);
            //rb.MovePosition(transform.position + new Vector3(h*moveSpeed * Time.deltaTime, 0, 0));
            rb.AddForce(new Vector2(h * moveSpeed * Time.deltaTime, 0), ForceMode2D.Impulse);
        }
        else
        {
            ani.SetBool("IsMove", false);
        }
    }
}
