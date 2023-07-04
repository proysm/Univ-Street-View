using UnityEngine;
using UnityEngine.UI;

public class Button_Select_typeA : MonoBehaviour
{
    bool isTimerOn = false;
    float delta = 0;
    float span = 2;
    GameObject player;
    GameObject timer;
    public GameObject Map;

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
               
                player.GetComponent<PlayerControl>().GotoTypeA();

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
