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
            //FrogMove.me.SetActive(false);
        }
        if (collision.gameObject.CompareTag("wall"))
        {
            IsWall = true;
            gameObject.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        if(OnPlayerInside)
        {
            while(!IsWall)
                rb.AddForce(Vector2.right * transform.localScale.x/6 * moveSpeed * Time.deltaTime, ForceMode2D.Impulse);
        }
    }
}
