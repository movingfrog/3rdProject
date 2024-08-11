using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GreenKey : MonoBehaviour
{
    public static bool Key = false;

    private void Start()
    {
        Key = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        Key = true;
    }
}
