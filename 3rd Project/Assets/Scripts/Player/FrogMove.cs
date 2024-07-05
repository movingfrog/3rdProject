using UnityEngine;

public class FrogMove : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpPower;
    bool IsGround = false;
    private float groundChackDistance = 0.1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }
    private void FixedUpdate()
    {
        RaycastHit2D rayhit = Physics2D.Raycast(transform.position, Vector3.down, groundChackDistance);
        IsGround = rayhit.collider.gameObject.CompareTag("ground");
    }

    public void Move()
    {
        float speed = moveSpeed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && IsGround)
        {
            rb.velocity = Vector3.zero;
            Debug.Log("aaffas");
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
        if (!IsGround)
        {
            if(Input.GetAxisRaw("Horizontal") > 0)
            {
                rb.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
            }
        }
    }
}
