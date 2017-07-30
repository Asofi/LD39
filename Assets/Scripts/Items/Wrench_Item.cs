using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrench_Item : BaseItem {
    public override void Interact()
    {
        PlayerManager.Instance.GetWrench();
        Destroy(gameObject);
    }

    public override void Examine()
    {
        PlayerManager.Instance.Talker.Say("This is Wrench", "I can use it for defend!");
        print("This if wrench");
    }
}
