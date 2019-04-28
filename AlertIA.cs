using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertIA : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IAController>() != null)
        {
            if (GetComponent<bl_PlayerSettings>().m_Team == Team.Recon)
            {
                other.gameObject.GetComponent<IAController>().GetAlertIA();
            }
        }
    }
}
