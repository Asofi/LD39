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
        PlayerManager.Instance.Talker.Say("It is spectral wrench!", "I can use it for defence!");
        print("This if wrench");
    }
}
