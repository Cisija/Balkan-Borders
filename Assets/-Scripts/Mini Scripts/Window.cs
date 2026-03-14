using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    private GameObject smallWindow;
    private bool isDragging=false;
    private Vector2 mousePosition;
    private Vector2 offset;
    private float x=-6.51f;
    private float BottomWindowBorder=-0.51f;
    private float TopWindowBorder=3f;
    // Start is called before the first frame update
    void Start()
    {
        smallWindow=GameObject.Find("Window Small");
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging && !Data.pause) {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position=new Vector2(x,mousePosition.y-offset.y);
        }
        if(transform.position.y<BottomWindowBorder){
            transform.position =new Vector2 (transform.position.x,BottomWindowBorder);
        }
        if(transform.position.y>TopWindowBorder){
            transform.position =new Vector2 (transform.position.x,TopWindowBorder);
        }
        if(transform.position.y>0.3)
        {
            Data.open=true;
        }
        else
        {
            Data.open=false;
        }
        smallWindow.transform.position= new Vector2(smallWindow.transform.position.x,3.585f+0.42f*((transform.position.y+0.51f)/3.51f));
        Data.window=transform.position.y;
    }

    void OnMouseDown() {
        if(!Data.pause)
        {
            isDragging = true;
            offset=Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
    }
}
