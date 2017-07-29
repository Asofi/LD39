using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class SmoothCameraFlollow : MonoBehaviour {

    public Transform Target;

    public float SmoothTimeX = 1f;
    public float SmoothTimeY = 1f;

    public Vector3 Offset;

    private Vector3 velocity = Vector3.zero;

    public bool Bounded;

    public Vector2 minCamPos;
    public Vector2 maxCamPos;

    // Use this for initialization
    void Awake () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if (Target == null)
            return;

        float posX = Mathf.SmoothDamp(transform.position.x, Target.transform.position.x, ref velocity.x, SmoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, Target.transform.position.y, ref velocity.y, SmoothTimeY);

        transform.position = new Vector3(posX, posY, transform.position.z);

        if (Bounded)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCamPos.x, maxCamPos.x),
                                                Mathf.Clamp(transform.position.y, minCamPos.y, maxCamPos.y),
                                                transform.position.z);
        }
    }
}
