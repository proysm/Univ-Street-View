using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBoxControl : MonoBehaviour
{
    GameObject textBox1;
    bool textBox1view=false; // 초기값은 안보이게
    void Start()
    {
        textBox1 = GameObject.Find("Canvas_TextBox1");
    }

    public void ToggleDisplay()
    {
        if(textBox1view == false)
        {
            textBox1view = true;
            textBox1.SetActive(true);
            Debug.Log(textBox1view);
        }
        else
        {
            textBox1view = false;
            textBox1.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
