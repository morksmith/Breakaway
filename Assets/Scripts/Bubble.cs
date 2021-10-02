using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float LifeTime;

    private float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.position += new Vector3(0, Time.deltaTime, 0);

        if(timer > LifeTime)
        {
            Destroy(gameObject);
        }
    }
}
