using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Date : MonoBehaviour
{
    Generator gen;
    // Start is called before the first frame update
    void Start()
    {
        gen=GameObject.Find("Manager").GetComponent<Generator>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMesh>().text=gen.formatDate(Data.day)+"."+gen.formatDate(Data.month)+"."+Data.year+".";
    }
}