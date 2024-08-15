using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkLocker : MonoBehaviour
{
    void Update()
    {
        if (DarkKey.darkKey)
        {
            Destroy(gameObject);
        }
    }
}
