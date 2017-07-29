using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Pistol_Weapon : BaseWeapon {

    public Transform FirePoint;
    public Rigidbody2D BulletPrefab;
    public LineRenderer BulletTrail;

    public float ShootRadius;
    public float Damage = 50;

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
            canShoot = false;
            if (shotTimer != null)
                StopCoroutine(shotTimer);
            StartCoroutine(shotTimer = ShotTimer());

            Ray shotRay = new Ray(FirePoint.position, FirePoint.right);
            RaycastHit2D hit = Physics2D.Raycast(shotRay.origin, shotRay.direction, ShootRadius);
            BulletTrail.SetPosition(0, FirePoint.position);
            if (hit.collider != null)
            {
                print(hit.collider.name);
                if (hit.collider.CompareTag("Enemy"))
                {
                    hit.collider.GetComponent<BaseEnemy>().TakeDamage(Damage);
                }
                    BulletTrail.SetPosition(1, hit.point);
            }
            else
            {
                BulletTrail.SetPosition(1, FirePoint.position + FirePoint.right * ShootRadius);
            }
            BulletTrail.enabled = true;

        }
    }

    IEnumerator shotTimer;
    IEnumerator ShotTimer()
    {
        Material lrColor = BulletTrail.material;
        lrColor.color = new Color(lrColor.color.r, lrColor.color.g, lrColor.color.b, 1);
        Tween FadeOut = lrColor.DOColor(new Color(lrColor.color.r, lrColor.color.g, lrColor.color.b, 0), timeBetweenShots);
        yield return FadeOut.WaitForCompletion();
        BulletTrail.enabled = false;
        canShoot = true;

    }
}
