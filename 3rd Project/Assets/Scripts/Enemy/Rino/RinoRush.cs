using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RinoRush : MonoBehaviour
{
    private Vector3 vec;
    Rigidbody2D rb;
    Animator ani;
    [SerializeField]
    private float moveSpeed;
    public static bool OnPlayerInside = false;

    private void Awake()
    {
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        vec = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall")||collision.gameObject.CompareTag("FakeGround"))
        {
            ani.SetBool("IsRinoWall", true);
            OnPlayerInside = false;
            Invoke("Spawn", 3f);
        }
    }

    void Spawn()
    {
        ani.SetBool("IsRinoWall", false);
        transform.position = vec;
        gameObject.SetActive(false);
        gameObject.SetActive(true);
    }

    private void FixedUpdate()
    {
        if (OnPlayerInside)
        {
            ani.SetTrigger("IsPlayer");
            if (transform.localScale.x >= 0)
                rb.AddForce(Vector2.right * -moveSpeed * Time.deltaTime, ForceMode2D.Impulse);
            else if (transform.localScale.x < 0)
                rb.AddForce(Vector2.left * -moveSpeed * Time.deltaTime, ForceMode2D.Impulse);
        }
    }
}
