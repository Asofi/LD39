using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAim : MonoBehaviour {
    public Transform GunIK;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GunIK.transform.position = (Vector2)newPos;
        //Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //diff.Normalize();

        //float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }
}
