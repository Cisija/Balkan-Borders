using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider : MonoBehaviour
{
    private bool hold=false;
    public GameObject handle;
    public GameObject fill;
    public float value;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        handle.GetComponent<RectTransform>().anchoredPosition= new Vector2((value*486)-243,handle.GetComponent<RectTransform>().anchoredPosition.y);
        if(hold)
        {
            if(handle.GetComponent<RectTransform>().anchoredPosition.x>=-243 && handle.GetComponent<RectTransform>().anchoredPosition.x<=243)
            {
                handle.transform.position=new Vector2(Input.mousePosition.x,handle.transform.position.y);
            }

            if(handle.GetComponent<RectTransform>().anchoredPosition.x<-243)
            {
                handle.GetComponent<RectTransform>().anchoredPosition=new Vector2(-243,handle.GetComponent<RectTransform>().anchoredPosition.y);
            }
            else if(handle.GetComponent<RectTransform>().anchoredPosition.x>243)
            {
                handle.GetComponent<RectTransform>().anchoredPosition=new Vector2(243,handle.GetComponent<RectTransform>().anchoredPosition.y);
            }
        }
        fill.GetComponent<RectTransform>().offsetMax= new Vector2(-243+handle.GetComponent<RectTransform>().anchoredPosition.x,fill.GetComponent<RectTransform>().offsetMax.y);
        value=(486+fill.GetComponent<RectTransform>().offsetMax.x)/486;
    }
    
    public void OnMouseDown()
    {
        hold=true;
    }
    public void OnMouseUp()
    {
        hold=false;
    }
}
