using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChack : MonoBehaviour
{
    public static PlayerChack instance;

    private void Awake()
    {
        instance = this;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            BeeDown.Instance.IsPlayerChack = true;
        }
    }
}
