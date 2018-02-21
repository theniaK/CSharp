using UnityEngine;
using System.Collections;

public class Destructible : MonoBehaviour
{

    public GameObject destroyedVersion;
  
    public void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.name == "Player") // if a crate  collides with the player...
        {
            Destroy(this.gameObject); // .. the object is destroyed
            GameObject clone = Instantiate(destroyedVersion, transform.position, transform.rotation) as GameObject; // the instance of the broken crate is created..
            Destroy (clone.gameObject , 3f); //.. and destroyed in a certain amount of time
        }
    }
}
