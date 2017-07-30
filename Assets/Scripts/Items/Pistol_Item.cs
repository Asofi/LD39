using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol_Item : BaseItem {
    public override void Interact()
    {
        PlayerManager.Instance.GetPistol();
        Destroy(gameObject);
    }

    public override void Examine()
    {
        PlayerManager.Instance.Talker.Say("This is pistol");
        print("This is Pistol");
    }

}
