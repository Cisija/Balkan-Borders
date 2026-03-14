using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left : MonoBehaviour
{
    public Sprite left;
    public Sprite leftClick;
    private int tracks;
    private SpriteRenderer rend;
    private Radio radio; 
    // Start is called before the first frame update
    void Start()
    {
        rend=GetComponent<SpriteRenderer>();
        radio=GameObject.Find("Radio").GetComponent<Radio>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        rend.sprite=leftClick;
    }

    void OnMouseUp()
    {
        rend.sprite=left;
        if(Data.radio!=0)
        {
            if(Data.radio==4)
            {
                Data.radio=1;
            }
            else
            {
                Data.radio+=1;
            }
        }
        if(Data.radio==1)
        {
            tracks=radio.BiH;
        }
        else if(Data.radio==2)
        {
            tracks=radio.Hr;
        }
        else if(Data.radio==3)
        {
            tracks=radio.Srb;
        }
        else if(Data.radio==4)
        {
            tracks=radio.Yug;
        }
        Data.track=Random.Range(0,tracks);
        radio.Stop();
    }
}
