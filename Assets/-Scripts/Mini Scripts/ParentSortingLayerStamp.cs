using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentSortingLayerStamp : MonoBehaviour
{
    void Update()
    {
        GetComponent<SpriteRenderer>().sortingLayerName=transform.parent.GetComponent<SpriteRenderer>().sortingLayerName[0].ToString();
    }
}
