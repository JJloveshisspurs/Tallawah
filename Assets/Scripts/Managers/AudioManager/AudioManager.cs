using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    public float defaultMusicVolume = .5f;

    public float defaultMusicTime = .5f;


    public List<AudioItemMusic> musicItems;

    public List<AudioItemSFX> SFX_Items;

    public AudioSource music_Source;

    public List<AudioSource> SFX_Sources;

    public int current_SFX_SourceIndex;


    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {

            DestroyObject(this.gameObject);
        }
        
    }

    public void PlayMusic(MusicTrackEnums.Music pMusicTracks)
    {

        AudioClip selectedAudioClip = null;

        for(int i = 0; i < musicItems.Count; i++)
        {

            if(musicItems[i].musicTrackSelection == pMusicTracks)
            {

                selectedAudioClip = musicItems[i].audioClip;

                break;
            }


        }

        music_Source.clip = selectedAudioClip;

        music_Source.Play();

    }

    public void PlaySFX(SFXTrackEnums.SFX pSFXTracks)
    {

        AudioClip selectedAudioClip = null;
        AudioSource selectedAudioSource;

        for (int i = 0; i < SFX_Items.Count; i++)
        {
            if (SFX_Items[i].SFX_TrackSelection == pSFXTracks)
            {

                selectedAudioClip = SFX_Items[i].audioClip;

                break;
            }

        }

        selectedAudioSource = GetNextEmptySFX_AudioSurce();
       
        selectedAudioSource.PlayOneShot(selectedAudioClip);


    }


    public AudioSource GetNextEmptySFX_AudioSurce()
    {

        current_SFX_SourceIndex = current_SFX_SourceIndex + 1;


        if (current_SFX_SourceIndex >= SFX_Sources.Count)
            current_SFX_SourceIndex = 0;


        return SFX_Sources[current_SFX_SourceIndex];
    }


}
