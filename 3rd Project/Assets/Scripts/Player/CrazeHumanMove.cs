using UnityEngine;

public class CrazeHumanMove : MonoBehaviour
{
    //변수 선언
    Rigidbody2D rb;
    Animator ani;

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpPower;
    private int FlipY;

    public GameObject UI;

    bool IsGround = false;
    bool isJump = false;

    private float groundChackDistance = 0.1f;
    private LayerMask groundLayer;

    //초기화
    private void Start()
    {
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        FlipY = 1;
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
                ani.SetBool("IsRun", true);
                rb.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
            }
            else if (Input.GetKey(KeyCode.LeftShift))
            {
                sprite.flipX = true;
                ani.SetBool("IsRun", true);
                rb.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
            }
        if (rb.velocity.x == 0)
            ani.SetBool("IsRun", false);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        switch (collision.gameObject.tag)
        {
            case "BG1":
            case "BG2":
                rb.gravityScale = 1;
                FlipY = 1;
                sprite.flipY = false;
                break;
            case "BG3":
            case "BG4":
                rb.gravityScale = -1;
                FlipY = -1;
                sprite.flipY = true;
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //땅위에 있는지 확인해주는 코드
        switch (collision.gameObject.tag)
        {
            case "ground":
                isJump = false;
                ani.SetBool("IsJumping", false);
                ani.SetBool("IsFalling", false);
                break;
            case "Enemy":
                ani.SetTrigger("IsDamaged");
                Destroy(gameObject, 3f);
                break;
        }
    }
    private void OnDestroy()
    {
        UI.SetActive(true);
    }
    public void Jump()
    {
        //점프 코드
        if ((Input.GetKeyDown(KeyCode.LeftAlt)||Input.GetKeyDown(KeyCode.RightAlt)) && !IsGround && !isJump)
        {
            ani.SetBool("IsJumping", true);
            Debug.Log("aaffas");
            rb.AddForce(Vector2.up * FlipY * jumpPower, ForceMode2D.Impulse);
            isJump = true;
        }
        else if(rb.velocity.y < 0)
        {
            ani.SetBool("IsFalling", true);
        }
    }
}
