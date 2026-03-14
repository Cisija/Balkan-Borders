using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WokiToki : MonoBehaviour
{

    public GameObject bubble,correct,photo,date,gender,city;
    public GameObject green;
    private GameObject current;
    private bool go=false,closing=false;
    private float x;
    private int r;
    private AudioSource sound;
    private Object[] clips;

    private float speed=0.1f;
    private float time=3.7f;
    private float delay=0.1f;

    // Start is called before the first frame update
    void Start()
    {
        sound=GetComponent<AudioSource>();
        clips=Resources.LoadAll("WokiToki", typeof(AudioClip));
    }

    // Update is called once per frame
    void Update()
    {
        if(go)
        {
            current.transform.position=new Vector2(current.transform.position.x-speed*100*Time.deltaTime,current.transform.position.y);
            if(current.transform.position.x<x)
            {
                go=false;
                current.transform.position=new Vector2(x,current.transform.position.y);
                closing=true;
                Invoke("close",time);
            }
        }
    }

    public void error(int r)
    {
        if(closing)
        {
            CancelInvoke();
            sound.Stop();
            current.transform.position=new Vector2(x,current.transform.position.y);
            current.transform.position=new Vector2(current.transform.position.x+4f,current.transform.position.y);
            green.SetActive(false);
            closing=false;
        }
        bubble.SetActive(true);
        if(r==-1)
        {
            current=correct;
            x=-6.4056f;
        }
        else if(r==0)
        {
            current=city;
            x=-5.9105f;
        }
        else if(r==1)
        {
            current=gender;
            x=-5.6107f;
        }
        else if(r==2)
        {
            current=photo;
            x=-5.8357f;
        }
        else if(r==3)
        {
            current=date;
            x=-5.8359f;
        }
        Invoke("start",delay);
        green.SetActive(true);
        sound.clip=(AudioClip)clips[Random.Range(0,clips.Length)];
        sound.Play();
    }

    private void close()
    {
        if(closing)
        {
            bubble.SetActive(false);
            current.transform.position=new Vector2(current.transform.position.x+4f,current.transform.position.y);
            closing=false;
            green.SetActive(false);
        }
    }

    private void start()
    {
        go=true;
    }
}
