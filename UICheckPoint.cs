using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UICheckPoint : MonoBehaviour {

    CheckPoint checkPoint;
    public bool checkTrue;

	// Use this for initialization
	void Start ()
    {
		
        checkPoint = GameObject.FindGameObjectWithTag("Checkpoint").GetComponent<CheckPoint>();
        checkTrue = checkPoint.check;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (checkTrue)
        {
           GetComponent<Text>().text = "Checkpoint!";
        }
	}
}
