using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour {
    public bool isPolice;
    public GameObject[] models;
    public bool[] isVip;

    public void ChangeModel(int value, bool police)
    {
        for (int i = 0; i < models.Length; i++)
        {
            models[i].SetActive(false);
        }

        if (police)
        {
            playerData.SINGLETON.idPolice = value;
        }
        else {
            playerData.SINGLETON.idCriminal = value;
        }

        models[value].SetActive(true);
    }
}
