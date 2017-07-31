using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol_Item : BaseItem {
    public override void Interact()
    {
        PlayerManager.Instance.GetPistol();
        Examine();
        Destroy(gameObject);
    }

    public override void Examine()
    {
        PlayerManager.Instance.Talker.Say("God! Is it industrial laser?");
        print("This is Pistol");
    }


}
