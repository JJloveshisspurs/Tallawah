using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMusicPlayer : MonoBehaviour
{

    public MusicTrackEnums.Music musicSelection;

    // Start is called before the first frame update
    void Start()
    {
        PlayMusicOnSceneStart();
    }

   public void PlayMusicOnSceneStart()
    {

        AudioManager.instance.PlayMusic(musicSelection);

    }
}
