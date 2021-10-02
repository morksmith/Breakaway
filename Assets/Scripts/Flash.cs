using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    public float FlashFrequency;
    public float FlashTime;
    public bool Flashing = false;
    private Renderer rend;
    private float timer;
    private float flashTimer;
    private GameManger game;

    private void Start()
    {
        game = GameObject.FindObjectOfType<GameManger>();
        rend = GetComponent<Renderer>();
    }

    public void Update()
    {
        if (game.Paused)
        {
            return;
        }
        if (Flashing)
        {
            timer += Time.deltaTime;
            flashTimer += Time.deltaTime;
            if(flashTimer > FlashFrequency)
            {
                if(rend.enabled == true)
                {
                    rend.enabled = false;
                }
                else
                {
                    rend.enabled = true;
                }
                flashTimer = 0;
            }
            if(timer > FlashTime)
            {
                Flashing = false;
                rend.enabled = true;
            }
        }
    }

    public void FlashStart()
    {
        Flashing = true;
        timer = 0;
        flashTimer = 0;
    }
}
