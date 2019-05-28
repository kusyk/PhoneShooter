using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletColorController : MonoBehaviour {


    private LineRenderer line;


    void Start ()
    {
        line = GetComponent<LineRenderer>();
    }
	


	void Update ()
    {
		if(ShotButton.isPressed || Input.GetKey(KeyCode.Space))
        {
            line.enabled = true;
        }
        else
        {
            line.enabled = false;
        }
    }
}
