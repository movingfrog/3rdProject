using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chackPlayer : MonoBehaviour
{
    private BoxCollider2D game;

    public static int i;

    private void Start()
    {
        game = this.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            i = ChickenMove.Instance.transform.position.x - collision.transform.position.x < 0 ? 1 : -1;
            ChickenMove.IsPlyaer = true;
            game.size *= 3;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
            i = ChickenMove.Instance.transform.position.x - collision.transform.position.x < 0 ? 1 : -1;
    }
}
