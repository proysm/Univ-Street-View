using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueTrigger : MonoBehaviour
{
    public dialogue info;

    public void Trigger()
    {
        var system = FindObjectOfType<dialogueSystem>();
        system.Begin(info);
    }
}
