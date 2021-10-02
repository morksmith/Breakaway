using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public string UpgradeName;
    public Sprite UpgradeSprite;
    public float Cost;
    public enum UpgradeType
    {
        Speed,
        Shield,
        Hat,
        Invulnerability,
        FishingRod
    }
    public UpgradeType Type;

}
