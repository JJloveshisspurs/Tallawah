using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameobjectSFX_Player : MonoBehaviour
{
    public SFXTrackEnums.SFX SFXSelection;

    // Start is called before the first frame update
    void Start()
    {
        PlaySFXOnSceneStart();
    }

    public void PlaySFXOnSceneStart()
    {

        AudioManager.instance.PlaySFX(SFXSelection);

    }


}
