using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class TrumpController : MonoBehaviour
{

    private Rigidbody rb;
    private Animation anim;
    public Joystick joystick;
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animation>();
        GameObject objJoystick = GameObject.FindGameObjectWithTag("Fixed Joystick");
        joystick = objJoystick.GetComponent<Joystick>();

    }

    // Update is called once per frame
    void Update()
    {
        
        float x = joystick.Horizontal;
        float y = joystick.Vertical;

        //Debug.Log("x is :" + x);

        Vector3 movement = new Vector3(x, 0, y);

        rb.velocity = movement * 3f;

        if (x != 0 && y != 0)
        {
            //Debug.Log("should be moving");
            transform.eulerAngles = new Vector3(transform.eulerAngles.x,
                Mathf.Atan2(x, y) * Mathf.Rad2Deg, transform.eulerAngles.z);
        }

        if (x != 0 || y != 0)
        {
            anim.Play("walk");
        }
        else
        {
            anim.Play("idle");
        }
    }
}
