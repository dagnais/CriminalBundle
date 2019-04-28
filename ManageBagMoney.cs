using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageBagMoney : Photon.MonoBehaviour {
    public Transform carTarget;
    public Transform[] spawnsTarget;
    private Transform cross;
    private bool isBagActive;

    void Start () {
        if (playerData.SINGLETON.IsOwner)
        {
            GenerateRandom();
        }
    }
	
	void Update () {
		if(isBagActive)
        {
            if(cross!= null)
                cross.LookAt(carTarget);
        }
	}

    public void RefreshState(bool value , Transform crossValue)
    {
        isBagActive = value;
        cross = crossValue;
    }

    [PunRPC]
    public void SpawnCar(int idRnd)
    {
        Debug.Log("id:" + idRnd);
       
    }

    public void GenerateRandom()
    {
       int rnd = Random.Range(0, spawnsTarget.Length);
        carTarget.transform.position = spawnsTarget[rnd].position;
        carTarget.transform.rotation = spawnsTarget[rnd].rotation;
    }
}
