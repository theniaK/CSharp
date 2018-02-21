using UnityEngine;
using System.Collections;

public class WorldInteraction : MonoBehaviour {

    NavMeshAgent playerAgent;
    
	// Use this for initialization
	void Start ()
    {
        playerAgent = GetComponent<NavMeshAgent>(); // Get navmesh component from the gameobject player.
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) // if the left mouese button is clicked and if the mouse pointer is on the UI.
        {
            GetInteraction();
        }
	}
    void GetInteraction()
    {
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition); // Creates a ray.
        RaycastHit interactionInfo; // Stores the ray information.
        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity)) // Casts a ray against all the colliders in the scene.
        {
            GameObject interactedObject = interactionInfo.collider.gameObject; // It stores the object that the mouse clicks on.
            if (interactedObject.tag == "Interactable Object") // If it is something that is interactable then the player moves toward this object...
            {
                interactedObject.GetComponent<Interactable>().MoveToIntervation(playerAgent);

               
            }
            else // ..else the player moves in the terrain in the direction pointed to the player.
            {
                playerAgent.destination = interactionInfo.point; // the player will go to the point that was clicked.
            }
        }
    }

}
