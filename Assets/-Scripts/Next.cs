using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Next : MonoBehaviour
{
    private bool visible=true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!visible && GameObject.Find("Person") == null)
        {
            Invoke("go",0.5f);
            visible=true;
        }
        else if(visible && GameObject.Find("Person") != null)
        {
            GetComponent<CircleCollider2D>().enabled=false;
            GetComponent<SpriteRenderer>().enabled=false;
            visible=false;
        }
    }

    void OnMouseDown() 
    {
        if(!Data.pause)
        {
            Data.start=true;
            GameObject.Find("Guy"+Data.guy.ToString()).GetComponent<Guy>().first();
        }
    }

    private void go()
    {
        GetComponent<CircleCollider2D>().enabled=true;
        GetComponent<SpriteRenderer>().enabled=true;
    }
}
