using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapClick : MonoBehaviour
{
    private Vector2 savedPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Data.mapCollidersActive)
        {
            GetComponent<BoxCollider2D>().enabled=true;
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled=false;
        }
    }

    void OnMouseDown()
    {
        transform.parent.GetComponent<Map>().OnMouseDown();
        savedPosition=transform.position;
    }

    void OnMouseUp()
    {
        transform.parent.GetComponent<Map>().OnMouseUp();
        if(savedPosition==new Vector2(transform.position.x,transform.position.y))
        {
            Data.mapCollidersActive=false;
            transform.parent.GetComponent<Map>().click(this.name);
        }
    }
}
