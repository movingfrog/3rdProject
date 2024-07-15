using UnityEngine;
using UnityEngine.UIElements;

public class PlyaerMove : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            //rb.MovePosition(transform.position + new Vector3(h*moveSpeed * Time.deltaTime, 0, 0));
            rb.AddForce(new Vector2(h * moveSpeed * Time.deltaTime, 0), ForceMode2D.Impulse);
        }
    }
}
