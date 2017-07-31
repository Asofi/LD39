using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(CapsuleCollider2D))]
public class PlayerManager : MonoBehaviour {

    public static PlayerManager Instance;
    public Image HealthBar;
    public BubbleTalker Talker;
    public enum WeaponTypes
    {
        WRENCH,
        PISTOL
    }

    public WeaponTypes SelectedWeaponType;

    public BaseWeapon SelectedWeapon;

    public BaseWeapon[] Weapons;

    private float health;
    public float MaxHealth = 100;

    private float stamina;
    public float MaxStamina = 100;

    public bool
        GotWrench = false,
        GotPistol = false;

    public Collider2D WrenchCol;
    public Wrench_Weapon ww;

    public float Health
    {
        get
        {
            return health;
        }

        set
        {
            if (value >= 0)
            {
                transform.DOKill();
                health = value;
                HealthBar.DOFillAmount(health / MaxHealth, 0.1f).SetId(transform);
            }
        }
    }

    public float Stamina
    {
        get
        {
            return stamina;
        }

        set
        {
            stamina = value;
        }
    }

    // Use this for initialization
    void Awake () {

        Instance = Instance ?? this;

        Health = MaxHealth;
        Stamina = MaxStamina;

        GetWrench();
    }

    void Update () {

        if (Input.GetButtonDown("Fire1"))
        {

            SelectedWeapon.Attack();
        }

	}

    public void GetWrench()
    {
        GotWrench = true;
        print("U got Wrench");
        SelectWrench();
    }

    public void SelectWrench()
    {
        if (GotWrench)
        {
            for (int i = 0; i < Weapons.Length; i++)
            {
                if(i != 0)
                    Weapons[i].Activate(false);
                else
                {
                    Weapons[i].Activate(true);
                    SelectedWeapon = Weapons[i];
                    SelectedWeaponType = WeaponTypes.WRENCH;
                }
            }
        }

    }

    public void GetPistol()
    {
        GotPistol = true;
        print("U got Pistol");
        SelectPistol();
    }

    public void SelectPistol()
    {
        if (GotPistol)
        {
            for (int i = 0; i < Weapons.Length; i++)
            {
                if (i != 1)
                {
                    Weapons[i].Activate(false);
                }
                else
                {
                    Weapons[i].Activate(true);
                    SelectedWeapon = Weapons[i];
                    SelectedWeaponType = WeaponTypes.PISTOL;
                }
            }
        }
    }

    public void TakeDamage(float dmg)
    {
        Health = Mathf.Clamp(Health - dmg, 0, MaxHealth);
        if (Health == 0)
            print("DEAD! GAME OVER, BUDDY!");
    }




    public void FinishAttack()
    {
        ww.FinishAttack();
    }

    public void TurnOffCollider()
    {
        WrenchCol.enabled = false;
    }

    public void TurnOnCollider()
    {
        WrenchCol.enabled = true;
    }
}
