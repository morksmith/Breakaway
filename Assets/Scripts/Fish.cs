using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public float MoveSpeed;
    public float Size;
    public bool Caught = false;
    public float LifeTime = 20;
    private float timer;
    void Start()
    {
        Size = Random.Range(0.25f, 1.2f);
        transform.localScale *= Size;
        MoveSpeed += Size;
    }

    // Update is called once per frame
    void Update()
    {

        if (!Caught)
        {
            timer += Time.deltaTime;
            transform.position += new Vector3(MoveSpeed * Time.deltaTime, 0, 0);
            if(timer > LifeTime)
            {
                Destroy(gameObject);
            }
        }
    }
}
