using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowModel : MonoBehaviour {
    public float speed;

	void Update () {
        transform.Rotate(new Vector3(0,1 * speed * Time.deltaTime, 0));
	}
}
