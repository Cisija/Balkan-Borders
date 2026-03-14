using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passport : MonoBehaviour
{
    public int layer;
    public int greska;

    private bool isDragging = false;
    private bool isBig = false;
    private bool wasBig = false;
    private bool death = false, dead = true;
    private Vector2 mousePosition;
    private Vector2 offset;
    private Vector2 offsetBig = new Vector2();
    private Vector2 offsetSmall = new Vector2();
    public Sprite passportBig;
    public Sprite passportSmall;
    public BoxCollider2D ColliderBig;
    private float drop = 0f;
    private float WindowTableBorder = -3.24f;

    private float BorderWindowBorder = 1.26f;
    private float BottomWindowBorder = -3.24f;
    private float dropRate = 1f;
    private float TopTableBorder = 3.5f;
    private float BottomTableBorder = -7f;
    private float RightTableBorder = 10.5f;

    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        if (isDragging && !Data.pause)
        {
            dropRate = 0f;
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition - offset;
        }
        if (isBig && !death)
        {
            GetComponent<SpriteRenderer>().sortingLayerName = layer.ToString();
        }
        else if (!isBig && !death)
        {
            GetComponent<SpriteRenderer>().sortingLayerName = layer.ToString() + "s";
        }
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > WindowTableBorder && transform.position.x > WindowTableBorder && !isBig && isDragging)
        {
            offsetSmall = offset;
            GetComponent<SpriteRenderer>().sprite = passportBig;
            ColliderBig.enabled = true;
            offset = offsetBig;
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).GetComponent<MeshRenderer>()) transform.GetChild(i).GetComponent<MeshRenderer>().enabled = true;
                else if (transform.GetChild(i).GetComponent<SpriteRenderer>()) transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = true;
                else if (transform.GetChild(i).name == "Image" || transform.GetChild(i).name == "ImageNew")
                {
                    for (int j = 0; j < transform.GetChild(i).transform.childCount; j++)
                    {
                        transform.GetChild(i).transform.GetChild(j).GetComponent<SpriteRenderer>().enabled = true;
                    }
                }
            }
            isBig = true;
            wasBig = true;
        }
        else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < WindowTableBorder && transform.position.x < WindowTableBorder && isBig && isDragging)
        {
            offsetBig = offset;
            GetComponent<SpriteRenderer>().sprite = passportSmall;
            ColliderBig.enabled = false;
            offset = offsetSmall;
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).GetComponent<MeshRenderer>()) transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
                else if (transform.GetChild(i).GetComponent<SpriteRenderer>()) transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = false;
                else if (transform.GetChild(i).name == "Image" || transform.GetChild(i).name == "ImageNew")
                {
                    for (int j = 0; j < transform.GetChild(i).transform.childCount; j++)
                    {
                        transform.GetChild(i).transform.GetChild(j).GetComponent<SpriteRenderer>().enabled = false;
                    }
                }
            }
            isBig = false;
        }
        if (!isBig && transform.position.y > BorderWindowBorder)
        {
            transform.position = new Vector2(transform.position.x, BorderWindowBorder);
        }
        if (!isBig && !death && transform.position.y < BottomWindowBorder)
        {
            transform.position = new Vector2(transform.position.x, BottomWindowBorder);
            dropRate = 0f;
        }
        if ((transform.position.y > BottomWindowBorder || death) && !isBig && !isDragging && !Data.pause)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - drop * Time.deltaTime);
            drop += dropRate;
        }
        if (isBig && transform.position.y > TopTableBorder)
        {
            transform.position = new Vector2(transform.position.x, TopTableBorder);
        }
        if (isBig && transform.position.y < BottomTableBorder)
        {
            transform.position = new Vector2(transform.position.x, BottomTableBorder);
        }
        if (isBig && transform.position.x > RightTableBorder)
        {
            transform.position = new Vector2(RightTableBorder, transform.position.y);
        }
        if (death && transform.position.y < -7 && transform.position.y > -8 && dead)
        {
            GameObject.Find("Person").GetComponent<Person>().passportDeath();
            dead = false;
        }

    }

    void OnMouseDown()
    {
        if (!Data.pause)
        {
            isDragging = true;
            offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        }
        GameObject.Find("Manager").GetComponent<Manager>().PushDown(this.name);
    }

    void OnMouseUp()
    {
        if (!isBig && mousePosition.x > -8.1f && mousePosition.x < -4.9f && mousePosition.y > -2.1f && mousePosition.y < Data.window - 1.679 && wasBig)
        {
            GetComponent<SpriteRenderer>().sortingLayerName = "Falling Document";
            death = true;
        }
        isDragging = false;
        offsetSmall = new Vector2();
        offsetBig = new Vector2();
        GameObject.Find("Manager").GetComponent<Manager>().resetZ();
    }

}