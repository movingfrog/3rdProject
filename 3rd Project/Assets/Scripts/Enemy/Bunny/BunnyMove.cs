using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyMove : MonoBehaviour
{
    public static BunnyMove Instance;
    Rigidbody2D rb;
    public Animator ani;
    Vector3 vec;
    [SerializeField]
    private float speedPower;
    [SerializeField]
    private float jumpPower;

    public static bool IsPlayer;
    bool IsGround;

    private void Start()
    {
        vec = transform.position;
        ani = GetComponent<Animator>();
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            IsGround = true;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            ani.SetTrigger("IsDie");
            Destroy(gameObject, 2f);
        }
        else if (collision.gameObject.CompareTag("wall"))
        {
            ani.SetTrigger("IsDie");
            Invoke("False", 1f);
            Invoke("respown", 3f);
        }
    }

    public void False()
    {
        gameObject.SetActive(false);
    }
    public void respown()
    {
        BunnyChack.Spawn = true;
        transform.position = vec;
    }

    private void FixedUpdate()
    {
        if(IsPlayer)
        {
            //플레이어가 닿은 쪽으로 이동
            rb.AddForce(Vector2.right * BunnyChack.f * speedPower * Time.deltaTime, ForceMode2D.Impulse);
            //바닥에 닿았을 때에만 점프
            if(IsGround)
            {
                rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                IsGround = false;
            }
        }
    }
}
