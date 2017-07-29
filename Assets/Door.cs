using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door : BaseItem {

    Transform DoorObj;
    bool isOpen = false;

    private void Awake()
    {
        DoorObj = transform.GetChild(0);
    }

    public override void Interact()
    {
        if (!isOpen)
        {
            isOpen = true;
            DoorObj.DOLocalMoveY(1, 1);
        } else
        {
            isOpen = false;
            DoorObj.DOLocalMoveY(0, 1);
        }
    }

    public override void Examine()
    {
        print("This is door");
    }
}
