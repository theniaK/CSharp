using UnityEngine;
using System.Collections;
using UnityEngine.UI;
[ExecuteInEditMode]

public class UISphereText : MonoBehaviour {


    PlayerStats playerRigd;
    int counter;

	// Use this for initialization
	void Start ()
    {
        playerRigd = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        counter = playerRigd.sphereCounter; // gets sphere counter variavble
        GetComponent<Text>().text = counter.ToString(); // displays how many spheres the player has collected to the screen

    }
}
