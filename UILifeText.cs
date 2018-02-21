using UnityEngine;
using System.Collections;
using UnityEngine.UI;
[ExecuteInEditMode]

public class UILifeText : MonoBehaviour {

    BallOffTerrain playerRigd;
    int life = 3;

    // Use this for initialization
    void Start()
    {
        playerRigd = GameObject.FindGameObjectWithTag("Player").GetComponent<BallOffTerrain>();
    }

    // Update is called once per frame
    void Update()
    {
        life = playerRigd.life; // gets player's life 
		GetComponent<Text>().text = life.ToString(); // displays the player's health to the screen

    }
}
