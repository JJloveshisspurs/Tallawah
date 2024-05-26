using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public string dir;
    public float speed = 1.0f;
    public Rigidbody2D rb;

    public int attack;

    public bool limitTime = false;
    public float theTime = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        if(limitTime)
        {
            StartCoroutine(destroyTime());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(dir == "up")
        {
            rb.velocity = new Vector2(0, speed);
        }
        else if(dir=="left")
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        else if(dir=="right")
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else if(dir=="down")
        {
            rb.velocity = new Vector2(0, -speed);
        }
        
        
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.tag == "Enemy")
        {
           obj.gameObject.GetComponent<EnemyBehaviour>().damage(attack, gameObject.tag);
        }

        if(obj.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator destroyTime()
    {
        yield return new WaitForSeconds(theTime);
         Destroy(gameObject);
    }
}
