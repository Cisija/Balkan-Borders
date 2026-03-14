using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right : MonoBehaviour
{
    public Sprite right;
    public Sprite rightClick;
    private SpriteRenderer rend;
    private int tracks;
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
        rend.sprite=rightClick;
    }

    void OnMouseUp()
    {
        rend.sprite=right;
        radio.Stop();
    }
}
