using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCustom : Photon.MonoBehaviour {
    public bool isPolice;
    public int idPolice, idCriminal, idMask, idGunPolice, idGunCriminal;
    public GameObject[] policeModel, criminalModel, maskModel;
    public Transform pointMask;
    private bool Sync = true;
    private int co = 0;

    void Start () {

        if (photonView.isMine)
            LoadData();
        else
            LoadConfig();
    }

    private void Update()
    {
        if(Sync)
            LoadConfig();  co++;
    }

    public void LoadConfig()
    {
        LoadPoliceModel();
        LoadCriminalModel();
        LoadMask();
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(isPolice);
            stream.SendNext(idPolice);
            stream.SendNext(idCriminal);
            stream.SendNext(idMask);
        }
        else
        {
            isPolice = (bool)stream.ReceiveNext();
            idPolice = (int)stream.ReceiveNext();
            idCriminal = (int)stream.ReceiveNext();
            idMask = (int)stream.ReceiveNext();
        }

        if (co > 3) {
            Sync = false;
        }
    }

    void LoadData()
    {
        idPolice = playerData.SINGLETON.idPolice;
        idCriminal = playerData.SINGLETON.idCriminal;
        idMask = playerData.SINGLETON.idMask;
        idGunPolice = playerData.SINGLETON.idGunPolice;
        idGunCriminal = playerData.SINGLETON.idGunCriminal;
    }

    void LoadPoliceModel()
    {
        if (isPolice) {

            foreach (var item in policeModel)
            {
                item.SetActive(false);
            }
            policeModel[idPolice].SetActive(true);

        }

    }

    void LoadCriminalModel()
    {
        if (!isPolice)
        {
            foreach (var item in criminalModel)
            {
                item.SetActive(false);
            }
            criminalModel[idCriminal].SetActive(true);
        }
    }

    void LoadMask()
    {
        if (!isPolice) {

            Destroy(pointMask.transform.GetChild(0).gameObject);
            GameObject obj = Instantiate(maskModel[idMask], pointMask.position, pointMask.rotation);
            obj.transform.parent = pointMask;
        }
    }
}
