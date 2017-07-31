using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Pistol_Weapon : BaseWeapon {

    public Transform FirePoint;
    public LineRenderer BulletTrail;
    public LayerMask HitLayerMask;
    public Transform GunBone;

    public float ShootRadius;

    bool canShoot = true;
    public GameObject Ammo;
    public RectTransform AmmoBar;
    float size = 1;

    bool shotTimerFlag = false;


    public float Size
    {
        get
        {
            return size;
        }

        set
        {
            if(value <= 1 && value >=0)
            {
                AmmoBar.sizeDelta = new Vector2(250 * value, AmmoBar.sizeDelta.y);
                size = value;

                if (size > 0.2f)
                    if(!shotTimerFlag)
                    canShoot = true;
                else
                    canShoot = false;
            }

        }
    }

    // Use this for initialization
    void Start () {
        Ammo.SetActive(true);
	}

    public override void Attack()
    {
        if (canShoot)
        {
            Size -= 0.2f;
            GunBone.DOLocalMoveY(0.2f, timeBetweenShots / 2).SetLoops(2, LoopType.Yoyo);
            canShoot = false;
            if (shotTimer != null)
                StopCoroutine(shotTimer);
            StartCoroutine(shotTimer = ShotTimer());

            Ray shotRay = new Ray(FirePoint.position, FirePoint.right);
            RaycastHit2D hit = Physics2D.Raycast(shotRay.origin, shotRay.direction, ShootRadius, HitLayerMask);
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
        shotTimerFlag = true;
        Material lrColor = BulletTrail.material;
        lrColor.color = new Color(lrColor.color.r, lrColor.color.g, lrColor.color.b, 1);
        Tween FadeOut = lrColor.DOColor(new Color(lrColor.color.r, lrColor.color.g, lrColor.color.b, 0), timeBetweenShots);
        yield return FadeOut.WaitForCompletion();
        BulletTrail.enabled = false;
        if(Size > 0.2f)
            canShoot = true;
        shotTimerFlag = false;

    }

    private void OnDisable()
    {
        shotTimerFlag = false;
    }
}
