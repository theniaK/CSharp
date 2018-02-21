using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public int distance = - 20; // The camera's distance from the player on the z axis
    public float lift = 1.5f; // The camera's tilt on the y axis

	// Use this for initialization
	void Awake ()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); // Gets Transform component from player
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //The camera's position will be that of the player's plus the y tilt and z distance
        Vector3 cameraPos = new Vector3(0, lift, distance); // the camera aims at the player from a certain distance and with a certain angle 
        transform.position = target.position + cameraPos; 
        transform.LookAt(target); // The camera always looks at the player
	}
}
