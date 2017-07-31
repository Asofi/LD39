using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrench_Item : BaseItem {
    public override void Interact()
    {
        PlayerManager.Instance.GetWrench();
        Examine();
        Destroy(gameObject);
    }

    public override void Examine()
    {
        PlayerManager.Instance.Talker.Say("It's spectral wrench! Great!");
        print("This if wrench");
    }
}
