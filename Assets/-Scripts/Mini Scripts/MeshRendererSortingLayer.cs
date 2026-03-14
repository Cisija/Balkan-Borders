using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshRendererSortingLayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().sortingOrder=1;
    }

    void Update()
    {
        GetComponent<MeshRenderer>().sortingLayerName=transform.parent.GetComponent<SpriteRenderer>().sortingLayerName[0].ToString();
    }
}
