using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol_Weapon : BaseWeapon {

    public Transform FirePoint;
    public Rigidbody2D BulletPrefab;

    bool canShoot = true;
    float timeBetweenShots = 0.2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Attack()
    {
        if (canShoot)
        {
            Rigidbody2D bullet = Instantiate(BulletPrefab, FirePoint.position, Quaternion.identity);
            bullet.AddForce(FirePoint.right * 2000);
        }
    }
}
