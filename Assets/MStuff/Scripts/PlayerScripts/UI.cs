using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public InventoryScript Is;
    public PlayerManagementScript pms;
    public InteractionButtonScript ibs;
    public AssistButton ab;
    public TextMeshProUGUI lifeText;
    
    public TextMeshProUGUI trashText;
    public Image imageUI;
    public Slider WeaponSlide;

    public Image assistImage;

    private Color origColor;
    // Start is called before the first frame update
    void Start()
    {   
        origColor = assistImage.GetComponent<Image>().color;

        trashText.text = Is.trash.ToString() +"/7";
        lifeText.text = "Money: " + pms.currency.ToString();
       
        imageUI.sprite = ibs.wepn.image;
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log("uuuuu");
       origColor.a = ab.assistGuage/ab.assistGuageLimit;
       assistImage.GetComponent<Image>().color = origColor;
        lifeText.text =  pms.currency.ToString();
        
        imageUI.sprite = ibs.wepn.image;
        WeaponSlide.maxValue = 100.0f;
        WeaponSlide.value = ibs.waitTimeCounter;
        trashText.text = Is.trash.ToString() +"/7";
    }
}
