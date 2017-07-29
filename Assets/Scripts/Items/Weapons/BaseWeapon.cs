using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour {

    protected bool attackFinished = true;

    public virtual void Attack() {}

    public void FinishAttack()
    {
        attackFinished = true;
    }
}
