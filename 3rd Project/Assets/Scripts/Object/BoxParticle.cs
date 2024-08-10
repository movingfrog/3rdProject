using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxParticle : MonoBehaviour
{
    public GameObject[] box;
    private void Awake()
    {
        //Invoke("Test", 3f);
    }

    public void Test()
    {
        Debug.Log("TestOn");
        this.gameObject.SetActive(false);
        for (int i = 0; i < box.Length; i++)
        {
            Instantiate(box[i]);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        for(int i = 0; i < box.Length; i++)
        {
            Instantiate(box[i]);
        }
    }
}
