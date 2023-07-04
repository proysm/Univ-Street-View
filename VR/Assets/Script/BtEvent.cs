using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtEvent : MonoBehaviour
{
    public GameObject panel;
    public GameObject cam;

    public void TouchBt()
    {
        cam.transform.position = Vector3.zero;
        panel.SetActive(true);
    }
}