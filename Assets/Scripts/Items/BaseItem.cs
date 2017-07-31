using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BaseItem : MonoBehaviour, IItem {

    bool SteppedIn = false;

    public CanvasGroup Info;

    public virtual void Examine()
    {
        print("Examined item");
    }

    public virtual void Interact()
    {
        print("Interacted");
    }

    public virtual void Spawn(Vector3 position)
    {
        print("Spawned");
    }

    public virtual void StepIn()
    {
        transform.DOKill();
        Info.DOFade(1, 0.5f).SetId(transform);
        print("Stepped It");
    }

    public virtual void StepOut()
    {
        transform.DOKill();
        Info.DOFade(0, 0.5f).SetId(transform);
        print("Stepped Out");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SteppedIn = true;
        StepIn();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        SteppedIn = false;
        StepOut();
    }
	
	// Update is called once per frame
	void Update () {
        if (!SteppedIn)
            return;
        if (Input.GetKeyDown(KeyCode.F))
        {
            Interact();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Examine();
        }
    }

}
