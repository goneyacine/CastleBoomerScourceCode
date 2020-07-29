using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{
    public Vector2 position;
    public List<Node> nodes = new List<Node>();
    public int nodesNumber;
    public Vector2 nodeScale;
    public Vector2 scale;

    public Row(Vector2 position,int nodesNumber,Vector2 nodeScale,Vector2 scale)
    {
        this.position = position;
        this.nodesNumber = nodesNumber;
        this.nodeScale = nodeScale;
        this.scale = scale;
    }

    private void Start()
    {
        updateNodes();
    }
    private void Update()
    {
        updateNodes();
    }
    private void updateNodes()
    {
        if (nodes.Count != nodesNumber)
        {
            //refresh the nodes list 
            nodes = new List<Node>();
            for (int i = 0; i < nodesNumber; i++)
            {
                //calculate the position of the current node
                Vector2 currentNodePosition;
                if (i == 0)
                    currentNodePosition = position + (nodeScale / 2);
                else
                    currentNodePosition = position + ((i * nodeScale) + (nodeScale / 2));
                //create the new node and add it to the nodes list
                Node node = new Node(currentNodePosition, nodeScale);
                nodes.Add(node);
            }
        }
    }
}
