using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonCH21A : MonoBehaviour
{
    bool isTimerOn = false;
    float delta = 0;
    float span = 2;
    GameObject player;
    GameObject timer;
    GameObject ButtonCH2A;
    private void Start()
    {
        player = GameObject.Find("Player");
        timer = GameObject.Find("ImageTimer");
        ButtonCH2A = GameObject.Find("ButtonCH2A");
    }
    void Update()
    {
        if (isTimerOn == true)
        {
            delta += Time.deltaTime;
            timer.GetComponent<Image>().fillAmount = delta / span;
            if (delta > span)
            {
                player.GetComponent<PlayerControl>().GotoCh2of1();
                ButtonCH2A.GetComponent<dialogueTrigger>().Trigger();
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
