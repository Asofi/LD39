using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Motor : MonoBehaviour {

    public Transform GFX;
    public float Speed = 200f;
    public float MaxYSpeed = 10;
    public float JumpForce = 200f;

    public bool isPlayer = false;

    Rigidbody2D m_RB;

	// Use this for initialization
	void Awake () {
        m_RB = GetComponent<Rigidbody2D>();
	}

    public void Move(float dir, bool sprint = false)
    {
        if (isPlayer)
        {
            float newVelocity = dir * Speed * Time.deltaTime * (sprint ? 1.5f : 1);
            m_RB.velocity = new Vector2(newVelocity, Mathf.Clamp(m_RB.velocity.y, -10, 10));

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (mousePos.x > transform.position.x)
                GFX.localEulerAngles = Vector2.zero;
            if (mousePos.x < transform.position.x)
                GFX.localEulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            float newVelocity = dir * Speed;
            m_RB.velocity = new Vector2(newVelocity, Mathf.Clamp(m_RB.velocity.y, -10, 10));

            if (dir > 0)
                GFX.localEulerAngles = Vector2.zero;
            if (dir < 0)
                GFX.localEulerAngles = new Vector3(0, 180, 0);
        }
    }

    public void Jump()
    {
        if (GroundCheck.Grounded)
        {
            m_RB.AddForce(Vector2.up * JumpForce);
        }
    }
	
}
