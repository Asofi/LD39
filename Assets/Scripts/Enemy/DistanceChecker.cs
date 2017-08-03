using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceChecker : MonoBehaviour {

    public float SeeDistance = 6f;
    public float AttackDistance = 4f;
    public float DistanceToPlayer;

    public bool isPlayerInside;
    public bool isPlayerVisible;
    public Transform Target;
    public LayerMask RaycastMask;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (!isPlayerInside)
        {
            Target = null;
            return;
        }
        else
        {
            if(Target != null)
            {
                DistanceToPlayer = Vector2.Distance(transform.position, Target.position);
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Target.position - transform.position, SeeDistance, RaycastMask);
                if (hit.collider != null)
                    isPlayerVisible = hit.collider.CompareTag("Player");
                else
                    isPlayerVisible = false;
            }
        }
        
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Target = collision.transform;
        isPlayerInside = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isPlayerVisible = false;
        isPlayerInside = false;
    }
}
