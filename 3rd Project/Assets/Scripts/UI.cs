using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public Cameras Camera;

    private void OnEnable()
    {
        Camera.transform.position = new Vector3(0,0,-10);
        Camera.cam.orthographicSize = 5;
    }

}
