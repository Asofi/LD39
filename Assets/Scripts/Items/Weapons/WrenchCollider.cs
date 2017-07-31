using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrenchCollider : MonoBehaviour {

    Wrench_Weapon ww;
    Collider2D col;

    private void Awake()
    {
        ww = transform.parent.GetComponent<Wrench_Weapon>();
        //col = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BaseEnemy enemy = collision.GetComponent<BaseEnemy>();
        if (enemy == null)
            return;
        ww.DealDamage(enemy);
    }

    public void FinishAttack()
    {
        ww.FinishAttack();
    }

    public void TurnOffCollider()
    {
        col.enabled = false;
    }

    public void TurnOnCollider()
    {
        col.enabled = true;
    }

}
