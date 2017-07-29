using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Motor))]
public class PlayerControll : MonoBehaviour {

    Motor motor;

	// Use this for initialization
	void Awake () {
        motor = GetComponent<Motor>();
	}

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            motor.Jump();
        }
    }

    private void FixedUpdate()
    {
        motor.Move(Input.GetAxis("Horizontal"), Input.GetKey(KeyCode.LeftShift) ? true : false);
    }

    public void InteractWithItem()
    {

    }
}
