using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initialsScript : MonoBehaviour
{

    public AudioClip collisionSound;
    public BlockUI controller;

    // Use this for initialization
    void Start()
    {
        GetComponent<AudioSource>().clip = collisionSound;
    }

    void OnMouseDown()
    {
        controller.deleteInitials();
    }

    void OnCollisionEnter()
    {
        GetComponent<AudioSource>().Play();
    }
}
