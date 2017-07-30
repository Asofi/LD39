using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(CapsuleCollider2D))]
public class BaseEnemy : MonoBehaviour {

    public RectTransform HealthBar;

    protected Rigidbody2D m_RB;
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
            if(value >= 0)
            {
                transform.DOKill();
                health = value;
                HealthBar.DOScaleX(health/MaxHealth, 0.1f).SetId(transform);
            }
        }
    }

    private void Awake()
    {
        Health = MaxHealth;
        m_RB = GetComponent<Rigidbody2D>();
    }

    public virtual void TakeDamage(float dmg)
    {
        print(name + " takes " + dmg + " damage!");
        Health = Mathf.Clamp(Health - dmg, 0, MaxHealth);
        if (Health == 0)
        {
            print(gameObject.name + " IS DEAD!");
            Death();
        }
    }

    public virtual void Death()
    {
        Destroy(gameObject);
    }
}
