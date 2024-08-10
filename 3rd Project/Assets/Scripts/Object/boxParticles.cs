using UnityEngine;
using UnityEngine.UIElements;

public class boxParticles : MonoBehaviour
{
    public float Xforce;
    public float Yforce;

    public Transform target;

    private void Awake()
    {
        transform.position = new Vector3(target.position.x + Random.Range(-Xforce, Xforce),target.position.y + Yforce, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            Destroy(gameObject);
        }
    }
}
