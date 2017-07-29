using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem {

    void Interact();
    void Examine();
    void Spawn(Vector3 position);
    void StepIn();
    void StepOut();
}
