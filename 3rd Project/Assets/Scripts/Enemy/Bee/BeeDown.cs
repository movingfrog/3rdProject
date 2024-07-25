using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BeeDown : MonoBehaviour
{
    Rigidbody2D rb;
    Animator ani;
    Vector3 vec;
    [SerializeField]
    private float fallTime;
    public static BeeDown Instance;
    public bool IsPlayerChack;
    bool IsDown;
    bool IsUp;


    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        ani = GetComponent<Animator>();
        vec = transform.position;
        Debug.Log(vec);
        IsDown = false;
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if(IsPlayerChack)
        {
            ani.SetInteger("IsDown", 1);
            rb.gravityScale = 0.01f;
            rb.AddForce(Vector2.down * 0.3f, ForceMode2D.Impulse);
            IsDown = true;
        }
    }

    public void ReSpawn()
    {
        PlayerChack.instance.gameObject.SetActive(false);
        IsPlayerChack = false;
        IsDown = false;
        rb.gravityScale = 0;
        IsUp = true;
    }

    private void Update()
    {
        if(IsDown && rb.velocity.y == 0)
        {
            Invoke("ReSpawn", 1f);
        }
        if (transform.position.y == vec.y || transform.position.y >= vec.y - 0.1f)
        { 
            PlayerChack.instance.gameObject.SetActive(true);
            IsUp = false;
            ani.SetInteger("IsDown", 2);
        }
        else if (transform.position.y != vec.y && IsUp)
        {
            ani.SetInteger("IsDown", 0);
            transform.position = Vector2.Lerp(transform.position, vec, Time.deltaTime);
        }
    }
}
