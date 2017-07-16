using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockUI : MonoBehaviour {

    public GameObject[] blocks;
    public GameObject blockPrefab;

    private BlockUI blockToAdd;


	// Use this for initialization
	void Start () {

        spawnBlocks();

    }

    void spawnBlocks()
    {
        
        for (char letter = 'A'; letter <= 'Z'; letter++)
        {
            blockToAdd = GameObject.Instantiate(blockPrefab).GetComponent<Card>(); //switch Card with block, figure out how to change text


        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
