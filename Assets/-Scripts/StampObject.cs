using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampObject : MonoBehaviour
{
    private bool isStamping = false;
    private bool isDragging = false;
    private bool isBig = false;
    private bool direction = false;
    private float currenty;
    private Vector2 mousePosition;
    private Vector2 offset;
    private Vector2 offsetBig = new Vector2(0f, 0.6f);
    private Vector2 offsetSmall = new Vector2();
    public Sprite stampBig;
    public Sprite stampSmall;
    public PolygonCollider2D ColliderBig;
    public BoxCollider2D ColliderStamp;
    public Transform stamp;
    private AudioSource thump;
    private float movex;
    private float movey;
    private float WindowTableBorder = -3.41f;

    private float BorderWindowBorder = 1.33f;
    private float BottomWindowBorder = -3.5f;
    private float locationx = -4.005f;
    private float locationy = -2.025f;
    private float stampSpeed = 7f;
    private float speedx = 0.3f;
    private float speedy = 0.16875f;

    // Start is called before the first frame update
    void Start()
    {
        thump = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isDragging && !isStamping && !Data.pause)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition - offset;
        }
        if (isDragging && !isBig)
        {
            GetComponent<SpriteRenderer>().sortingLayerName = "Stamp Small Move";
        }
        else if (!isDragging && !isBig)
        {
            GetComponent<SpriteRenderer>().sortingLayerName = "Stamp Small";
        }
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > WindowTableBorder && transform.position.x > WindowTableBorder && !isBig)
        {
            offsetSmall = offset;
            GetComponent<SpriteRenderer>().sprite = stampBig;
            ColliderBig.enabled = true;
            ColliderStamp.enabled = true;
            offset = offsetBig;
            GetComponent<SpriteRenderer>().sortingLayerName = "Stamp Big";
            isBig = true;
        }
        else if (transform.position.x < WindowTableBorder && isBig)
        {
            GetComponent<SpriteRenderer>().sprite = stampSmall;
            ColliderBig.enabled = false;
            ColliderStamp.enabled = false;
            offset = offsetSmall;
            isBig = false;
        }
        if (!isBig && transform.position.y > BorderWindowBorder)
        {
            transform.position = new Vector2(transform.position.x, BorderWindowBorder);
        }
        if (!isBig && transform.position.y < BottomWindowBorder)
        {
            transform.position = new Vector2(transform.position.x, BottomWindowBorder);
        }
        if (transform.position != new Vector3(locationx, locationy, 0f) && !isDragging && !isStamping && !Data.pause)
        {
            movex = speedx * 100 * Time.deltaTime;
            movey = speedy * 100 * Time.deltaTime;
            if (transform.position.x > locationx + movex)
            {
                transform.position = new Vector3(transform.position.x - movex, transform.position.y, 0f);
            }
            else if (transform.position.x < locationx - movex)
            {
                transform.position = new Vector3(transform.position.x + movex, transform.position.y, 0f);
            }
            if (transform.position.y > locationy + movey)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - movey, 0f);
            }
            else if (transform.position.y < locationy - movey)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + movey, 0f);
            }
        }
        if (!isDragging && transform.position.x < locationx + movex && transform.position.x > locationx - movex && transform.position.y < locationy + movey && transform.position.y > locationy - movey)
        {
            transform.position = new Vector3(locationx, locationy, 0f);
        }
        if (GameObject.Find("Passport") != null && Input.GetMouseButtonDown(1) && !Data.pause && isDragging && isBig && GetComponent<BoxCollider2D>().bounds.Intersects(GameObject.Find("Passport").GetComponent<Passport>().ColliderBig.bounds))
        {
            thump.Play();
            currenty = transform.position.y;
            isStamping = true;
            direction = false;
        }
        if (isStamping)
        {
            if (transform.position.y <= currenty - 0.3)
            {
                direction = true;
                Instantiate(stamp, new Vector3(transform.position.x, transform.position.y - 0.7f, 0f), Quaternion.identity, GameObject.Find("Passport").transform).name = "Stamp";
                transform.position = new Vector3(transform.position.x, transform.position.y + stampSpeed * Time.deltaTime, 0f);
            }
            if (!direction)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - stampSpeed * Time.deltaTime, 0f);
            }
            else if (direction)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + stampSpeed * Time.deltaTime, 0f);
            }
            if (transform.position.y >= currenty)
            {
                isStamping = false;
            }
        }
    }
    public void OnMouseDown()
    {
        if (!Data.pause)
        {
            isDragging = true;
            offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        }
    }

    public void OnMouseUp()
    {
        isDragging = false;
        offsetSmall = new Vector2();
    }
}