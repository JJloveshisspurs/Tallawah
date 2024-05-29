using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeFade : MonoBehaviour
{

    public bool startInvisible;

    public NarrativeFadeItem narrativeItem;

    private float sprite1_FadeRatio;
    private float sprite2_FadeRatio;


    public float updateTimer = 0f;
    public float updateTimeInterval = 0.1f;

    // Start is called before the first frame update
    void Start()
    {

        if(startInvisible == true)
        {

            FadecharacterSprite();

        }
        
    }

    // Update is called once per frame
    void Update()
    {

        if(narrativeItem.sprite1 != null)
        {
            narrativeItem.sprite1_Fadetimer += Time.deltaTime;
            sprite1_FadeRatio = narrativeItem.sprite1_Fadetimer / narrativeItem.sprite1_Fadetime;
            
        }

        if (narrativeItem.sprite2 != null)
        {
            narrativeItem.sprite2_Fadetimer += Time.deltaTime;
            sprite2_FadeRatio = narrativeItem.sprite2_Fadetimer / narrativeItem.sprite2_Fadetime;

        }


        updateTimer += Time.deltaTime;

        if (updateTimer >= updateTimeInterval)
        {
            updateTimer = 0f;
            UpdateColor();
        }
    }

    public void FadecharacterSprite()
    {
        if (narrativeItem.sprite1 != null)
        {

            narrativeItem.sprite1.color = new Color(1f, 1f, 1f, 0f);

        }

        if (narrativeItem.sprite2 != null)
        {

            narrativeItem.sprite2.color = new Color(1f, 1f, 1f, 0f);

        }

    }


    public void UpdateColor()
    {
        if (narrativeItem.sprite1 != null)
        {
            narrativeItem.sprite1.color = new Color(narrativeItem.sprite1.color.r, narrativeItem.sprite1.color.g, narrativeItem.sprite1.color.b, sprite1_FadeRatio);
        }

        if (narrativeItem.sprite2 != null)
        {
            narrativeItem.sprite2.color = new Color(narrativeItem.sprite2.color.r, narrativeItem.sprite2.color.g, narrativeItem.sprite2.color.b, sprite2_FadeRatio);
        }


    }
}
