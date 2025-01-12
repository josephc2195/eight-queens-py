﻿using UnityEngine;
using System.Collections;

public class AI_Sample : MonoBehaviour {

    public CharacterScript mainScript;

    public float[] bombSpeeds;
    public float[] buttonCooldowns;
    public float playerSpeed;
    public int[] beltDirections;
    public float[] buttonLocations;

	// Use this for initialization
	void Start () {
        mainScript = GetComponent<CharacterScript>();

        if (mainScript == null)
        {
            print("No CharacterScript found on " + gameObject.name);
            this.enabled = false;
        }

        buttonLocations = mainScript.getButtonLocations();

        playerSpeed = mainScript.getPlayerSpeed();
	}

    int targetBeltIndex = 0;

	// Update is called once per frame
	void Update () {

        buttonCooldowns = mainScript.getButtonCooldowns();
        beltDirections = mainScript.getBeltDirections();

        float minDistance = 1000; 
        int minIndex = 0;
        float curDistance;

		print ("RED BUTTON COOLDOWNS");
		float[] t = mainScript.getButtonCooldowns ();
		for (int i = 0; i < t.Length; i++) {
			//print (t [i]);
		}
		print ("----------------");


        for (int i = 0; i < beltDirections.Length; i++)
        {
            curDistance = Mathf.Abs(buttonLocations[i] - mainScript.getCharacterLocation());
            if (buttonCooldowns[i] <= 0 && (beltDirections[i] == -1 || beltDirections[i] == 0))
            {
                if (curDistance < minDistance)
                {
                   minIndex = i;
                   minDistance = curDistance;
                }
            }
        }

        targetBeltIndex = minIndex;

        if (buttonLocations[targetBeltIndex] < mainScript.getCharacterLocation())
        {
            mainScript.moveDown();
            mainScript.push();
        }
        else
        {
            mainScript.moveUp();
            mainScript.push();
        }
	}
}
