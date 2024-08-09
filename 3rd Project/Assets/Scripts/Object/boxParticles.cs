using UnityEngine;

public class boxParticles : MonoBehaviour
{
    public int maxBounce;

    public float Xforce;
    public float Yforce;
    public float gravity;

    private Vector2 direction;
    private bool isGrounded = true;

    private float maxHeight;
    private int currentBounce = 0;
    private float currentheight;

    public Transform shadow;
    public Transform sprite;

    private void Awake()
    {
        currentheight = Random.Range(Yforce - 1, Yforce);
        maxHeight = currentheight;
        Initialize(new Vector2(Random.Range(-Xforce, Xforce), Random.Range(-Xforce, Xforce)));
    }

    private void Update()
    {
        if (!isGrounded)
        {
            currentheight += -gravity * Time.deltaTime;
            sprite.position += new Vector3(0, currentheight, 0) * Time.deltaTime;
            transform.position += (Vector3)direction * Time.deltaTime;

            float totalVelocity = Mathf.Abs(currentheight) + Mathf.Abs(maxHeight);
            float scaleXY = Mathf.Abs(currentheight) / totalVelocity;
            shadow.localScale = Vector2.one * Mathf.Clamp(scaleXY, 0.5f, 1.0f);

            CheckGroundHit();
        }
    }

    void Initialize(Vector2 _direction)
    {
        isGrounded = false;
        maxHeight /= 1.5f;
        direction = _direction;
        currentheight = maxHeight;

    }

    void CheckGroundHit()
    {
        if(sprite.position.y < shadow.position.y)
        {
            sprite.position = shadow.position;
            shadow.localScale = Vector2.one;

            if(currentBounce < maxBounce)
            {
                Initialize(direction / 1.5f);
            }
            else
            {
                isGrounded = true;
            }
        }
    }
}
