using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlay : MonoBehaviour {

    AudioSource AS;

    public AudioClip Laser;
    public AudioClip Energy;
    public AudioClip Hit;

    // Use this for initialization
    void Start () {
        AS = GetComponent<AudioSource>();
	}
	
    public void Shoot()
    {
        AS.PlayOneShot(Laser);
    }

    public void PlayHit()
    {
        AS.PlayOneShot(Hit);
    }

    public void PlayEnergy()
    {
        AS.PlayOneShot(Energy);
    }
}
