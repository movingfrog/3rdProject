using UnityEngine;

public class FrogMove : MonoBehaviour
{
    //���� ����
    Rigidbody2D rb;
    Animator ani;

    public static GameObject me;

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
        me = this.gameObject;
        rb = GetComponent<Rigidbody2D>();
    }

    
    private void Update()
    {
        //�����ڵ� ȣ��
        Jump();
        if(rb.velocity.y < 0)
        {
            ani.SetTrigger("IsFalling");
        }
    }

    
    private void FixedUpdate()
    {
        float speed = moveSpeed * Time.deltaTime;

        //������ �� �� �ְ����ִ� �ڵ�
        IsGround = Physics.Raycast(transform.position, Vector3.down, groundChackDistance, groundLayer);
        //�����ҽÿ� �¿�� ������ �� �ִ� �ڵ�
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //������ �ִ��� Ȯ�����ִ� �ڵ�
        switch (collision.gameObject.tag)
        {
            case "ground":
            case "wall":
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
        if (Input.GetKeyDown(KeyCode.Space) && !IsGround && !isJump)
        {
            ani.SetBool("IsJumping", true);
            Debug.Log("aaffas");
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isJump = true;
        }
    }
}
