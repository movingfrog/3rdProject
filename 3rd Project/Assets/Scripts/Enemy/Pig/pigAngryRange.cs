using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pigAngryRange : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.localScale = new Vector3(PigMove.flipX * -1, 1, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PigMove.maxSpeed = 10;
            PigMove.ani.SetBool("IsAngry", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {   
            PigMove.maxSpeed = 0;
            PigMove.ani.SetBool("IsAngry", false);
        }
    }
}
