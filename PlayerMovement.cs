using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 30f;
	public float rotationSpeed = 10f;
	public float gravity = 10f;
	public bool grounded;
	public float jumpHeight = 2;
	public float maxVelocity = 10f;

	public int health = 3;
	public int counter = 0;

	private Transform playerTransform;
	private Rigidbody playerRigidBody;

	// Use this for initialization
	void Start () 
	{
		playerTransform = GetComponent <Transform> (); 
		playerRigidBody = GetComponent <Rigidbody> ();
		playerRigidBody.useGravity = false;
		playerRigidBody.freezeRotation = true; // The game physics doesn't affect the player's rotation.

	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		playerTransform.Rotate (0 , Input.GetAxis("Horizontal")* rotationSpeed, 0); // Sets rotation

		Vector3 targetVelocity = new Vector3 (0, 0 , Input.GetAxis("Vertical")); // Sets player movement on z axis
		targetVelocity = targetVelocity * speed; // Set speed by multiplying vector with speed.
		playerRigidBody.AddForce (targetVelocity); // Gives speed to object.
		targetVelocity = playerTransform.TransformDirection(targetVelocity); // Changes axis when rotating the player

		Vector3 velocity = playerRigidBody.velocity;
		Vector3 velocityChange = targetVelocity - velocity;
		velocityChange.x = Mathf.Clamp (velocityChange.x, -maxVelocity, maxVelocity); // Gives bounds to velocity on x axis.
		velocityChange.z = Mathf.Clamp (velocityChange.z, -maxVelocity, maxVelocity); // Gives bounds to velocity on z axis.
		velocityChange.y = 0; // No velocity on y axis
		playerRigidBody.AddForce (velocityChange , ForceMode.VelocityChange); // Gives bounds to player velocity and make player's mass irrelevant to speed.

		if (Input.GetButton("Jump") && grounded == true) // So that the player jumps once even if the jump button is pushed constantly
		{
			playerRigidBody.velocity = new Vector3 (velocity.x , CalculateJump() , velocity.z);// Set velocity to push up object
		}
		Vector3 playerGravity = new Vector3 (0 , -gravity * playerRigidBody.mass , 0); // Adds gravity relevant to the object's mass to the object
		playerRigidBody.AddForce (playerGravity); // Sets gravity to player


		grounded = false; 
	}

	void Update()
	{
		if (health <= 0) 
		{
			Application.LoadLevel("Scenes/scene3");
		}

        if (counter == 5)
        {
            Application.LoadLevel("Scenes/Menu");
        }
	}

	float CalculateJump () // A method that calculates the player's jump.
	{
		float jump = Mathf.Sqrt(1 * jumpHeight * gravity);
		return jump;
	}

	void OnCollisionStay () // Checks if the object touches the ground.
	{
		grounded = true; 
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == ("Coin")) // If the object the player collides with is a coin then it gets destroyed after the coin counter is raised by one.
		{
			counter++;
			Destroy (other.gameObject);
		}
	}
		
}
