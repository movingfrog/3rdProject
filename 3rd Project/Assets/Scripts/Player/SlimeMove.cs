using UnityEngine;
using UnityEngine.UIElements;

public class PlyaerMove : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rb;
    Animator ani;
    void Start()
    {
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
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
