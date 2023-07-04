using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class VRModeContorl : MonoBehaviour
{
    public GameObject TouchControl;
    public void StreoView() {
        StartCoroutine(LoadDevice("Cardboard"));
        TouchControl.SetActive(false);
    }
    IEnumerator LoadDevice(string newwDevice) {
        XRSettings.LoadDeviceByName(newwDevice);
        yield return null;
        XRSettings.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            StartCoroutine(LoadDevice("None"));
            TouchControl.SetActive(true);
        }
    }
}
