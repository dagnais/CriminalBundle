using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAController : Photon.MonoBehaviour {
    public GameObject[] agents;
    public GameObject characters;
	void Start () {
        if(characters != null)
        {
            GetCharacters();
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<bl_PlayerSettings>()!= null)
        {
            if (other.GetComponent<bl_PlayerSettings>().m_Team == Team.Recon)
            {
                photonView.RPC("AlertIA", PhotonTargets.AllBuffered);
            }
        }
    }


    public void GetAlertIA()
    {
        foreach (GameObject item in agents)
        {
            item.GetComponent<BoxCollider>().center = new Vector3(0, 0.57f, 0);
            item.GetComponent<BoxCollider>().size = new Vector3(1, 1, 1);
            item.GetComponent<Animator>().SetTrigger("Attack");
        }
        enabled = false;
    }

    void GetCharacters()
    {
        agents = new GameObject[characters.transform.childCount];
        for (int i = 0; i < characters.transform.childCount; i++)
        {
            agents[i] = characters.transform.GetChild(i).gameObject;
        }
    }

    [PunRPC]
    public void AlertIA()
    {
        GetCharacters();
        GetAlertIA();
    }
}
