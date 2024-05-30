using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{

    public SpriteRenderer sprite;
    public float updateTimer = 0f;
    public float updateTimeInterval = 0.1f;


    public float sprite_Fadetime  =3f;
    public float sprite_Fadetimer;

    private float sprite_FadeRatio;
    // Start is called before the first frame update
    void OnEnable()
    {

    }

    // Update is called once per frame
    void Update()
    {
        updateTimer += Time.deltaTime;
        sprite_Fadetimer += Time.deltaTime;

        if (updateTimer >= updateTimeInterval)
        {
            updateTimer = 0f;
            UpdateColor();
        }
    }

    public void UpdateColor()
    {

        sprite_FadeRatio = sprite_Fadetimer / sprite_Fadetime;

        if (sprite != null)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, sprite_FadeRatio);
        }
    }
}
