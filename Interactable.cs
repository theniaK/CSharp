using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour {
    [HideInInspector]
    public NavMeshAgent playerAgent;
    private bool hasInteracted;

    public virtual void  MoveToInteravtion(NavMeshAgent playerAgent)
    {
        hasInteracted = false;
        this.playerAgent = playerAgent;
        playerAgent.stoppingDistance = 1f; // Makes the player stop close to the object.
        playerAgent.destination = this.transform.position;  // It moves the player to the position of the NPC or item.        
    }

    void Update() //Makes sure that the player interacts with the object when he gets near it and not sooner.
    {
        if (!hasInteracted && playerAgent!= null && !playerAgent.pathPending) // Chekcs if the player is not null and there is a path that the player will follow.
        {
            if (playerAgent.remainingDistance <= playerAgent.stoppingDistance) // Checks if the player is near the destination.
            {
                Interact(); // Calls method so the player will interact with the NPC or item.
                hasInteracted = true;
            }
        }
    }


    public virtual void Interact()
    {
        Debug.Log("Interacting with base class.");
    }
}
