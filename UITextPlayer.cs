using UnityEngine;
using System.Collections;
using UnityEngine.UI;
[ExecuteInEditMode]

public class UITextPlayer : MonoBehaviour {

    private PlayerMovement playerMov;
    public int playerHealth;

	// Use this for initialization
	void Start ()
    {
        playerMov = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        playerHealth = playerMov.health;
        GetComponent<Text>().text = playerHealth.ToString();
	}
}
