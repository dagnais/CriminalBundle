using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModifyHUDGranade : MonoBehaviour {
    public int value;
    public Text textBullet;
    public bl_Gun gun;
	void Start () {
        textBullet = GameObject.FindGameObjectWithTag("ShowAmmo").GetComponent<Text>();
	}
	
}
