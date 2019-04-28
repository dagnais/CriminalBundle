using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamInvite : MonoBehaviour {
    public GameObject panelInvite;

    public void Invite()
    {
        FindObjectOfType<DisplaySteam>().InviteAllFriends();
        panelInvite.SetActive(true);
        Invoke("HidePanel", 3);
    }
    void HidePanel()
    {
        panelInvite.SetActive(false);
    }
}
