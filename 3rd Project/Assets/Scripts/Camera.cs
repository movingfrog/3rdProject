using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    Transform game;
    public float speed;

    private void Awake()
    {
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
