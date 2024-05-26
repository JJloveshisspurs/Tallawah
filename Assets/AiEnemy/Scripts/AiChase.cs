using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiChase : MonoBehaviour
{
    public GameObject player;
    public float speed;

    private float distance;

    public SpriteAnimator walking_Animation;
    public SpriteAnimator running_Animation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        
        
        if (distance < 4)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);

            if (running_Animation.enabled == false)
            {
                walking_Animation.enabled = false;
                running_Animation.enabled = true;
            }
            
        }
        else
        {

            if (walking_Animation.enabled == false)
            {
                walking_Animation.enabled = true;
                running_Animation.enabled = false;
            }

        }
    }
}
