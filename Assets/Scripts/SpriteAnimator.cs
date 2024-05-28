using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    public SpriteRenderer currentSprite;

    public List<Sprite> images;

    public float animationSpeed = .25f;


    public int currentFrameIndex = 0;

    public bool playOnStart = true;

    bool playingAnimation = false;

    public void Start()
    {
        if (playOnStart)
        {
            currentFrameIndex = 0;
            currentSprite.sprite = images[currentFrameIndex];

            StartCoroutine(Animate());
        }
    }


    IEnumerator Animate()
    {
        currentFrameIndex = currentFrameIndex + 1;

        if (currentFrameIndex >= images.Count)
            currentFrameIndex = 0;

        currentSprite.sprite = images[currentFrameIndex];

        yield return new WaitForSeconds(animationSpeed);

        StartCoroutine(Animate());
    }

    public void StartAnimating()
    {
        if (playingAnimation == false)
        {
            playingAnimation = true;
            StopAllCoroutines();
            currentFrameIndex = 0;
            currentSprite.sprite = images[currentFrameIndex];

            StartCoroutine(Animate());
        }

    }

    public void StopAnimating()
    {
        if (playingAnimation)
        {

            playingAnimation = false;
            StopAllCoroutines();
        }

    }
}
