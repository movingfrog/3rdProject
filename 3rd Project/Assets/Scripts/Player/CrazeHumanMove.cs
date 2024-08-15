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
    private int FlipY;

    public GameObject UI;

    bool IsGround = false;
    bool isJump = false;

    private float groundChackDistance = 0.1f;
    private LayerMask groundLayer;

    //�ʱ�ȭ
    private void Start()
    {
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        FlipY = 1;
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
        //���� �ڵ�
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
