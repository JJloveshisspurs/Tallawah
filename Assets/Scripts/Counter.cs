using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Counter : MonoBehaviour
{
    public static Counter instance;
    public TMP_Text coinText;
    public Sprite[] imagesList;
    public Image image;
    public int currentCoins = 0;
    public int maxCoins;
    private bool rastaManActive = false;

    private void Awake()
    {
        // Ensure that only one instance of Counter exists.
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateCoinText();
        // Change the sprite of the GameObject to the sprite at the specified index.
        ChangeCoinImage(currentCoins);
    }

    void Update()
    {
        if (currentCoins >= maxCoins && !rastaManActive)
        {
       
            RastaManAppears();
        }
    }

    public void IncreaseCoins(int amount)
    {
        currentCoins += amount;
        
        if (currentCoins < 0)
        {
            currentCoins = 0;
        }

        UpdateCoinText();
        ChangeCoinImage(currentCoins);
    }

    public void DecreaseCoins(int amount)
    {
        currentCoins -= amount;
        if (currentCoins < 0)
        {
            currentCoins = 0;
        }
        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = $"COINS: {currentCoins} / {maxCoins}";
        }
    }

   
   public void ChangeCoinImage(int index)
    {
       image.sprite = imagesList[index];

    }




    private void RastaManAppears()
    {
        rastaManActive = true;
        Debug.Log("RastaMan Activated");
    
    }
}