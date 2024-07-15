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
        //점프코드 호출
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

        //점프를 할 수 있게해주는 코드
        IsGround = Physics.Raycast(transform.position, Vector3.down, groundChackDistance, groundLayer);
        //점프할시에 좌우로 움직일 수 있는 코드

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
        //땅위에 있는지 확인해주는 코드
        switch (collision.gameObject.tag)
        {
            case "ground":
                IsJump = false;
                break;
        }
    }
    public void Jump()
    {
        //점프 코드
        if (Input.GetKeyDown(KeyCode.Space) && !IsGround && !IsJump)
        {
            Debug.Log("aaffas");
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            IsJump = true;
        }
    }
}
