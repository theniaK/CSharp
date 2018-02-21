using UnityEngine;
using System.Collections;


public class CheckPoint : MonoBehaviour {

    public  Vector3 reachedPoint;
    public bool check;

	public void OnTriggerEnter (Collider col)
    {
        if (col.tag == "Player") // if the player collides with the checkpoint
        {
            if (transform.position.x > reachedPoint.x) // a new position of the player is set
            {
                reachedPoint = transform.position;
                check = true;
                
            }
            
        }
    }
}
