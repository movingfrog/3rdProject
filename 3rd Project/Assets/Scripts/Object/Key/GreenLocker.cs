using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenLocker : MonoBehaviour
{
    private void Update()
    {
        if (GreenKey.Key)
        {
            Destroy(gameObject);
        }
    }
}
