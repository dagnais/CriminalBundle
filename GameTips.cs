using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTips : MonoBehaviour {
    public Text textTip;
    string[] tips;

	void Awake () {
        tips = new string[6];
        tips[0] = "Press B to change the shooting mode.";
        tips[1] = "Press C to crouch.";
        tips[2] = "Press M to change class.";
        tips[3] = "Press Tab to see scoreboard.";
        tips[4] = "Press Escape to see options.";
        tips[5] = "Press control + w + r to switch fullscreen.";
        int rnd = Random.Range(0, 6);
        textTip.text = tips[rnd];
    }
}
