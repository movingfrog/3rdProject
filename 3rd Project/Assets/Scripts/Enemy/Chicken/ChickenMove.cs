using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenMove : MonoBehaviour
{
    Rigidbody2D rb;
    public static ChickenMove Instance;
    [SerializeField]
    private float speedPower;
    [SerializeField]
    private float maxSpeed = 15;

    public static bool IsPlyaer;

    private void Start()
    {
        Instance = this;
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
        if (IsPlyaer)
        {
            rb.velocity += new Vector2(speedPower * chackPlayer.i * Time.deltaTime, 0);
            speedPower += 7.5f * Time.deltaTime;
            if(speedPower >= maxSpeed)
            {
                speedPower = maxSpeed;
                Destroy(gameObject, 5f);
            }
        }
    }
}
