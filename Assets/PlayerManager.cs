using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public static PlayerManager Instance;

    public enum Weapons
    {
        FISTS,
        WRENCH,
        PISTOL
    }

    public Weapons ChosenWeapon;

    private float health;
    public float MaxHealth = 100;

    private float stamina;
    public float MaxStamina = 100;

    public bool
        GotWrecker = false,
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
        ChosenWeapon = Weapons.FISTS;
	}

    public void GetWrench()
    {
        GotWrecker = true;
        print("U got Wrench");
    }

    public void SelectWrench()
    {
        ChosenWeapon = Weapons.WRENCH;
    }

    public void GetPistol()
    {
        GotPistol = true;
        print("U got Pistol");
    }

    public void SelectPistol()
    {
        ChosenWeapon = Weapons.PISTOL;
    }

    // Update is called once per frame
    void Update () {
        switch (ChosenWeapon)
        {
            case Weapons.FISTS:

                break;
            case Weapons.WRENCH:

                break;
            case Weapons.PISTOL:

                break;
        }
	}
}
