using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonManager : MonoBehaviour {
    public GameObject[] polygon;

    private void Start()
    {
        for (int i = 0; i < polygon.Length; i++)
        {
                polygon[i].SetActive(false);
        }
    }

    public void ChangeState(bool value)
    {
        for (int i = 0; i < polygon.Length; i++)
        {
            if (polygon[i].activeInHierarchy != value)
                polygon[i].SetActive(value);
        }
        
    }
}
