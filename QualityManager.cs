using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class QualityManager : MonoBehaviour {
    public Light sun;
    public GameObject[] interiorLight;
    public GameObject[] details;
    private int currentQuality;
    private PedestrianObject[] people;

    void Start () {
        people = FindObjectsOfType<PedestrianObject>();  
    }
	
    public void LoadQuality()
    {
        FindObjectOfType<bl_UIReferences>().LoadQualityOptions();
        ChangeQuality();
    }

	void Update () {
		if(Input.GetKeyUp(KeyCode.Alpha0) && Input.GetKeyUp(KeyCode.Z))
        {
            foreach (GameObject item in details)
            {
                if (item != null)
                    item.SetActive(!item.activeInHierarchy);
            }
        }
        CheckQuality();
        
	}

    void ChangeQuality()
    {
        currentQuality = QualitySettings.GetQualityLevel();
        switch(currentQuality)
        {
            case 0:
                sun.shadows = LightShadows.None;
                sun.shadowResolution = UnityEngine.Rendering.LightShadowResolution.Low;
                if (Camera.main != null)
                    Camera.main.farClipPlane = 100;
                break;
            case 1:
                sun.shadows = LightShadows.None;
                sun.shadowResolution = UnityEngine.Rendering.LightShadowResolution.Low;
                if (Camera.main != null)
                    Camera.main.farClipPlane = 110;
                break;
            case 2:
                sun.shadows = LightShadows.None;
                sun.shadowResolution = UnityEngine.Rendering.LightShadowResolution.Low;
                if (Camera.main != null)
                    Camera.main.farClipPlane = 120;
                break;
            case 3:
                sun.shadows = LightShadows.Hard;
                sun.shadowResolution = UnityEngine.Rendering.LightShadowResolution.Low;
                if (Camera.main != null)
                    Camera.main.farClipPlane = 135;
                break;
            case 4:
                sun.shadows = LightShadows.Soft;
                sun.shadowResolution = UnityEngine.Rendering.LightShadowResolution.Low;
                if (Camera.main != null)
                    Camera.main.farClipPlane = 150;
                break;
            case 5:
                sun.shadows = LightShadows.Soft;
                sun.shadowResolution = UnityEngine.Rendering.LightShadowResolution.VeryHigh;
                if(Camera.main != null)
                    Camera.main.farClipPlane = 300;
                break;
        }

        if (QualitySettings.GetQualityLevel() >= 3)
        {
            foreach (GameObject item in interiorLight)
            {
                item.SetActive(true);
            }
            foreach (GameObject item in details)
            {
                if (item != null)
                    item.SetActive(true);
            }

            foreach (PedestrianObject item in people)
            {
                if(item!= null)
                    item.gameObject.SetActive(true);
            }

            PostProcessingBehaviour[] cameras = FindObjectsOfType<PostProcessingBehaviour>();
            foreach (PostProcessingBehaviour item in cameras)
            {
                if (item != null)
                    item.enabled = true;
            }
        }

        if (QualitySettings.GetQualityLevel() <= 2)
        {
            foreach (GameObject item in interiorLight)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in details)
            {
                if (item != null)
                    item.SetActive(false);
            }

            foreach (PedestrianObject item in people)
            {
                if (item != null)
                    item.gameObject.SetActive(false);
            }

            PostProcessingBehaviour[] cameras = FindObjectsOfType<PostProcessingBehaviour>();
            foreach (PostProcessingBehaviour item in cameras)
            {
                if (item != null)
                    item.enabled = false;
            }
        }
    }
    
    void CheckQuality()
    {
        if (QualitySettings.GetQualityLevel() != currentQuality)
        {
            ChangeQuality();
        }
    }

}
