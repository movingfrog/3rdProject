using System.Collections;
using UnityEngine;

public class IndianMove : MonoBehaviour
{
    public GameObject IsStay;
    Rigidbody2D rb;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float jumpPower;

    bool IsGround = false;
    bool IsJump = false;

    private float groundChackDistance = 0.1f;
    private LayerMask groundLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        Walk();
    }
    private void Update()
    {
        //�����ڵ� ȣ��
        Jump();
        if (IsStay.activeSelf)
        {
            if (Input.anyKey)
            {
                Debug.Log("you are die");
            }
        }
    }


    private void Stay()
    {
        Debug.Log("1");
        IsStay.SetActive(true);
        Invoke("Walk", 1.5f);
    }
    private void Walk()
    {
        Debug.Log("2");
        IsStay.SetActive(false);
        Invoke("Stay", 3.0f);
    }

    private void FixedUpdate()
    {
        float speed = maxSpeed * Time.deltaTime;

        //������ �� �� �ְ����ִ� �ڵ�
        IsGround = Physics.Raycast(transform.position, Vector3.down, groundChackDistance, groundLayer);
        //�����ҽÿ� �¿�� ������ �� �ִ� �ڵ�

        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            sprite.flipX = false;
            rb.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
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
                IsJump = false;
                break;
        }
    }
    public void Jump()
    {
        //���� �ڵ�
        if (Input.GetKeyDown(KeyCode.Space) && !IsGround && !IsJump)
        {
            Debug.Log("aaffas");
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            IsJump = true;
        }
    }
}
