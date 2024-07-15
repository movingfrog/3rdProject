using UnityEngine;

public class CrazeHumanMove : MonoBehaviour
{
    //변수 선언
    Rigidbody2D rb;

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpPower;

    bool IsGround = false;
    bool isJump = false;

    private float groundChackDistance = 0.1f;
    private LayerMask groundLayer;

    //초기화
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        //점프코드 호출
        Jump();
    }


    private void FixedUpdate()
    {
        float speed = moveSpeed * Time.deltaTime;

        //점프를 할 수 있게해주는 코드
        IsGround = Physics.Raycast(transform.position, Vector3.down, groundChackDistance, groundLayer);
        //점프할시에 좌우로 움직일 수 있는 코드
        
            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            if (Input.GetKey(KeyCode.RightShift))
            {
                sprite.flipX = false;
                rb.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
            }
            else if (Input.GetKey(KeyCode.LeftShift))
            {
                sprite.flipX = true;
                rb.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
            }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //땅위에 있는지 확인해주는 코드
        switch (collision.gameObject.tag)
        {
            case "ground":
                isJump = false;
                break;
        }
    }
    public void Jump()
    {
        //점프 코드
        if ((Input.GetKeyDown(KeyCode.LeftAlt)||Input.GetKeyDown(KeyCode.RightAlt)) && !IsGround && !isJump)
        {
            Debug.Log("aaffas");
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isJump = true;
        }
    }
}
