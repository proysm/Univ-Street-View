using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Goto_Main2 : MonoBehaviour
{
    bool isTimerOn = false;
    float delta = 0;
    float span = 2;
    GameObject player;
    GameObject timer;

    private void Start()
    {
        player = GameObject.Find("Player");
        timer = GameObject.Find("ImageTimer");

    }


    // Update is called once per frame
    void Update()
    {
        if (isTimerOn == true)
        {
            delta += Time.deltaTime;
            timer.GetComponent<Image>().fillAmount = delta / span;
            if (delta > span)
            {
                player.GetComponent<PlayerControl>().GotoMain2();
            }
        }
        else
        {
            delta = 0;
            timer.GetComponent<Image>().fillAmount = 0;
        }
    }

    public void GazeStart()
    {
        isTimerOn = true;
    }
    public void GazeEnd()
    {
        isTimerOn = false;
    }
}
