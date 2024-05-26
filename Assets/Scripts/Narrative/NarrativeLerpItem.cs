using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeLerpItem : MonoBehaviour
{

    public Transform startPosition;
    public Transform endPosition;

    public float lerpTimer;
    public float lerpTimeLength;

    public float lerpRatio;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.position = startPosition.position;
    }

    // Update is called once per frame
    void Update()
    {
        lerpTimer += Time.deltaTime;


        lerpRatio = lerpTimer / lerpTimeLength;


        // Set our position as a fraction of the distance between the markers.
        transform.position = Vector3.Lerp(startPosition.position, endPosition.position, lerpRatio);
    }
}
