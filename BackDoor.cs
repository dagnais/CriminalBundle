using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExitGames.Client.Photon;

public class BackDoor : Photon.MonoBehaviour
{
    public GameObject UI;
    public Text Counter;
    public float timerOpenRetard = 300f;
    private bool open = false;
    public Animator anim;

    void OnTriggerStay(Collider colr)
    {
        if (colr.tag == "Player")
        {
            timerOpenRetard -= Time.deltaTime;
            photonView.RPC("OpenDoorTimeRPC", PhotonTargets.AllBuffered, timerOpenRetard);
            if (open == false)
            {
                UI.SetActive(true);
            }
            if (timerOpenRetard < 0)
            {
                if (open == false)
                {
                    photonView.RPC("OpenDoorRPC", PhotonTargets.AllBuffered);
                }
            }
        }
    }

    [PunRPC]
    void OpenDoorRPC()
    {
        print("Han abierto la puerta");
        UI.SetActive(false);
        open = true;
        print("animacion");
        GetComponent<AudioSource>().Play();
        anim.enabled = true;
    }

    [PunRPC]
    void OpenDoorTimeRPC(float t)
    {
        Counter.text = Mathf.Round(t).ToString();
    }

    void OnTriggerExit(Collider colr)
    {
        UI.SetActive(false);
    }
}
