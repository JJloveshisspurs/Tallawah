using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject[] destroyObj;
    public GameObject[] appearObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.tag == "Player" || obj.gameObject.tag == "Water")
        {
           //obj.gameObject.GetComponent<EnemyBehaviour>().damage(2.0f, gameObject.tag);
           ObjectDestroy();
           ObjectAppear();
           Destroy(gameObject);
        } 
    }

    public void ObjectDestroy()
    {
        AudioManager.instance.PlaySFX(SFXTrackEnums.SFX.Trash_Plastic_Wrap);
        for(int i = 0; i < destroyObj.Length; i++)
        {
            Destroy(destroyObj[i]);
        }
    }

    public void ObjectAppear()
    {
        for(int i = 0; i < appearObj.Length; i++)
        {
            appearObj[i].SetActive(true);
        }
    }
}
