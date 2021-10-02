using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public float MoveSpeed;
    public float MaxWidth;
    public float DownSpeed;
    public Flash Flash;
    private GameManger game;
    private float xPos;
    private float yPos;
    public bool Shielded = false;
    public bool Invulnerable = false;
    public bool Hatted = false;
    public bool Rodded = false;
    public GameObject Shield;
    public GameObject Inv;
    public GameObject Hat;
    public GameObject Rod;
    public float InvulnerableTime = 8;
    public float invTimer;
    public AudioSource Audio;
    public AudioClip CoinSound;
    public AudioClip HitSound;
    public AudioClip PowerupSound;



    void Start()
    {
        yPos = transform.position.y;
        game = GameObject.FindObjectOfType<GameManger>();

    }

    // Update is called once per frame
    void Update()
    {
        if (game.Paused)
        {
            return;
        }
        if (Invulnerable)
        {
            invTimer += Time.deltaTime;
            if(invTimer > InvulnerableTime)
            {
                Invulnerable = false;
                Inv.SetActive(false);
            }
        }
        if (DownSpeed < 0)
        {
            DownSpeed += Time.deltaTime * MoveSpeed;
        }
        yPos += Input.GetAxis("Vertical") * (MoveSpeed/2) * Time.deltaTime + (DownSpeed * Time.deltaTime);
        xPos += Input.GetAxis("Horizontal") * MoveSpeed * Time.deltaTime;
        xPos = Mathf.Clamp(xPos, -MaxWidth, MaxWidth);
        transform.position = new Vector2(xPos, yPos);

        if(transform.position.y < -5)
        {
            game.GameOver();
        }
        
    }

    public void TakeDamage()
    {
        Flash.FlashStart();
        DownSpeed -= 5;

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided with " + collision.transform.name);
        if (!Flash.Flashing)
        {
            if (collision.transform.tag == "Obstacle")
            {
                Audio.PlayOneShot(HitSound);
                if (Shielded)
                {
                    Destroy(collision.gameObject);
                    Shielded = false;
                    Shield.SetActive(false);
                }
                else if (Invulnerable)
                {
                    Destroy(collision.gameObject);
                }
                else
                {
                    TakeDamage();
                }
            }
        }
        if(collision.transform.tag == "Coin")
        {
            Audio.PlayOneShot(CoinSound);

            game.GetCoin();
            Destroy(collision.gameObject);
        }
        if (collision.transform.tag == "Fish")
        {
            if(Hatted && Rodded)
            Audio.PlayOneShot(PowerupSound);
            SceneManager.LoadScene(1);
        }
        if (collision.transform.tag == "Bomb")
        {
            Audio.PlayOneShot(HitSound);

            if (Shielded)
            {
                Destroy(collision.gameObject);
                Shielded = false;
                Shield.SetActive(false);
            }
            else if (Invulnerable)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                game.GameOver();
            }
        }
    }

    public void AddShield()
    {
        Shield.SetActive(true);
        Shielded = true;
        Audio.PlayOneShot(PowerupSound);

    }
    public void AddInv()
    {
        Inv.SetActive(true);
        Invulnerable = true;
        invTimer = 0;
        Audio.PlayOneShot(PowerupSound);

    }

    public void AddSpeed()
    {
        MoveSpeed += 0.5f;
        Audio.PlayOneShot(PowerupSound);

    }

    public void AddHat()
    {
        Hat.SetActive(true);
        Hatted = true;
        Audio.PlayOneShot(PowerupSound);

    }

    public void AddFishingRod()
    {
        Rod.SetActive(true);
        Rodded = true;
        Audio.PlayOneShot(PowerupSound);

    }

}
