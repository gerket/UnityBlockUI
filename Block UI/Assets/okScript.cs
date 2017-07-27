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
        GetComponent<AudioSource>().enabled = true;
        for (int i = 0; i < 4; i++)
        {
            gameObject.transform.GetChild(i).transform.GetComponent<TextMeshPro>().color = Color.green;
        }
        
    }

    IEnumerator OnMouseDown()
    {
        for(int i = 0; i < 3; i++)
        {
            Debug.Log(controller.initialsText[i].ToString());
        }

        //controller.fadeOut();
        yield return new WaitForSeconds(1);
        //controller.fadeIn();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnCollisionEnter()
    {
        GetComponent<AudioSource>().Play();
    }
}
