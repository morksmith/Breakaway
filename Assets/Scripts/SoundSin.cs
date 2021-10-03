using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSin : MonoBehaviour
{
    public AudioSource Audio;

    private float step;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        step += Time.deltaTime;
        Audio.pitch = 0.7f + Mathf.Sin(step) * 0.1f;
    }
}
