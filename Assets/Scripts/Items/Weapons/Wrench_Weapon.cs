using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrench_Weapon : BaseWeapon {

    public AudioPlay AP;
    public Animator anim;

    private void Awake()
    {
    }

    public override void Attack()
    {
        if (!attackFinished)
            return;
        anim.Play("Melee_Attack", 1);
        attackFinished = false;
    }

    public void DealDamage(BaseEnemy enemy)
    {
        AP.PlayHit();
        enemy.TakeDamage(Damage);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    print("Collision");
    //    BaseEnemy enemy = collision.GetComponent<BaseEnemy>();
    //    if (enemy == null || !attackFinished)
    //        return;
    //    enemy.TakeDamage(Damage);
    //    attackFinished = false;
    //}
}
