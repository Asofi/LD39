using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropAfterDeath : MonoBehaviour {

    public Transform SpawnPrefab;

    public void Spawn()
    {
            Instantiate(SpawnPrefab, transform.position - Vector3.up * 0.61f, Quaternion.identity);
    }
}
