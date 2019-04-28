using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copyrightController : MonoBehaviour {
    public GameObject refer;

	void Start () {
        gameObject.SetActive(refer.activeInHierarchy);
	}
	
}
