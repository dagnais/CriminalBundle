using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpStair : MonoBehaviour {
    public Transform connectObj;

    public void UpStairAction(Transform pj)
    {
        pj.position = connectObj.position;
    }
}
