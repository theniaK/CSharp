using UnityEngine;
using System.Collections;
using UnityEngine.UI;
[ExecuteInEditMode]

public class UIScore : MonoBehaviour {

    PlayerStats playerRigd;
    int score;

    // Use this for initialization
    void Start()
    {
        playerRigd = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        score = playerRigd.scoreCounter; // gets player's score 
        GetComponent<Text>().text = score.ToString(); //  displays player's score to the screen

    }
}
