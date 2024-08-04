using UnityEngine;

public class BunnyChack : MonoBehaviour
{
    public static int f;
    public static bool Spawn;

    private void Start()
    {
        Spawn = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Spawn)
        {
            Spawn = false;
            BunnyMove.Instance.ani.SetTrigger("IsPlayer");
            f = collision.gameObject.transform.position.x - BunnyMove.Instance.transform.position.x < 0 ? -1 : 1; 
            BunnyMove.IsPlayer = true;

        }
    }
}
