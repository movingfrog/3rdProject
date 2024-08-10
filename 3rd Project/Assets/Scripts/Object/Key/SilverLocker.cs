using UnityEngine;

public class SilverLocker : MonoBehaviour
{
    private void Update()
    {
        if (SilverKey.Key)
        {
            Destroy(gameObject);
        }
    }
}
