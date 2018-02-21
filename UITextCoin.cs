using UnityEngine;
using System.Collections;
using UnityEngine.UI;
[ExecuteInEditMode]

public class UITextCoin : MonoBehaviour {


    private PlayerMovement playerCoinCount;
    public int coinCount;
    
	// Use this for initialization
	void Start ()
    {
        playerCoinCount = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMovement>();
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        coinCount = playerCoinCount.counter;
        GetComponent<Text>().text = coinCount.ToString();
    }
}
