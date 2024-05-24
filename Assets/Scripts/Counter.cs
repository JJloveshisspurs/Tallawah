using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SocialPlatforms.Impl;


public class Counter : MonoBehaviour
{

    public static Counter instance;
    public TMP_Text coinText;
    public int currentCoins = 0;
    bool rastaManActive = false;

    private void Awake()
    {
        instance = this;
    }
    

    // Start is called before the first frame update
    void Start()
    {
        coinText.text = "COINS: " + currentCoins.ToString();
    }

    void Update()
    {
        if (currentCoins >= 7 && rastaManActive == false)
        {
            rastaManAppears();
        }
        
    }

    public void IncreaseCoins(int amount)
    {
        currentCoins += amount;

        if (currentCoins < 0)
        {
            currentCoins = 0;
        }

        coinText.text =  "COINS:" + currentCoins.ToString();

    }

    public void DecreaseCoins(int amount)
    {
        currentCoins -= amount;

        if(currentCoins < 0)
        {
            currentCoins = 0;
        }

        coinText.text = "COINS: " + currentCoins.ToString();
    }

    public void rastaManAppears ()
    {
        rastaManActive = true;
        Debug.Log("RastaMan Activated");
    }

}

