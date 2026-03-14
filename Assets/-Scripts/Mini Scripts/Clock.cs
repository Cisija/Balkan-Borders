using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    private TextMesh hour;

    private TextMesh min;

    private string mins;

    private string hours;

    // Start is called before the first frame update
    void Start()
    {
        Data.h = 6;
        Data.m = 0;
        hour = GetComponent<TextMesh>();
        min = GameObject.Find("Minutes").GetComponent<TextMesh>();
        hour.text="06";
        min.text="00";
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            Data.h++;
        }*/
        if (!Data.pause && Data.start)
        {
            if (Mathf.Round(Data.m) > 59)
            {
                Data.h++;
                Data.m = 0;
            }
            Data.m = Data.m + 2 * Time.deltaTime;
            if (Mathf.Round(Data.m) == 0)
            {
                mins = "00";
            }
            else if (Mathf.Round(Data.m) < 10)
            {
                mins = "0" + Mathf.Round(Data.m).ToString();
            }
            else
            {
                mins = Mathf.Round(Data.m).ToString();
            }
            if (Mathf.Round(Data.h) < 10)
            {
                hours = "0" + Mathf.Round(Data.h).ToString();
            }
            else
            {
                hours = Mathf.Round(Data.h).ToString();
            }
            hour.text = hours;
            min.text = mins;
        }
    }
}
