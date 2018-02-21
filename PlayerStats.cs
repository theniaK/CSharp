using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

    public int health = 3; // player's health
    public int sphereCounter = 0; // counts the spheres collected
    public int scoreCounter = 0; // counts the score
    public int points = 70; // points from collecting spheres

	// Use this for initialization
	void Awake ()
    {
       
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    //If the player collides with a sphere then the player collects the sphere and gains points.
    void OnTriggerEnter (Collider other) 
     {
        if (other.tag == "Sphere") // On collision with a sphere
        {
            sphereCounter++; // the sphere counter increases
            scoreCounter += points; // the score increases
            Destroy(other.gameObject); // the sphere is destroyed
            
        }
     } 
}
