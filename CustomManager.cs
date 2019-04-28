using UnityEngine;
using UnityEngine.UI;

public class CustomManager : MonoBehaviour {
    public int policeId, criminalId, maskId;
    public PlayerSelect police, criminal;
    public Dropdown gunPolice, gunCriminal;
    public GameObject vipPolice, vipCriminal, vipMask;
    public Transform[] criminalMasks, pointMasks;
    public bool[] isVipMask;

	void Start () {
        Camera.main.transform.position = new Vector3(1.6f, 18.5f, -6.77f);
        Camera.main.transform.eulerAngles = new Vector3(15, 0, 0);
        playerData.SINGLETON.Load();

        police.ChangeModel(playerData.SINGLETON.idPolice, true);
        criminal.ChangeModel(playerData.SINGLETON.idCriminal, false);
        maskId = playerData.SINGLETON.idMask - 1;
        NextMask();
        gunPolice.value = playerData.SINGLETON.idGunPolice;
        gunCriminal.value = playerData.SINGLETON.idGunCriminal;
    }

    public void NextCriminal()
    {
        criminalId++;
        if (criminalId == criminal.models.Length)
            criminalId = 0;
        criminal.ChangeModel(criminalId, false);
    }

    public void BackCriminal()
    {
        criminalId--;
        if (criminalId == -1)
            criminalId = criminal.models.Length -1;
        criminal.ChangeModel(criminalId, false);
 
    }

    public void NextPolice()
    {
        policeId++;
        if (policeId == police.models.Length)
            policeId = 0;
        police.ChangeModel(policeId, true);

        playerData.SINGLETON.Save();
    }

    public void BackPolice()
    {
        policeId--;
        if (policeId == -1)
            policeId = police.models.Length - 1;
        police.ChangeModel(policeId, true);
        playerData.SINGLETON.Save();

    }

    public void NextMask()
    {
        maskId++;
        if (maskId == criminalMasks.Length)
            maskId = 0;
        for (int i = 0; i < criminal.models.Length; i++)
        {
            Destroy(pointMasks[i].GetChild(0).gameObject);
            Transform obj = Instantiate(criminalMasks[maskId], pointMasks[i].position, pointMasks[i].rotation);
            obj.transform.parent = pointMasks[i];
        }
        playerData.SINGLETON.idMask = maskId;
        playerData.SINGLETON.Save();
    }

    public void BackMask()
    {
        maskId--;
        if (maskId ==  -1)
            maskId = criminalMasks.Length - 1;
        for (int i = 0; i < criminal.models.Length; i++)
        {
            Destroy(pointMasks[i].GetChild(0).gameObject);
            Transform obj = Instantiate(criminalMasks[maskId], pointMasks[i].position, pointMasks[i].rotation);
            obj.transform.parent = pointMasks[i];
        }
        playerData.SINGLETON.idMask = maskId;
        playerData.SINGLETON.Save();
    }

    public void ChangeGunPolice()
    {
        playerData.SINGLETON.idGunPolice = gunPolice.value;
        playerData.SINGLETON.Save();
    }

    public void ChangeGunCriminal()
    {
        playerData.SINGLETON.idGunCriminal = gunCriminal.value;
        playerData.SINGLETON.Save();
    }

}
