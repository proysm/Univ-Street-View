using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon_Ch2 : MonoBehaviour
{
    public void GotoCh2of1()
    {
        transform.position = new Vector3(0, 60, 0);
    }

    public void GotoCh2of2()
    {
        transform.position = new Vector3(0, 60, 30);
    }

    public void NextPic()
    {
        transform.Translate(30, 0, 0);
    }
}
