using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyMove : MonoBehaviour
{
    public static BunnyMove Instance;
    Rigidbody2D rb;
    [SerializeField]
    private float speedPower;
    [SerializeField]
    private float jumpPower;

    public static bool IsPlayer;
    bool IsGround;

    private void Start()
    {
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
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("wall"))
        {
            BunnyChack.Spawn = true;
            gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if(IsPlayer)
        {
            //�÷��̾ ���� ������ �̵�
            rb.AddForce(Vector2.right * BunnyChack.f * speedPower * Time.deltaTime, ForceMode2D.Impulse);
            //�ٴڿ� ����� ������ ����
            if(IsGround)
            {
                rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                IsGround = false;
            }
        }
    }
}
