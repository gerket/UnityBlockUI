using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlockUI : MonoBehaviour {

    public float distanceBetweenCards;
    public GameObject blockPrefab;
    public TextMeshPro blockTextFront;
    public TextMeshPro blockTextTop;
    public TextMeshPro blockTextLeft;
    public TextMeshPro blockTextRight;
    public BlockUI controller;
    public float initialHeight;
    public float timeBetweenDrops;
    public Transform initial1Transform;
    public Transform initial2Transform;
    public Transform initial3Transform;
    public GameObject blockOK;
    public GameObject canvas;


    public List<GameObject> blocks;
    public List<GameObject> initials;
    public List<string> initialsText;
    public GameObject blockToAdd;
    public Transform blockTransform;
    public TextMeshPro[] blockTexts;
    public Color32[] colors;
    public int colorCounter;
    public int initialCounter;
    public GameObject spawnInitial;
    public GameObject initialBlockToInstantiate;
     



    // private
    public float offset;

	// Use this for initialization
	void Start () {
        blockTransform = blockPrefab.GetComponent<Transform>();
        blockTexts = new TextMeshPro[] { blockTextFront, blockTextTop, blockTextLeft, blockTextRight };
        colors = new Color32[] {Color.red, Color.blue, Color.green, Color.yellow, Color.magenta };
        colorCounter = 0;
        initialCounter = 1;

        spawnBlocks();
        StartCoroutine("positionBlocks");

    }

    void spawnBlocks()
    {
        
        for (char letter = 'A'; letter <= 'Z'; letter++)
        {
            
            for(int i = 0; i < blockTexts.Length; i++)
            {
                blockTexts[i].text = letter.ToString();
                blockTexts[i].color = colors[colorCounter % colors.Length];
                
            }
            blockToAdd = GameObject.Instantiate(blockPrefab);
            blockToAdd.name = letter.ToString();
            //blockToAdd.GetComponent<Rigidbody>().useGravity = true;
            blocks.Add(blockToAdd);
            colorCounter++;
            
        }
        
    }

    IEnumerator positionBlocks()
    {

        offset = ((blocks.Count - 1.0f) * controller.distanceBetweenCards / 2.0f) - blockTransform.position.x;
        offset *= -1.0f;

        for (int i = 0; i < blocks.Count; i++)
        {
            blocks[i].transform.position = new Vector3(offset + (i * controller.distanceBetweenCards),initialHeight, blockTransform.position.z);
            blocks[i].GetComponent<BoxCollider>().enabled = true;
            blocks[i].GetComponent<Rigidbody>().useGravity = true;
            blocks[i].GetComponent<AudioSource>().enabled = true;
            yield return new WaitForSeconds(timeBetweenDrops);
        }
    }
    
    public void spawnInitials(GameObject initialBlock)
    {
        initialBlockToInstantiate = initialBlock;
        StopCoroutine("spawnInitialsHelper");
        StartCoroutine("spawnInitialsHelper");
    }


    IEnumerator spawnInitialsHelper()
    {
        switch (initials.Count)
        {
            case 0:
                spawnInitial = GameObject.Instantiate(initialBlockToInstantiate, initial1Transform.position, initial1Transform.rotation);
                spawnInitial.name = "Initial 1: " + spawnInitial.name;
                initialsText.Add(initialBlockToInstantiate.name);
                initials.Add(spawnInitial);
                Debug.Log("case 1");
                break;

            case 1:
                spawnInitial = GameObject.Instantiate(initialBlockToInstantiate, initial2Transform.position, initial2Transform.rotation);
                spawnInitial.name = "Initial 2: " + spawnInitial.name;
                initialsText.Add(initialBlockToInstantiate.name);
                initials.Add(spawnInitial);
                Debug.Log("case 2");
                break;

            case 2:
                spawnInitial = GameObject.Instantiate(initialBlockToInstantiate, initial3Transform.position, initial3Transform.rotation);
                spawnInitial.name = "Initial 3: " + spawnInitial.name;
                initialsText.Add(initialBlockToInstantiate.name);
                initials.Add(spawnInitial);
                yield return new WaitForSeconds(timeBetweenDrops);
                blockOK.GetComponent<Rigidbody>().useGravity = true;
                Debug.Log("case 3");
                break;

            default:
                Debug.Log("Hit default switch statement in spawnInitialHelper");
                break;
            
        }
        
        yield break;
    }

    public void deleteInitials()
    {
        switch (initials.Count)
        {
            case 3:
                //kick ok block and initial 3, remove initial 3 from initials and initialsText
                break;

            case 2:
                //kick initial 2, remove initial 3 from initials and initialsText
                break;

            case 1:

                break;

            default:
                Debug.Log("deleteInitials default switch statement");
                break;
        }
    }

    public void fadeOut()
    {
        LeanTween.alpha(canvas, 0.0f, 1.0f);
    }
}
