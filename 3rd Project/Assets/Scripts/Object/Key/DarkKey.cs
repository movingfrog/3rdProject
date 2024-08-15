using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkKey : MonoBehaviour
{
    public static bool darkKey;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        darkKey = true;
    }
}
