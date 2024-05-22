using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Counter : MonoBehaviour
{

    public static Counter instance;
    public TMP_Text coinText;
    public int currentCoins = 0;


    private void Awake()
    {
        instance = this;
    }
    

    // Start is called before the first frame update
    void Start()
    {
        coinText.text = currentCoins.ToString();
    }

  
    public void IncreaseCoins(int amount)
    {
        currentCoins += amount;
        coinText.text =  "COINS: " + currentCoins.ToString();
    }

    public void DecreaseCoins(int amount)
    {
        currentCoins -= amount;
        coinText.text = "COINS: " + currentCoins.ToString();
    }

}

