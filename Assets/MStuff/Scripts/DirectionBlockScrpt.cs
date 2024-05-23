using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionBlockScrpt : MonoBehaviour
{
    public enum direction{west, east, north, south};
    public direction thisdir = direction.west;
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
        if(obj.gameObject.tag == "Enemy")
        {
            if( obj.gameObject.TryGetComponent<DogEnemybehaviour>(out DogEnemybehaviour beh))
            {
                if(thisdir == direction.west)
                {
                    beh.currDir = DogEnemybehaviour.moveDir.west;
                }

                if(thisdir == direction.east)
                {
                    beh.currDir = DogEnemybehaviour.moveDir.east;
                }

                if(thisdir == direction.north)
                {
                    beh.currDir = DogEnemybehaviour.moveDir.north;
                }

                if(thisdir == direction.south)
                {
                    beh.currDir = DogEnemybehaviour.moveDir.south;
                }
            }
        }
    }
}
