using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CH2end : MonoBehaviour
{
    bool isTimerOn = false;
    float delta = 0;
    float span = 2;
    GameObject player;
    GameObject timer;
    GameObject dialogueSystem;
    private void Start()
    {
        player = GameObject.Find("Player");
        timer = GameObject.Find("ImageTimer");
        dialogueSystem = GameObject.Find("dialogueSystem");
    }
    void Update()
    {
        if (isTimerOn == true)
        {
            delta += Time.deltaTime;
            timer.GetComponent<Image>().fillAmount = delta / span;
            if (delta > span)
            {
                player.GetComponent<PlayerControl>().GotoCh2();
                dialogueSystem.GetComponent<dialogueSystem>().End();
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
