using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleController : Photon.MonoBehaviour {
    Animator _anim;
    Rigidbody _rb;

	void Start () {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
	}
	
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag== "Player")
        {
            CancelInvoke("ExitCollision");
            _anim.enabled = false;
            _rb.isKinematic = true;
        }
        
    }
    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Invoke("ExitCollision", 0.5f);
        }
    }
    void ExitCollision()
    {
        _anim.enabled = true;
        _rb.isKinematic = false;
    }

    public void YouDie()
    {
        if (GetComponent<PhotonView>() != null)
            photonView.RPC("DeadRPC", PhotonTargets.AllBuffered);
        else
            Dead();
    }

    [PunRPC]
    void DeadRPC ()
    {
        if (GetComponent<PedestrianObject>() != null)
            GetComponent<PedestrianObject>().enabled = false;

        _anim.applyRootMotion = true;
        _anim.SetTrigger("Die");
        Destroy(gameObject, 5);
    }

    void Dead()
    {
        if (GetComponent<PedestrianObject>() != null)
            GetComponent<PedestrianObject>().enabled = false;

        _anim.applyRootMotion = true;
        _anim.SetTrigger("Die");
        Destroy(gameObject, 5);
    }
}
