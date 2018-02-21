using UnityEngine;
using System.Collections;

public class Sphere : MonoBehaviour {

    public GameObject  sphereEffect;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    // When the player collides with the sphere the particle effect plays
    public void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player") // when the sphere collides with the player
        {
            Instantiate(sphereEffect, transform.position, transform.rotation); // the sphere effect is generated
          
        }
    }
}
