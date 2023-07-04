using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;

public class BackEndInitialize : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        var bro = Backend.Initialize(true);
    }

}
