using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerManager : MonoBehaviour
{
    public GameObject[] Lock;

    private void Update()
    {
        if(End.count >= 1)
        {
            Destroy(Lock[0]);
        }
        if(End.count >= 2)
            Destroy(Lock[1]);
        if(End.count >= 3)
            Destroy(Lock[2]);
    }
}
