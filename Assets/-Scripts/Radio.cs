using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Radio : MonoBehaviour
{
    public int BiH;

    public int Hr;

    public int Srb;

    public int Yug;

    public Sprite flagBiH;

    public Sprite flagHr;

    public Sprite flagSrb;

    public Sprite flagYug;

    public Sprite button;

    public Sprite buttonClick;

    private SpriteRenderer flag;

    private int lastRadio = 1;

    private SpriteRenderer rend;

    private AudioSource music;

    private int tracks;

    // Start is called before the first frame update
    private Object[] songsBiH;
    private Object[] songsHr;
    private Object[] songsSrb;
    private Object[] songsYug;

    // Start is called before the first frame update
    void Start()
    {
        flag = GameObject.Find("Flag").GetComponent<SpriteRenderer>();
        music = GetComponent<AudioSource>();
        rend = GetComponent<SpriteRenderer>();
        songsBiH=Resources.LoadAll("Music/BiH", typeof(AudioClip));
        BiH=songsBiH.Length-1;
        songsHr=Resources.LoadAll("Music/Hr", typeof(AudioClip));
        Hr=songsHr.Length-1;
        songsSrb=Resources.LoadAll("Music/Srb", typeof(AudioClip));
        Srb=songsSrb.Length-1;
        songsYug=Resources.LoadAll("Music/Yug", typeof(AudioClip));
        Yug=songsYug.Length-1;
    }

    // Update is called once per frame
    void Update()
    {
        music.volume=Data.radioVolume;
        if (Data.radio == 1)
        {
            flag.sprite = flagBiH;
            tracks=BiH;
        }
        else if (Data.radio == 2)
        {
            flag.sprite = flagHr;
            tracks=Hr;
        }
        else if (Data.radio == 3)
        {
            flag.sprite = flagSrb;
            tracks=Srb;
        }
        else if (Data.radio == 4)
        {
            flag.sprite = flagYug;
            tracks=Yug;
        }

        if (!music.isPlaying && Data.radio!=0)
        {
            if (Data.radio == 1)
            {
                music.clip = (AudioClip)songsBiH[Data.track];
            }
            else if (Data.radio == 2)
            {
                music.clip = (AudioClip)songsHr[Data.track];
            }
            else if (Data.radio == 3)
            {
                music.clip = (AudioClip)songsSrb[Data.track];
            }
            else if (Data.radio == 4)
            {
                music.clip = (AudioClip)songsYug[Data.track];
            }
            if(Data.track>tracks-1)
            {
                Data.track=0;
            }
            else
            {
                Data.track++;
            }
            music.Play(0);
        }
    }

    void OnMouseDown()
    {
        rend.sprite = buttonClick;
    }

    void OnMouseUp()
    {
        rend.sprite = button;
        if (Data.radio == 0)
        {
            Data.radio = lastRadio;
            if(Data.radio==1)
            {
                tracks=BiH;
            }
            else if(Data.radio==2)
            {
                tracks=Hr;
            }
            else if(Data.radio==3)
            {
                tracks=Srb;
            }
            else if(Data.radio==4)
            {
                tracks=Yug;
            }
            Data.track=Random.Range(0,tracks);
        }
        else
        {
            lastRadio = Data.radio;
            Data.radio = 0;
            music.Stop();
            flag.sprite=null;
        }
    }

    public void Stop()
    {
        music.Stop();
    }
}
