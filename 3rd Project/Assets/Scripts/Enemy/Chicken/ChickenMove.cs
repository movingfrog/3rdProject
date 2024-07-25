using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenMove : MonoBehaviour
{
    Rigidbody2D rb;
    Animator ani;
    public static ChickenMove Instance;
    [SerializeField]
    private float speedPower;
    [SerializeField]
    private float maxSpeed = 15;

    public static bool IsPlyaer;

    private void Start()
    {
        Instance = this;
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        if (IsPlyaer)
        {
            ani.SetTrigger("ChickenRun");
            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            sprite.flipX = chackPlayer.i == 1 ? true : false;
            rb.velocity += new Vector2(speedPower * chackPlayer.i * Time.deltaTime, 0);
            speedPower += 7.5f * Time.deltaTime;
            if(speedPower >= maxSpeed)
            {
                speedPower = maxSpeed;
                Invoke("IsDie", 5f);
            }
        }
    }
    private void IsDie()
    {
        ani.SetTrigger("Die");
        Destroy(gameObject, 1f);
    }
}
