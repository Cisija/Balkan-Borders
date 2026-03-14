using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    public AudioClip to,from;

    private bool leave,spawn,go;

    private float rand;

    private AudioSource sound;

    private float y;

    private bool death = false;

    private bool direction = true;

    private float speed = 6f;

    private float bobSize = 0.05f;

    private float bobSpeed = 0.7f;

    private float speedRate = 0.1f;

    private float slowRate = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Data.arrive=false;
        leave = true;
        sound = GetComponent<AudioSource>();

        y = transform.position.y;
        rand = Random.Range(-6.6f, -6.4f);
    }

    // Update is called once per frame
    void Update()
    {
        if (spawn)
        {
            sound.clip = to;
            sound.time=0.5f;
            spawn = false;
            float move= GameObject.Find("Guy"+Data.guy.ToString()).GetComponent<Guy>().move;
            if(move<=10) walk();
            else
            {
                Invoke ("walk",(move-10)*0.1f);
                sound.time=0.5f-(move-10)*0.1f;
            }
            sound.Play();
        }
        if (go)
        {
            if (
                transform.position.x > -8f &&
                transform.position.x < rand &&
                !death &&
                !Data.pause
            )
            {
                transform.position =
                    new Vector2(transform.position.x + speed * Time.deltaTime,
                        transform.position.y);
                if (speed > 0)
                {
                    speed -= slowRate * Time.deltaTime;
                }
                else
                {
                    speed = 0.5f;
                }
                if (bobSpeed > 0)
                {
                    bobSpeed -= 0.01f;
                }
                else
                {
                    bobSpeed = 0.1f;
                }
            }
            else if (transform.position.x < -8f && !death && !Data.pause)
            {
                transform.position = new Vector2(transform.position.x + speed * Time.deltaTime,transform.position.y);
            }
            else
            {
                Data.arrive = true;
            }

            if (transform.position.y > y + bobSize)
            {
                direction = false;
            }
            else if (transform.position.y < y - bobSize)
            {
                direction = true;
            }

            if (direction && (!Data.arrive || death) && !Data.pause)
            {
                transform.position =
                    new Vector2(transform.position.x,
                        transform.position.y + bobSpeed * Time.deltaTime);
            }
            else if (!direction && (!Data.arrive || death) && !Data.pause)
            {
                transform.position =
                    new Vector2(transform.position.x,
                        transform.position.y - bobSpeed * Time.deltaTime);
            }
        }

        if (death && !Data.pause)
        {
            if (leave)
            {
                sound.clip = from;
                sound.Play();
                leave = false;
            }
            if (speed < 6f)
            {
                speed += speedRate;
            }
            if (bobSpeed < 0.7f)
            {
                bobSpeed += 0.02f;
            }
            if (GameObject.Find("Stamp") != null)
            {
                transform.position =
                    new Vector2(transform.position.x + speed * Time.deltaTime,
                        transform.position.y);
            }
            else
            {
                transform.position =
                    new Vector2(transform.position.x - speed * Time.deltaTime,
                        transform.position.y);
            }
        }

        if (transform.position.x > -1.2 || transform.position.x < -12)
        {
            GameObject.Find("Game").GetComponent<Game>().personDeath();
        }
    }

    public void passportDeath()
    {
        if(GameObject.Find("Stamp") != null)
        {
            GameObject.Find("Guy"+Data.guy.ToString()).GetComponent<Guy>().leave(true);
        }
        else
        {
            GameObject.Find("Guy"+Data.guy.ToString()).GetComponent<Guy>().leave(false);
        }
        
        speed = 0f;
        bobSpeed = 0f;
        death = true;
    }

    public void walk()
    {
        go = true;
    }

    public void start()
    {
        spawn=true;
    }
}
