using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> ObjectsToSpawn;
    public float SpawnFrequency =1;
    public float LevelWidth = 5;
    public bool IncreaseOverTime = false;
    private GameManger game;


    private float timer;
    private void Start()
    {
        game = GameObject.FindObjectOfType<GameManger>();
    }

    public void Update()
    {
        if (game.Paused)

        {
            return;
        }
        if (IncreaseOverTime)
        {
            if (SpawnFrequency > 0.2f)
            {
                SpawnFrequency -= Time.deltaTime * 0.01f;
            }
        }
        timer += Time.deltaTime;
        if(timer > SpawnFrequency)
        {
            SpawnObstacle();
            timer = 0;
        }
    }

    public void SpawnObstacle()
    {
        var objectPicker = Random.Range(0, ObjectsToSpawn.Count);
        var xPos = Random.Range(-LevelWidth, LevelWidth);
        var newObject = Instantiate(ObjectsToSpawn[objectPicker], new Vector2(transform.position.x + xPos, transform.position.y), transform.rotation);
    }
}
