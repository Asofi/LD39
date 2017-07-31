using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery_Item : BaseItem {

    [TextArea]
    public string[] Descriptions;
    public float Amount = 25;

    public override void Examine()
    {
        base.Examine();
        PlayerManager.Instance.Talker.Say(Descriptions[Random.Range(0, Descriptions.Length)]);
    }

    public override void Interact()
    {
        base.Interact();
        PlayerManager.Instance.RefillEnergy(Amount);
        Destroy(gameObject);
    }

}
