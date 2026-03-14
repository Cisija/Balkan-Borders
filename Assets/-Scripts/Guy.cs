using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Guy : MonoBehaviour
{
    private bool isIdle = true, send, leaving, isFirst, start = true, isOffset, clicking, rejected;
    private float timeWalk, timeIdle;
    private int frame, i, yOffset, j;
    public float distance, move;
    private float distance2, x, y, intervalIdle;
    private Transform temp;
    private AudioSource sound;

    public Sprite stand;
    public Sprite idle;
    public Sprite click;
    public Sprite[] walk;

    private float speed = 0.03f;
    private float intervalWalk = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        intervalIdle = UnityEngine.Random.Range(0f, 1f);
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Data.pause)
        {
            if (transform.position.x != (float)Math.Round(transform.position.x, 3) && !Data.pause)
            {
                transform.position = new Vector2((float)Math.Round(transform.position.x, 3), transform.position.y);
            }

            if (isIdle && !leaving && !clicking)
            {
                if (timeIdle > intervalIdle && UnityEngine.Random.Range(0, 2) == 1)
                {
                    if (GetComponent<SpriteRenderer>().sprite == stand)
                    {
                        GetComponent<SpriteRenderer>().sprite = idle;
                    }
                    else
                    {
                        GetComponent<SpriteRenderer>().sprite = stand;
                    }
                }
            }
            else if (!isIdle && !leaving && !clicking)
            {
                if (timeWalk > intervalWalk)
                {
                    if (isOffset)
                    {
                        transform.position = new Vector2(transform.position.x, transform.position.y + speed);
                        j++;
                        if (j == yOffset)
                        {
                            isOffset = false;
                        }
                    }
                    if (i >= move - 15 && isFirst)
                    {
                        GameObject.Find("Person").GetComponent<Person>().start();
                        isFirst = false;
                    }
                    if (UnityEngine.Random.Range(0, 10) == 0 && !send)
                    {
                        if (GameObject.Find("Guy" + (Int32.Parse(this.name.Substring(3, this.name.Length - 3)) + 1).ToString()) != null)
                        {
                            GameObject.Find("Guy" + (Int32.Parse(this.name.Substring(3, this.name.Length - 3)) + 1).ToString()).GetComponent<Guy>().next();
                        }
                        send = true;
                    }
                    if (i == move)
                    {
                        isIdle = true;
                        GetComponent<SpriteRenderer>().sprite = stand;
                        if (!send)
                        {
                            if (GameObject.Find("Guy" + (Int32.Parse(this.name.Substring(3, this.name.Length - 3)) + 1).ToString()) != null)
                            {
                                GameObject.Find("Guy" + (Int32.Parse(this.name.Substring(3, this.name.Length - 3)) + 1).ToString()).GetComponent<Guy>().next();
                            }
                        }
                    }
                    if (!isIdle)
                    {
                        GetComponent<SpriteRenderer>().sprite = walk[frame];
                        transform.position = new Vector2(transform.position.x - speed, transform.position.y);
                        frame++;
                        i++;
                    }

                }
                if (frame == 4)
                {
                    frame = 0;
                }
            }

            if (leaving && !clicking && !rejected)
            {
                if (timeWalk > intervalWalk)
                {
                    if (isOffset)
                    {
                        transform.position = new Vector2(transform.position.x, transform.position.y - speed);
                        j++;
                        if (j == yOffset)
                        {
                            isOffset = false;
                        }
                    }
                    GetComponent<SpriteRenderer>().sprite = walk[frame];
                    transform.position = new Vector2(transform.position.x - speed, transform.position.y);
                    frame++;
                }
                if (frame == 4)
                {
                    frame = 0;
                }
            }
            if (leaving && !clicking && rejected)
            {
                if (timeWalk > intervalWalk)
                {
                    if (transform.position.y > 2.805f && !(SceneManager.GetActiveScene().name == "BiH-Srb"))
                    {
                        GetComponent<SpriteRenderer>().sprite = walk[frame];
                        transform.position = new Vector2(transform.position.x + speed, transform.position.y - speed);
                        frame++;
                    }
                    else if (transform.position.y > 2.35f)
                    {
                        GetComponent<SpriteRenderer>().sprite = walk[frame];
                        transform.position = new Vector2(transform.position.x, transform.position.y - speed);
                        frame++;
                    }
                    else
                    {
                        GetComponent<SpriteRenderer>().sprite = walk[frame];
                        transform.position = new Vector2(transform.position.x + speed, transform.position.y - speed);
                        frame++;
                    }
                }
                if (frame == 4)
                {
                    frame = 0;
                }
            }

            if (timeWalk > intervalWalk)
            {
                timeWalk = timeWalk - intervalWalk;
            }
            timeWalk = timeWalk + Time.deltaTime;

            if (timeIdle > intervalIdle)
            {
                if (start)
                {
                    timeIdle = 0;
                    intervalIdle = 0.5f;
                    start = false;
                }
                timeIdle = timeIdle - intervalIdle;
            }
            timeIdle = timeIdle + Time.deltaTime;

            if (transform.position.x < -9.735f || transform.position.y < 1.5f)
            {
                Destroy(gameObject);
            }
        }
    }

    public void leave(bool correct)
    {
        x = UnityEngine.Random.Range(10, 20) / 100f * 3f;
        y = UnityEngine.Random.Range(-4, 4) / 100f * 3f;
        temp = Instantiate(this.transform, new Vector2(GameObject.Find("Guy" + (Data.guy + 50).ToString()).transform.position.x + x, 3.015f + y), Quaternion.identity);
        temp.name = "Guy" + (Data.guy + 51).ToString();
        temp.GetComponent<Guy>().distance = x;
        if (correct)
        {
            yOffset = UnityEngine.Random.Range(2, 5);
            j = 0;
            isOffset = true;
            leaving = true;
            Data.guy++;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
            j = 0;
            leaving = true;
            rejected = true;
            Data.guy++;
        }
    }

    public void next()
    {
        if (isIdle)
        {
            i = 0;
            distance2 = GameObject.Find("Guy" + (Int32.Parse(this.name.Substring(3, this.name.Length - 3)) - 1).ToString()).GetComponent<Guy>().move / 100f * 3f + distance;
            if ((int)(distance2 * 100 / 3) - 15 < 0)
            {
                move = UnityEngine.Random.Range(0, (int)(distance2 * 100 / 3) - 7);
            }
            else
            {
                move = UnityEngine.Random.Range((int)(distance2 * 100 / 3) - 15, (int)(distance2 * 100 / 3) - 7);
            }
            distance = distance2 - (move / 100f * 3f);
            isIdle = false;
            send = false;
        }
        else
        {
            distance = GameObject.Find("Guy" + (Int32.Parse(this.name.Substring(3, this.name.Length - 3)) - 1).ToString()).GetComponent<Guy>().move / 100f * 3f + distance;
        }
    }

    public void first()
    {
        GameObject.Find("Game").GetComponent<Game>().Next();
        send = false;
        i = 0;
        move = (int)Mathf.Round(distance * 100f / 3f);

        yOffset = (int)((3.165f - transform.position.y) * 100f / 3f);
        if (yOffset != 0)
        {
            isOffset = true;
            j = 0;
        }
        isFirst = true;
        isIdle = false;
    }

    private void OnMouseDown()
    {
        if (!Data.pause)
        {
            GetComponent<SpriteRenderer>().sprite = click;
            sound.Play();
            clicking = true;
            Invoke("switchBack", 0.15f);
        }
    }

    private void switchBack()
    {
        GetComponent<SpriteRenderer>().sprite = stand;
        clicking = false;
    }
}
