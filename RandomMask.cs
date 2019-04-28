using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMask : MonoBehaviour {
    public GameObject[] masks;
    public int rnd;

	void Start () {
        masks = new GameObject[transform.childCount];
        if(masks.Length > 0)
        {
            for (int i = 0; i < masks.Length; i++)
            {
                masks[i] = transform.GetChild(i).gameObject;
                masks[i].SetActive(false);
            }
            rnd = Random.Range(0, transform.childCount);
            masks[rnd].SetActive(true);
        }
	}
}
