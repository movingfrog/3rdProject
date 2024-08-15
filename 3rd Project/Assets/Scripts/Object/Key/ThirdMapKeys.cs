using UnityEngine;

public class ThirdMapKeys : MonoBehaviour
{
    public static bool[] keys = new bool[4];
    public GameObject[] Lockers;
    public GameObject[] LockObject;

    private void Start()
    {
        for(int i = 0; i < keys.Length; i++)
        {
            keys[i] = false;
        }
    }

    private void Update()
    {
        for(int i = 0;i < Lockers.Length;i++)
        {
            if (keys[i] == true)
            {
                Destroy(Lockers[i]);
            }
        }
        if (keys[3])
        {
            Destroy(LockObject[0]);
            if (keys[2])
            {
                Destroy(LockObject[1]);
                if (keys[1])
                {
                    Destroy(LockObject[2]);
                    if (keys[0])
                        Destroy(LockObject[3]);
                }
            }
        }
    }

}
