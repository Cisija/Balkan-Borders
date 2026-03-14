using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public int layer;

    private bool isDragging = false;
    private bool isBig = false;
    private bool direction = false;
    private bool inPlace = true;
    private Vector3 savedPosition;
    private Vector2 mousePosition;
    private Vector2 offset;
    private Vector2 offsetBig = new Vector2(0f, 0.6f);
    private Vector2 offsetSmall = new Vector2();
    public Sprite mapBig;
    public Sprite mapSmall;
    public BoxCollider2D ColliderBig;

    public Sprite BiH;
    public Sprite Hr;
    public Sprite Srb;
    public Sprite MNE;
    public Sprite Slo;
    public Sprite Mk;

    private float move;
    private float WindowTableBorder = -3.41f;
    private float BorderWindowBorder = 1.2f;
    private float BottomWindowBorder = -3.375f;
    private float locationx = -7.965f;
    private float locationy = -4.6804f;
    private float speed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (isDragging && !Data.pause)
        {
            direction = false;
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition - offset;
        }
        if (isBig)
        {
            GetComponent<SpriteRenderer>().sortingLayerName = layer.ToString();
        }
        else
        {
            GetComponent<SpriteRenderer>().sortingLayerName = layer.ToString() + "s";
        }
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > WindowTableBorder && transform.position.x > WindowTableBorder && !isBig && isDragging)
        {
            offsetSmall = offset;
            GetComponent<SpriteRenderer>().sprite = mapBig;
            ColliderBig.enabled = true;
            offset = offsetBig;
            isBig = true;
            Data.mapCollidersActive = true;
        }
        else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < WindowTableBorder && transform.position.x < WindowTableBorder && isBig && isDragging)
        {
            GetComponent<SpriteRenderer>().sprite = mapSmall;
            ColliderBig.enabled = false;
            offset = offsetSmall;
            isBig = false;
            Data.mapCollidersActive = false;
        }
        if (!isBig && transform.position.y > BorderWindowBorder)
        {
            transform.position = new Vector2(transform.position.x, BorderWindowBorder);
        }
        if (isDragging && !isBig && transform.position.y < BottomWindowBorder)
        {
            transform.position = new Vector2(transform.position.x, BottomWindowBorder);
        }
        if (!isDragging && !isBig && !inPlace && !Data.pause)
        {
            move = speed * 100 * Time.deltaTime;
            if (!direction)
            {
                if (transform.position.x > locationx + move)
                {
                    transform.position = new Vector3(transform.position.x - move, transform.position.y, transform.position.z);
                }
                else if (transform.position.x < locationx - move)
                {
                    transform.position = new Vector3(transform.position.x + move, transform.position.y, transform.position.z);
                }
                if (transform.position.x < locationx + move && transform.position.x > locationx - move)
                {
                    transform.position = new Vector3(locationx, transform.position.y, transform.position.z);
                    direction = true;
                }
            }
            else
            {
                if (transform.position.y > locationy + move)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y - move, transform.position.z);
                }
                else if (transform.position.y < locationy - move)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + move, transform.position.z);
                }
                if (transform.position.y < locationy + move && transform.position.y > locationy - move)
                {
                    transform.position = new Vector3(locationx, locationy, transform.position.z);
                    direction = false;
                    inPlace = true;
                }
            }
        }
    }
    public void OnMouseDown()
    {
        savedPosition = transform.position;
        if (!Data.pause)
        {
            isDragging = true;
            offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        }
        GameObject.Find("Manager").GetComponent<Manager>().PushDown(this.name);
    }

    public void OnMouseUp()
    {
        inPlace = false;
        isDragging = false;
        offsetSmall = new Vector2();
        if (transform.position == savedPosition && isBig && !Data.mapCollidersActive)
        {
            GetComponent<SpriteRenderer>().sprite = mapBig;
            Data.mapCollidersActive = true;
        }
        GameObject.Find("Manager").GetComponent<Manager>().resetZ();
    }

    public void click(string country)
    {
        if (country == "BiH")
        {
            GetComponent<SpriteRenderer>().sprite = BiH;
        }
        else if (country == "Hr")
        {
            GetComponent<SpriteRenderer>().sprite = Hr;
        }
        else if (country == "Srb")
        {
            GetComponent<SpriteRenderer>().sprite = Srb;
        }
        else if (country == "MNE")
        {
            GetComponent<SpriteRenderer>().sprite = MNE;
        }
        else if (country == "Slo")
        {
            GetComponent<SpriteRenderer>().sprite = Slo;
        }
        else if (country == "Mk")
        {
            GetComponent<SpriteRenderer>().sprite = Mk;
        }
    }
}