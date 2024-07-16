using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RinoRush : MonoBehaviour
{
    private Vector3 vec;
    Rigidbody2D rb;
    [SerializeField]
    private float moveSpeed;
    public static bool OnPlayerInside = false;
    bool IsWall = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        vec = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FrogMove.me.SetActive(false);
        }
        if (collision.gameObject.CompareTag("wall"))
        {
            IsWall = true;
            OnPlayerInside = false;
            gameObject.SetActive(false);
            Invoke("Spawn", 1f);
        }
    }

    void Spawn()
    {
        transform.position = vec;
        gameObject.SetActive(true);
    }

    private void FixedUpdate()
    {
        if (OnPlayerInside)
        {
            if (transform.localScale.x >= 0)
                rb.AddForce(Vector2.right * -moveSpeed * Time.deltaTime, ForceMode2D.Impulse);
            else if (transform.localScale.x < 0)
                rb.AddForce(Vector2.left * -moveSpeed * Time.deltaTime, ForceMode2D.Impulse);
        }
    }
}
