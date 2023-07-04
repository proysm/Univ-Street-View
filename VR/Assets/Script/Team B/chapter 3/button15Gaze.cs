using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button15Gaze : MonoBehaviour
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
    void Update()
    {
        if (isTimerOn == true)
        {
            delta += Time.deltaTime;
            timer.GetComponent<Image>().fillAmount = delta / span;
            if (delta > span)
            {
                player.GetComponent<PlayerControl>().GotoB16();
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