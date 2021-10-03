using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform Idol;

    public  SpriteRenderer Renderer;
    private float step;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        step += Time.deltaTime;
        transform.LookAt(Idol.position);
        Renderer.color = new Color(255, 255, 255, Mathf.Sin(step));
        Debug.Log(step);
    }
}
