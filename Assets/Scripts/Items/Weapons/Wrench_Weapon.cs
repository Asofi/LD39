using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrench_Weapon : BaseWeapon {

    public float Damage;

    public Animator anim;

    private void Awake()
    {
    }

    public override void Attack()
    {
        if (!attackFinished)
            return;
        anim.Play("WrenchAttack");
    }

    public void DealDamage(BaseEnemy enemy)
    {
        if (!attackFinished)
            return;
        enemy.TakeDamage(Damage);
        attackFinished = false;
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
