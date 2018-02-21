using UnityEngine;
using System.Collections;

public class KillOnHit : MonoBehaviour
{
    BallOffTerrain death;
   
    // Use this for initialization
    void Start()
    {
        death = GameObject.FindGameObjectWithTag("Player").GetComponent<BallOffTerrain>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player") // if the player is hit by an enemy...
        {
            death.RestartLevel(); //.. the player dies and the level restarts
           
        }
        
    }

}
