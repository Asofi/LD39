using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrench : BaseItem {
    public override void Interact()
    {
        PlayerManager.Instance.GetWrench();
        Destroy(gameObject);
    }

    public override void Examine()
    {
        print("This if wrench");
    }
}
