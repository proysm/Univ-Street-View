using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtEventOff : MonoBehaviour
{
    public GameObject panel;
    public GameObject cam;

    public void TouchBt()
    {
        cam.transform.position = new Vector3(-60,0,0);
        panel.SetActive(false);
    }
}