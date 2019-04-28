using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskSelect : MonoBehaviour {
    public GameObject[] masks;
    public bool[] isVip;

    void Awake()
    {
        masks = new GameObject[transform.childCount];
        if (masks.Length > 0)
        {
            for (int i = 0; i < masks.Length; i++)
            {
                masks[i] = transform.GetChild(i).gameObject;
                masks[i].SetActive(false);
            }
        }
    }

    public void ChangeMask(int value)
    {
        for (int i = 0; i < masks.Length; i++)
        {
            masks[i].SetActive(false);
        }
        masks[value].SetActive(true);
    }
}
