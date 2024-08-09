using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxParticle : MonoBehaviour
{
    public GameObject[] box;

    private void OnDestroy()
    {
        for(int i = 0; i < box.Length; i++)
        {
            Instantiate(box[i]);
        }
    }
}
