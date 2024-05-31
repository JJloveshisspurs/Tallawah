using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneIntroMusic : MonoBehaviour
{
    public AudioClip intro_Clip;
    public AudioSource intro_Music;
    public SceneMusicPlayer music_Player;

    private float clipTime;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.StopMusic();
        clipTime = intro_Clip.length;
        intro_Music.PlayOneShot(intro_Clip);
        StartCoroutine(IntroToMainLoop());
    }

    IEnumerator IntroToMainLoop()
    {

        yield return new WaitForSeconds(clipTime);
        music_Player.enabled = true;


    }
}
