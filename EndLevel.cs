using UnityEngine;
using System.Collections;

public class EndLevel : MonoBehaviour {

    BallOffTerrain nextLevel;

    void Awake()
    {
		nextLevel = GameObject.FindGameObjectWithTag("Player").GetComponent<BallOffTerrain>(); // Gets the BallOffTerrain script from the Player
    }

	void OnTrigger (Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            nextLevel.NextLevel();
            Debug.Log("Next");
        }
    }
}
