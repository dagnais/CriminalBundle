using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarManager : MonoBehaviour {
    bool _isRadar=true;
    HWRComponent.RadarSystem _radar;

    void Start () {
        _radar = GetComponent<HWRComponent.RadarSystem>();	
	}
	
	void Update () {
        if (Input.GetKeyUp(KeyCode.O))
        {
            _isRadar = !_isRadar;
            _radar.enabled = _isRadar;
        }
    }
}
