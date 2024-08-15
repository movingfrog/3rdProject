using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigMove : MonoBehaviour
{
    Rigidbody2D rb;
    public static Animator ani;
    [SerializeField]
    private float minSpeed;
    public static float maxSpeed;
    public static int flipX = 1;

    private void Start()
    {
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall")||collision.gameObject.CompareTag("Enemy"))
        {
            flipX *= -1;
        }
    }
    private void FixedUpdate()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if(flipX >= 0) 
        {
            sprite.flipX = true;
        }
        else if(flipX < 0)
        {
            sprite.flipX = false;
        }
        rb.AddForce(Vector2.right * flipX * (minSpeed + maxSpeed) * Time.deltaTime, ForceMode2D.Impulse);
    }
}
