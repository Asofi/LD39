using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour {
    public GameObject[] Parts;

    public float Damage = 50;
    public float timeBetweenShots = 0.2f;

    protected bool attackFinished = true;

    public virtual void Attack() {}

    public void FinishAttack()
    {
        attackFinished = true;
    }

    public void Activate(bool flag)
    {
        foreach(GameObject gm in Parts)
        {
            gm.SetActive(flag);
        }
    }
}
