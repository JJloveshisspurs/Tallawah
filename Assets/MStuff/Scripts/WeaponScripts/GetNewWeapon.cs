using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetNewWeapon : MonoBehaviour
{
    public GameObject textObj;
    public TextMeshProUGUI textNed;
    public bool beingUsed = false;
    public WeaponLoadout weaponLoadout;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(beingUsed)
        {
            if(Input.GetKeyDown("space"))
            {
                Time.timeScale = 1.0f;
                textObj.SetActive(false);
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.tag == "Player")
        {
            obj.gameObject.GetComponent<InventoryScript>().GetWepnFunction();
            textObj.SetActive(true);
            textNed.text = "You just got the water gun. Press c to change your weapon.";
            Time.timeScale = 0.0f;
            beingUsed = true;
            obj.gameObject.GetComponent<InventoryScript>().loadout[1] = weaponLoadout; 
            //StartCoroutine(thisTime());
           // text.SetActive(true);
           //Destroy(gameObject);
        }
    }

    IEnumerator thisTime()
    {
        textObj.SetActive(true);
        Time.timeScale = 0.0f;
        yield return new WaitForSeconds(1.0f);
        Time.timeScale = 1.0f;
        textObj.SetActive(false);
    }
}
