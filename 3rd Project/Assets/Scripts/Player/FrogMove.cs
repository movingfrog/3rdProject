using UnityEngine;

public class FrogMove : MonoBehaviour
{
    //변수 선언
    Rigidbody2D rb;
    Animator ani;

    public static GameObject me;
    public GameObject UI;

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float maxJumpPower;
    [SerializeField]
    private float UpingJumpPower;
    [SerializeField]
    private float jumpPower;

    bool IsGround = false;
    bool isJump = false;

    private float groundChackDistance = 0.1f;
    private LayerMask groundLayer;

    //초기화
    private void Start()
    {
        maxJumpPower = 7.5f;
        ani = GetComponent<Animator>();
        me = this.gameObject;
        rb = GetComponent<Rigidbody2D>();
    }

    
    private void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            Debug.Log("adsfsfafs");
            jumpPower += UpingJumpPower * Time.deltaTime;
        }
        if(jumpPower >= maxJumpPower)
        {
            jumpPower = maxJumpPower;
        }
        //점프코드 호출
        Jump();
        if(rb.velocity.y < 0)
        {
            ani.SetTrigger("IsFalling");
        }
    }

    
    private void FixedUpdate()
    {
        float speed = moveSpeed * Time.deltaTime;

        //점프를 할 수 있게해주는 코드
        IsGround = Physics.Raycast(transform.position, Vector3.down, groundChackDistance, groundLayer);
        //점프할시에 좌우로 움직일 수 있는 코드
        if (isJump)
        {
            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                sprite.flipX = false;
                rb.AddForce(Vector2.right * speed, ForceMode2D.Impulse);    
            }
            else if(Input.GetAxisRaw("Horizontal") < 0)
            {
                sprite.flipX = true;
                rb.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
            }
        }
    }
    private void OnDestroy()
    {
        UI.SetActive(true);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //땅위에 있는지 확인해주는 코드
        switch (collision.gameObject.tag)
        {
            case "ground":
            case "FakeGround":
                isJump = false;
                jumpPower = 0;
                ani.SetBool("IsJumping", false);
                ani.SetBool("IsFalling", false);
                break;
            case "Enemy":
                ani.SetTrigger("IsDamaged");
                Destroy(gameObject, 3f);
                break;
        }
    }
    public void Jump()
    {
        //점프 코드
        if (Input.GetKeyUp(KeyCode.Space) && !IsGround && !isJump&&jumpPower >= 1.5f)
        {
            ani.SetBool("IsJumping", true);
            Debug.Log("aaffas");
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isJump = true;
        }
    }
}
