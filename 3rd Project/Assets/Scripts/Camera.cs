using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameras : MonoBehaviour
{
    Transform game;
    public Camera cam;
    public float speed;

    private void Awake()
    {
        cam = GetComponent<Camera>();
        game = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    private void FixedUpdate()
    {
    }

    private void LateUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, game.position, speed*Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
}
