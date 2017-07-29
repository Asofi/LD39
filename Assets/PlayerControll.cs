using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerControll : MonoBehaviour {

    PlayerMotor motor;

	// Use this for initialization
	void Awake () {
        motor = GetComponent<PlayerMotor>();
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
