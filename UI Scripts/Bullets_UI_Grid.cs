using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class Bullets_UI_Grid : MonoBehaviour
{
    public List<Node> nodes;//done
    public Vector2 nodeScale;//done
    public Vector2 MainNodeScale;//done
    public List<Row> Rows;//done
    public Vector2 position;//done
    public int maxNodesInRow; //done
    public Vector2 dimanstionsReference; //done
    public int MainNodesNumInRow; //done
    public Vector2 rowScale; // done
    public Vector2 referenceRowScale; //done
    public int nodesNumber = 0; //done
    public int nodesInRow;//done
    public int gridCapacity; //done

    private void Start()
    {
        refereshVars();
    }
    private void Update()
    {
        refereshVars();
    }
    private void refereshVars()
    {
        if (nodesNumber <= maxNodesInRow)
            nodesInRow = nodesNumber;
        else
            nodesInRow = maxNodesInRow;
        MainNodeScale = rowScale / MainNodesNumInRow;

        if (nodesNumber == 0)
            nodesInRow = MainNodesNumInRow;

        nodeScale = rowScale / nodesNumber;
        rowScale = new Vector2((Screen.currentResolution.width * referenceRowScale.x) / dimanstionsReference.x,
                   (Screen.currentResolution.height * referenceRowScale.y) / dimanstionsReference.y);

        if (Rows.Count == 0 || Rows == null)
        {
            
            Rows = new List<Row>();
            Rows.Add(new Row(position,nodesInRow,nodeScale,rowScale));
        }

        gridCapacity = Rows.Count * nodesInRow;
        if (gridCapacity < nodesNumber)
        {
            Rows.Add(new Row(position + (nodeScale * (Rows.Count - 1)), nodesInRow, nodeScale, rowScale));
            UpdateNodes();
        }

        if (gridCapacity - nodesInRow >= nodesNumber) { 
            Rows.Remove(Rows[Rows.Count - 1]);
            UpdateNodes();
            }
        if (Rows != null && Rows.Count != 0)
        {
            foreach (Row row in Rows)
            {
                row.nodesNumber  = nodesInRow;
                row.nodeScale = nodeScale;
                row.scale = rowScale;
            }
        }
    }
    private void UpdateNodes()
    {
        nodes = new List<Node>();
        if(Rows != null && Rows.Count != 0)
        foreach (Row row in Rows)
        {
            if (row.nodes.Count != 0 && row.nodes != null)
            {
                foreach (Node node in row.nodes)
                    nodes.Add(node);
            }
        }
    }
    private void OnDrawGizmos()
    {
        if (nodes != null)
        {
            foreach (Node node in nodes)
            {
                Gizmos.DrawWireCube(node.position, nodeScale);
            }
        }
    }
}
