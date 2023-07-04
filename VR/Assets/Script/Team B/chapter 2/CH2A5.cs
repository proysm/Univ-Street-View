using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CH2A5 : MonoBehaviour
{
    bool isTimerOn = false;
    float delta = 0;
    float span = 2;
    GameObject player;
    GameObject timer;
    GameObject ButtonCH2A5;
    private void Start()
    {
        player = GameObject.Find("Player");
        timer = GameObject.Find("ImageTimer");
        ButtonCH2A5 = GameObject.Find("ButtonCH2A5");
    }
    void Update()
    {
        if (isTimerOn == true)
        {
            delta += Time.deltaTime;
            timer.GetComponent<Image>().fillAmount = delta / span;
            if (delta > span)
            {
                player.GetComponent<PlayerControl>().NextPic();
                ButtonCH2A5.GetComponent<dialogueTrigger>().Trigger();
            }

        }
        else
        {


        }
    }
    public void GazeStart()
    {
        isTimerOn = true;
    }
    public void GazeEnd()
    {
        isTimerOn = false;
        delta = 0;
        timer.GetComponent<Image>().fillAmount = 0;
    }
}
