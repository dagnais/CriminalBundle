using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<SecuryCameraController>() != null)
        {
            other.GetComponent<SecuryCameraController>().ActiveCamera(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Stair")
        {
            if(Input.GetKeyUp(KeyCode.E))
            {
                other.GetComponent<UpStair>().UpStairAction(transform);
            }
            Vector3 dif = transform.forward - other.transform.forward;
            if (dif.magnitude < 0.1f)
            {
                other.GetComponent<UpStair>().UpStairAction(transform);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<SecuryCameraController>() != null)
        {
            other.GetComponent<SecuryCameraController>().ActiveCamera(false);
        }
    }
}
