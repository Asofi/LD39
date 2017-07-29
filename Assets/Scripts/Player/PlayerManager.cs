using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public class PlayerManager : MonoBehaviour {

    public enum WeaponTypes
    {
        FISTS,
        WRENCH,
        PISTOL
    }

    public WeaponTypes SelectedWeaponType;
    public static PlayerManager Instance;

    public BaseWeapon SelectedWeapon;

    public BaseWeapon[] Weapons;

    private float health;
    public float MaxHealth = 100;

    private float stamina;
    public float MaxStamina = 100;

    public bool
        GotWrench = false,
        GotPistol = false;

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
                if(i != 1)
                    Weapons[i].gameObject.SetActive(false);
                else
                {
                    Weapons[i].gameObject.SetActive(true);
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
                if (i != 2)
                {
                    Weapons[i].gameObject.SetActive(false);
                }
                else
                {
                    Weapons[i].gameObject.SetActive(true);
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
}
