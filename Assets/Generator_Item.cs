using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Generator_Item : BaseItem {

    public Transform Tap;

    public override void Examine()
    {
        PlayerManager.Instance.Talker.Say("I should run this generator!");
    }

    public override void Interact()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(Tap.DOLocalRotate(new Vector3(0, 0, 50), 1));
        seq.AppendCallback(()=> { EventManager.Win(); });
    }
}
