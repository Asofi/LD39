using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CapsuleCollider2D))]
public class PlayerManager : MonoBehaviour {

    public AudioPlay AP;

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

    public GameObject MeleeHUD, GunHUD;

    public Pistol_Weapon GunScript;

    Tween HpTween;

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
                if (value >= MaxHealth)
                    value = MaxHealth;
                health = value;
                HealthBar.fillAmount = health / MaxHealth;
                //HpTween = HealthBar.DOFillAmount(health / MaxHealth, 0.1f).SetId(transform);
            } else if(value <= 0)
            {
                Death();
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

        Instance = this;

        Health = MaxHealth;
        Stamina = MaxStamina;

        //GetWrench();
    }

    void Update () {

        if (GunScript.Size < 1)
        {
            GunScript.Size += Time.deltaTime * 0.1f;
        }

        Health -= Time.deltaTime * (Input.GetKey(KeyCode.LeftShift) ? 1.5f : 1);

        if (Input.GetButtonDown("Fire1"))
        {
            if (SelectedWeapon != null)
                SelectedWeapon.Attack();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(GotWrench)
                SelectWrench();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if(GotPistol)
                SelectPistol();
        }


    }

    public void GetWrench()
    {
        GotWrench = true;
        if (MeleeHUD != null)
        MeleeHUD.SetActive(true);
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
        GunHUD.SetActive(true);
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
        {
            Death();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Death"))
        {
            Death();
        }
    }

    void Death()
    {
        Time.timeScale = 0;
        Health = 0;
        HealthBar.fillAmount = 0;
        EventManager.GameOver();
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

    public void RefillEnergy(float amount)
    {
        Health += amount;
    }
}
