using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public class BaseEnemy : MonoBehaviour {

    private float health;
    public float MaxHealth = 100;

    public float Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;
        }
    }

    private void Awake()
    {
        Health = MaxHealth;
    }

    public void TakeDamage(float dmg)
    {
        print(name + " takes " + dmg + " damage!");
        Health = Mathf.Clamp(Health - dmg, 0, MaxHealth);
        if (Health == 0)
            print(gameObject.name + " IS DEAD!");
    }
}
