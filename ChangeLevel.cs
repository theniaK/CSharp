using UnityEngine;
using System.Collections;

public class ChangeLevel : MonoBehaviour {

	void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player") // if the player has touched the finish line...
        {
            Application.LoadLevel(0); //... then the level changes
        }
    }
}
