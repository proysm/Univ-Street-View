using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    private Touch initTouch = new Touch();
    public Camera cam;
    private float rotx = 0f;
    private float roty = 0f;
    private Vector3 origRot;

    public float rotSpeed = 0.5f;
    public float dir = -1;
    // Start is called before the first frame update
    void Start()
    {
        origRot = cam.transform.eulerAngles;
        rotx = origRot.x;
        roty = origRot.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (Touch touch in Input.touches) {
            if (touch.phase == TouchPhase.Began) {
                initTouch = touch;
            }
            else if (touch.phase == TouchPhase.Moved) {
                float deltaX = initTouch.position.x - touch.position.x;
                float deltaY = initTouch.position.y - touch.position.y;
                rotx -= deltaY * Time.deltaTime * rotSpeed * dir;
                roty += deltaX * Time.deltaTime * rotSpeed * dir;
                cam.transform.eulerAngles = new Vector3(rotx, roty, 0f);
            }
            else if (touch.phase == TouchPhase.Ended) {
                initTouch = new Touch();
            }
        }
    }
}
