using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyMove : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    private float speedPower;
    [SerializeField]
    private float jumpPower;

    bool IsPlayer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if(IsPlayer)
        {
            rb.AddForce(Vector2.right * speedPower * Time.deltaTime, ForceMode2D.Impulse);
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }
}
