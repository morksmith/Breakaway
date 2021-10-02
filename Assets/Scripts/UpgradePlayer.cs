using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradePlayer : MonoBehaviour
{
    public PlayerControl Player;
    public GameManger Game;
    public bool UpgradeOpen = false;
    public TextMeshProUGUI UpgradeName;
    public TextMeshProUGUI CostText;
    public TextMeshProUGUI PurchaseText;
    public Image UpgradeImage;
    public List<Upgrade> Upgrades;
    public Upgrade CurrentUpgrade;

    private void Start()
    {
        NewUpgrade();
    }
    public void NewUpgrade()
    {
        var upgradePick = Random.Range(0, Upgrades.Count);
        CurrentUpgrade = Upgrades[upgradePick];
        if(CurrentUpgrade.Type == Upgrade.UpgradeType.Shield && Player.Shielded)
        {
            NewUpgrade();
        }
        if (CurrentUpgrade.Type == Upgrade.UpgradeType.Hat && Player.Hatted)
        {
            NewUpgrade();
        }
        if (CurrentUpgrade.Type == Upgrade.UpgradeType.FishingRod && Player.Rodded)
        {
            NewUpgrade();
        }
        if (CurrentUpgrade.Type == Upgrade.UpgradeType.Invulnerability && Player.Invulnerable)
        {
            NewUpgrade();
        }
        UpgradeImage.sprite = CurrentUpgrade.UpgradeSprite;
        UpgradeName.text = CurrentUpgrade.UpgradeName;
        CostText.text = "$" + CurrentUpgrade.Cost;

        if(Game.Coins >= CurrentUpgrade.Cost)
        {
            PurchaseText.text = "PRESS SPACE TO PURCHASE";
        }
        else
        {
            PurchaseText.text = "NOT ENOUGH COINS \n PRESS SPACE TO CONTINUE";
        }

    }

    public void Update()
    {
        if (UpgradeOpen)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(CurrentUpgrade.Cost <= Game.Coins)
                {
                    Game.Coins -= CurrentUpgrade.Cost;
                    if(CurrentUpgrade.Type == Upgrade.UpgradeType.Shield)
                    {
                        Player.AddShield();
                    }
                    if(CurrentUpgrade.Type == Upgrade.UpgradeType.Invulnerability)
                    {
                        Player.AddInv();
                    }
                    if(CurrentUpgrade.Type == Upgrade.UpgradeType.Speed)
                    {
                        Player.AddSpeed();
                    }
                    if (CurrentUpgrade.Type == Upgrade.UpgradeType.Hat)
                    {
                        Player.AddHat();
                    }
                    if (CurrentUpgrade.Type == Upgrade.UpgradeType.FishingRod)
                    {
                        Player.AddFishingRod();
                    }
                    Game.Paused = false;
                }
                else
                {
                    Game.Paused = false;
                }
                UpgradeOpen = false;
                gameObject.SetActive(false);
            }
        }
    }



}
