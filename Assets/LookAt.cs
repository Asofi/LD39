using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LookAt : MonoBehaviour {

    public Transform GunIK;
    public Transform Target;
    Vector2 aimPos = Vector2.zero;
    Vector2 curAimPos = Vector2.zero;
    bool isAiming = false;

    Quaternion startRot;
    // Use this for initialization
    void Start () {
        startRot = transform.localRotation;
	}
	
	// Update is called once per frame
	void Update () {
        if (Target == null)
        {
            if (GunIK.gameObject.activeInHierarchy)
                GunIK.gameObject.SetActive(false);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, startRot, Time.deltaTime * 3);
            StopAllCoroutines();
            curAimPos = Vector2.zero;
            isAiming = false;
            return;
        }
        else
        {
            if(!GunIK.gameObject.activeInHierarchy)
                GunIK.gameObject.SetActive(true);
        }

        if (curAimPos == Vector2.zero)
            curAimPos = Target.position;
        if (!isAiming)
            StartCoroutine(RandomAim());
        GunIK.position = curAimPos;
        //Vector3 diff = (Vector3)curAimPos - transform.position;
        //diff.Normalize();

        //float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }

    IEnumerator RandomAim()
    {
        isAiming = true;
        aimPos = (Vector2)Target.position + Random.insideUnitCircle * 0.7f;
        float time = Random.Range(0.5f, 1f);
        Tween tween = DOTween.To(() => curAimPos, x => curAimPos = x, aimPos, time);
        yield return tween.WaitForCompletion();
        isAiming = false;
    }
}
