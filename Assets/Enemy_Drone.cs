using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy_Drone : BaseEnemy {

    public enum StateTypes
    {
        PATROL,
        WARINING,
        FOLLOWING,

        ATTACK
    }

    public StateTypes CurState = StateTypes.PATROL;
    StateTypes prevState;

    public TMPro.TMP_Text AlertText;
    public Transform[] PatrolPoints;
    public Vector2 StartPos;
    public float Speed = 10;

    Motor m_Motor;

    int i = 0;
    Transform curWaypoint;
    float distance;

    public bool Patroling = false;

    public DistanceChecker DistChecker;
    public LookAt LookAt;
    public Enemy_Weapon Weapon;

    // Use this for initialization
    void Start () {
        m_Motor = GetComponent<Motor>();
        curWaypoint = PatrolPoints[i];
        StartPos = transform.position;

    }
	
	// Update is called once per frame
	void Update () {

            if (!DistChecker.isPlayerVisible)
            {
                if (prevState != StateTypes.PATROL)
                    prevState = CurState;
                CurState = StateTypes.PATROL;
            }
            else
            {
                if (prevState == StateTypes.PATROL)
                {
                    prevState = CurState;
                    CurState = StateTypes.WARINING;
                }
            }

        if (CurState != StateTypes.ATTACK)
            Weapon.Target = null;

        switch (CurState)
        {
            case StateTypes.PATROL:
                if(prevState != StateTypes.PATROL)
                {
                    AlertText.DOColor(new Color(AlertText.color.r, AlertText.color.g, AlertText.color.b, 0), 0.5f);
                }
                if (LookAt.Target != null)
                    LookAt.Target = null;
                if (Patroling)
                {
                    if (Vector2.Distance(transform.position, curWaypoint.position) > .1f)
                    {
                        m_Motor.Move(curWaypoint.position.x > transform.position.x ? 1 : -1);
                    }
                    else
                    {
                        NextWaypoint();
                    }
                } else
                {
                    int dir;
                    if ((StartPos.x + -.1f) > transform.position.x)
                        dir = 1;
                    else if ((StartPos.x + .1f) < transform.position.x)
                        dir = -1;
                    else
                        dir = 0;

                    m_Motor.Move(dir);
                }

                break;

            case StateTypes.WARINING:
                if (prevState == StateTypes.WARINING)
                    return;
                StartCoroutine(Warning());

                break;

            case StateTypes.FOLLOWING:
                if(LookAt.Target == null)
                    LookAt.Target = DistChecker.Target;
                m_Motor.Move((DistChecker.Target.position.x > transform.position.x) ? 1 : -1);
                if(DistChecker.DistanceToPlayer < DistChecker.AttackDistance)
                {
                    prevState = CurState;
                    CurState = StateTypes.ATTACK;
                    Weapon.Target = DistChecker.Target;
                }
                break;

            case StateTypes.ATTACK:
                Weapon.Attack();
                if (DistChecker.DistanceToPlayer > DistChecker.AttackDistance)
                {
                    prevState = CurState;
                    CurState = StateTypes.FOLLOWING;
                }
                break;
        }
	}

    void NextWaypoint()
    {
        i = (int)Mathf.Repeat(i + 1, 2);
        curWaypoint = PatrolPoints[i];
    }

    IEnumerator Warning()
    {
        AlertText.DOColor(new Color(AlertText.color.r, AlertText.color.g, AlertText.color.b, 1), 0.5f);
        yield return new WaitForSeconds(1);
        prevState = CurState;
        CurState = StateTypes.FOLLOWING;
    }

}
