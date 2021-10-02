using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hook : MonoBehaviour
{
    public BoatControl Boat;
    public bool Hooked = false;
    public TextMeshProUGUI MoneyText;
    public float Money = 0;

    public Fish CaughtFish;

    private void Start()
    {
        MoneyText.text = "$" + Mathf.Round(Money);
    }
    public void Update()
    {
        if(transform.localPosition.y > -1.5f)
        {
            if (Hooked)
            {
                Money += 5 * CaughtFish.Size;
                MoneyText.text = "$" + Mathf.Round(Money);
                Destroy(CaughtFish.gameObject);
                Hooked = false;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Fish")
        {
            if (!Hooked)
            {
                collision.GetComponent<Fish>().Caught = true;
                collision.transform.parent = transform;
                CaughtFish = collision.GetComponent<Fish>();
                Boat.State = BoatControl.FishState.Pulling;
                Hooked = true;
            }
            
        }
    }
}
