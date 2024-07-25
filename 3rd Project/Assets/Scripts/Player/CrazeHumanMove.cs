using UnityEngine;

public class CrazeHumanMove : MonoBehaviour
{
    //���� ����
    Rigidbody2D rb;
    Animator ani;

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpPower;

    bool IsGround = false;
    bool isJump = false;

    private float groundChackDistance = 0.1f;
    private LayerMask groundLayer;

    //�ʱ�ȭ
    private void Start()
    {
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        //�����ڵ� ȣ��
        Jump();
    }


    private void FixedUpdate()
    {
        float speed = moveSpeed * Time.deltaTime;

        //������ �� �� �ְ����ִ� �ڵ�
        IsGround = Physics.Raycast(transform.position, Vector3.down, groundChackDistance, groundLayer);
        //�����ҽÿ� �¿�� ������ �� �ִ� �ڵ�
        
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //������ �ִ��� Ȯ�����ִ� �ڵ�
        switch (collision.gameObject.tag)
        {
            case "ground":
                isJump = false;
                ani.SetBool("IsJumping", false);
                ani.SetBool("IsFalling", false);
                break;
            case "Enemy":
                ani.SetTrigger("IsDamaged");
                break;
        }
    }
    public void Jump()
    {
        //���� �ڵ�
        if ((Input.GetKeyDown(KeyCode.LeftAlt)||Input.GetKeyDown(KeyCode.RightAlt)) && !IsGround && !isJump)
        {
            ani.SetBool("IsJumping", true);
            Debug.Log("aaffas");
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isJump = true;
        }
        else if(rb.velocity.y < 0)
        {
            ani.SetBool("IsFalling", true);
        }
    }
}
