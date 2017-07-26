using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockScript : MonoBehaviour {

    public AudioClip collisionSound;
    public BlockUI controller;

	// Use this for initialization
	void Start () {
        GetComponent<AudioSource>().clip = collisionSound;
	}
	
	void OnMouseDown()
    {
        controller.spawnInitials(this.gameObject);
    }

    void OnCollisionEnter()
    {
        GetComponent<AudioSource>().Play();
    }
}
