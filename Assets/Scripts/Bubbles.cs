using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubbles : MonoBehaviour
{
    public GameObject Bubble;
    public float Height;
    public float Width;
    public float Frequency;

    private float timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > Frequency)
        {
            var x = Random.Range(0, Width);
            var y = Random.Range(0 , Height);
            Vector2 newPos = new Vector2(transform.position.x + x, transform.position.y + y);
            Instantiate(Bubble, newPos, transform.rotation);
            timer = 0;
        }
    }
}
