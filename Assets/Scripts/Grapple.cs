using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    private LineRenderer lineRend; // Creates a variable for the linerenderer.
    private DistanceJoint2D distJoint; // Creates a variable for the distance joint.
    private Node selectedNode; // Creates a variable for the Node-type gameObject.


    void Start()
    {
        // References the components on our gameObject.
        lineRend = GetComponent<LineRenderer>();
        distJoint = GetComponent<DistanceJoint2D>();

        // This prevents the player from accidentally grappling onto a random object, when the game starts.
        lineRend.enabled = false;
        distJoint.enabled = false;
        selectedNode = null;
    }

    void Update()
    {
        // This will constantly check if the player grapples onto a gameObject, which we will call a node for reference.

        NodeBehavior();

    }

    public void SelectNode(Node node) // This method will let the player select a node to grapple onto. The Node is the type we wish to use.
    {
        selectedNode = node;
    }

    public void DeselectNode() // This method will deselect the selectedNode when it runs.
    {
        selectedNode = null;
    }

    private void NodeBehavior()
    {
        // This will make sure nothing happens, if the player has not selected a node.
        if (selectedNode == null)
        {
            lineRend.enabled = false;
            distJoint.enabled = false;

            return;
        }

        // If a node has been selected, the line will be rendered and the distant joint will be enabled as well. 
        lineRend.enabled = true;
        distJoint.enabled = true;

        // This will change the connected Rigidbody component's node to the current selected one on our player. 
        distJoint.connectedBody = selectedNode.GetComponent<Rigidbody2D>();

        // If the player has selected a node, two positions for the linerenderer will be created.
        if (selectedNode != null)
        {
            lineRend.SetPosition(0, transform.position);
            lineRend.SetPosition(1, selectedNode.transform.position);
        }
    }
}