using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    
    public float speed = 150f; // the speed of the player
    public bool grounded; // checks i the player is grounded
    public float height = 20f; // the height of the jump
    public float gravity = 10f;

    private Rigidbody playerRigid;
    

	// Use this for initialization
	void Awake ()
    {
        
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        playerRigid = GetComponent<Rigidbody>();
        float rotation = Input.GetAxis("Horizontal"); // the ball rotates on the x axis
        rotation *= Time.deltaTime;
        playerRigid.AddTorque(Vector3.back* rotation);

        Vector3 velocity = playerRigid.velocity;
		// the player jumps omly when the ball is grounded
        if (Input.GetKey(KeyCode.Space) && grounded == true)
        {
            playerRigid.velocity = new Vector3 (velocity.x, CalculateJump() , velocity.z);
        }

       Vector3 playerGravity = new Vector3(0f, -gravity * playerRigid.mass, 0f);
       playerRigid.AddForce(playerGravity);

        grounded = false;
    }

	// calculates player jump
    public float CalculateJump()
    {
        float jump = Mathf.Sqrt(1 * height * gravity);
        return jump;
    }

    void OnCollisionStay()
    {
        grounded = true;
    }

}
