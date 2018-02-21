using UnityEngine;
using System.Collections;

public class BallOffTerrain : MonoBehaviour {

    public int maxFallDistance = -20; // Distance where ball is allowed to fall without taking damage
    public int life; // the life of the ball
    private Vector3 checkPoint;
    private PlayerStats playerStats;
    private AudioSource audio;
    private CheckPoint checkPointScript;
   
    void Awake ()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>(); // getting the PlayerStats script from the Player 
        audio = GetComponent<AudioSource>();
		checkPointScript = GameObject.FindGameObjectWithTag("Checkpoint").GetComponent<CheckPoint>(); // getting the CheckPoint script from the CheckPoint 
        life = playerStats.health; 
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (transform.position.y <= maxFallDistance)
        {
            
            RestartLevel(); // if the player fall further than the max falling disance the level restarts
        }
	}

    public void   RestartLevel()
    {
        audio.Play(); // when restarting the level a sound plays
        checkPoint = checkPointScript.reachedPoint; 
		transform.position = checkPoint; // the player restarts from the last checkpoint
        life--; // life reduced
        if (life < 0)
        {
            Application.LoadLevel(0); //the level restarts if the player loses all 3 lives
        }

    }

    public void NextLevel()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }
}
