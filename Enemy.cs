using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public enum State { // The possible states an enemy can be in.
		LOOKFOR,
		GOTO,
		ATTACK,
	}
	public State currState; // The enemy's current state.
	public float speed= 3f; // The speed of the enemy.
	public float goToDistance =13f; // The distance that is required so that the player is visible to the enemy.
	public float attackDistance = 2f; // The distance required to attack the player.
	public float attackTimer = 2f; // Timer for the enemy to attack.
	public Transform target;
	public string playerTag = "Player";

	private float currTime;
	private PlayerMovement playerScript;
	// Use this for initialization
	IEnumerator Start () 
	{
		target = GameObject.FindGameObjectWithTag (playerTag).transform; // Gets the position of the player
		currTime = attackTimer;

		if (target != null) // if there is a target (player) available.
		{
			playerScript = target.GetComponent <PlayerMovement> (); //Gains access to the players's script.
		}
		while (true) // if the script is enabled.
		{
			switch (currState) 
			{
				case State.LOOKFOR:
					LookFor ();
					break;
				case State.GOTO:
					GoTo ();
					break;
				case State.ATTACK:
					Attack (); 
					break;
			}
			yield return 0;
		}
	}

	void LookFor()
	{
		if ( Vector3.Distance (target.position, transform.position) < goToDistance) // if the player is visible...
		{
			currState = State.GOTO; // ..the enemy starts to follow the player.
		}
	}

	void GoTo()
	{
		transform.LookAt (target); // The enemy faces the player.
		//Makes the enemy follow the player while the player is visible to the enemy
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		RaycastHit ray;
		if (Physics.Raycast(transform.position, fwd, out ray))
		{
			if (ray.transform.tag != playerTag) 
			{
				currState = State.LOOKFOR;
				return;
			}
		}

		if (Vector3.Distance (target.position, transform.position) > attackDistance) { // if the conditions of the distance are met..
			transform.position = Vector3.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
		}else
		{
			currState = State.ATTACK; //.. the enemy attacks the player.
		}	
	}

	void Attack()
	{
		currTime = currTime - Time.deltaTime; // The time depletes in relation to real time.

		if (currTime < 0) // Once the a certain time period passes...
		{
			playerScript.health--; // The enemy's health gets depleted by one
			currTime = attackTimer; // The timer starts from the beginning.
		}

		if (Vector3.Distance (target.position, transform.position) > attackDistance) // If the enemy is not near to the player to attack...
		{
			currState = State.GOTO; // .. then the enemy starts moving toward the player.
		}
	}


}
