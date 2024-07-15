using UnityEngine;

public class CrazeHumanMove : MonoBehaviour
{
    //���� ����
    Rigidbody2D rb;

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
        //������ �ִ��� Ȯ�����ִ� �ڵ�
        switch (collision.gameObject.tag)
        {
            case "ground":
                isJump = false;
                break;
        }
    }
    public void Jump()
    {
        //���� �ڵ�
        if ((Input.GetKeyDown(KeyCode.LeftAlt)||Input.GetKeyDown(KeyCode.RightAlt)) && !IsGround && !isJump)
        {
            Debug.Log("aaffas");
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isJump = true;
        }
    }
}
