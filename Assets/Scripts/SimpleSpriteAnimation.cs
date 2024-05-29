using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

namespace Tallawah{

    public class SimpleSpriteAnimation : MonoBehaviour
    {
        public SpriteRenderer currentSprite;

        public List<Sprite> images;

        public float animationSpeed = .25f;


        public int currentFrameIndex = 0;


        public void Start()
        {
            currentFrameIndex = 0;
            currentSprite.sprite = images[currentFrameIndex];

            StartCoroutine(Animate());
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
    }
}
