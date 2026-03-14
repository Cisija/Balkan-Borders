using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentSortingLayerImage : MonoBehaviour
{
    void Update()
    {
        GetComponent<SpriteRenderer>().sortingLayerName=transform.parent.transform.parent.GetComponent<SpriteRenderer>().sortingLayerName[0].ToString();
    }
}
