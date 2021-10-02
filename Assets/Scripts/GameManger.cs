using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public bool GameEnded = false;
    public bool NewGame = true;
    public bool Paused = false;
    public float Distance;
    public float Lives = 3;
    public float HighScore;
    public float Coins;
    public float ShopFrequency;
    public TextMeshProUGUI DistanceText;
    public TextMeshProUGUI CoinText;
    public GameObject GameOverScreen;
    public GameObject StartMenu;
    public TextMeshProUGUI FinalDistanceText;
    public TextMeshProUGUI HighScoreText;
    public GameObject NewHighScore;
    public GameObject ShopMenu;
    public Transform Flag;
    private float shopTimer;
    public AudioSource Audio;
    public AudioClip DeadSound;

    void Start()
    {
        GameEnded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GameEnded)
            {
                RestartGame();
            }
            if (NewGame)
            {
                StartMenu.SetActive(false);
                Paused = false;
                NewGame = false;
            }
        }
        
        if (Paused)
        {
            return;
        }
        shopTimer += Time.deltaTime;
        Distance += Time.deltaTime * 4;
        DistanceText.text = "Distance: " + Mathf.Round(Distance) + "m";
        CoinText.text = "Coins: " + Coins;

        
        var flagY = Mathf.Lerp(4.25f, -4.25f, shopTimer / ShopFrequency);
        if(Flag.position.y > -4.25f)
        {
            Flag.position = new Vector2(Flag.position.x, flagY);
        }
        else
        {
            Paused = true;
            ShopMenu.SetActive(true);
            ShopMenu.GetComponent<UpgradePlayer>().NewUpgrade();
            ShopMenu.GetComponent<UpgradePlayer>().UpgradeOpen = true;
            Flag.position = new Vector2(Flag.position.x, 4.25f);
            shopTimer = 0;
        }
    }

    public void GetCoin()
    {
        Coins++;
    }

    public void GameOver()
    {
        Paused = true;
        GameEnded = true;
        Audio.Stop();
        Audio.loop = false;
        Audio.PlayOneShot(DeadSound);
        FinalDistanceText.text = "Distance: " + Mathf.Round(Distance) + "m";
        HighScoreText.text = "High Score: " + Mathf.Round(PlayerPrefs.GetFloat("score")) + "m";
        GameOverScreen.SetActive(true);
        if(Distance > PlayerPrefs.GetFloat("score"))
        {
            NewHighScore.SetActive(true);
            HighScoreText.text = "High Score: " + Mathf.Round(Distance) + "m";
            PlayerPrefs.SetFloat("score", Distance);
        }
        else
        {
            NewHighScore.SetActive(false);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowShop()
    {

    }


}
