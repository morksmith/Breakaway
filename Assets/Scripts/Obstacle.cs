using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float MoveSpeed;
    public float MaxLifetime = 5;
    private float yPos;
    private float timer = 0;
    private GameManger game;

    private void Start()
    {
        yPos = transform.position.y;
        game = GameObject.FindObjectOfType<GameManger>();
    }

    void Update()
    {
        if (game.Paused)
        {
            return;
        }
        yPos -= Time.deltaTime * MoveSpeed;
        transform.position = new Vector2(transform.position.x, yPos);

        timer += Time.deltaTime;
        if(timer > MaxLifetime)
        {
            Destroy(gameObject);
        }

    }
    
}
