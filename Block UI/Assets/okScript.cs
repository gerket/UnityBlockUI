using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class okScript : MonoBehaviour
{

    public AudioClip collisionSound;
    public BlockUI controller;

    // Use this for initialization
    void Start()
    {
        GetComponent<AudioSource>().clip = collisionSound;
        GetComponent<TextMeshPro>().color = Color.green;
    }

    void OnMouseDown()
    {
        Debug.Log(controller.initialsText);

        controller.fadeOut();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnCollisionEnter()
    {
        GetComponent<AudioSource>().Play();
    }
}
