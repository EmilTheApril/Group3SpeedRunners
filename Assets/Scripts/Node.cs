using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private GameObject player; // Creates a variable for the player.
    private Grapple grappleScript; // Creates a variable for the Grapple script.
    private Node node; // Creates a variable for the node.

    void Start()
    {
        // Finds the gameObject with the Player tag.
        player = GameObject.FindGameObjectWithTag("Player");

        // Gets the grapple script attached to the player.
        grappleScript = player.GetComponent<Grapple>();

        // The player will not grapple onto something when the game starts, therefore node is sat to null.
        node = null;
    }

    public void GrappleOn() // This method runs the action for when a node is selected.
    {
        // The node clicked on will be set to this particular node gameObject.
        node = this;

        // Access and runs the SelectNode method from the Grapple script.
        grappleScript.SelectNode(node);


    }

    public void GrappleOff() // This method runs the action for when no node is selected.
    {
        // No node will be clicked anymore, therefore it is sat to null.
        node = null;
        
        // Access and runs the DeselectNode method from the Grapple script.
        grappleScript.DeselectNode();
    }
}

