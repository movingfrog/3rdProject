using UnityEngine;

public class SilverKey : MonoBehaviour
{
    public static bool Key = false;

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
