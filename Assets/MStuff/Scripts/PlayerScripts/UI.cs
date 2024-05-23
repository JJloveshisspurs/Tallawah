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
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI keyText;
    public Image imageUI;
    // Start is called before the first frame update
    void Start()
    {
        lifeText.text = "Money: " + pms.currency.ToString();
        keyText.text = "Keys: " + Is.keys.ToString();
        imageUI.sprite = ibs.wepn.image;
    }

    // Update is called once per frame
    void Update()
    {
        lifeText.text = "Money: " + pms.currency.ToString();
        keyText.text = "Keys: " + Is.keys.ToString();
        imageUI.sprite = ibs.wepn.image;
    }
}
