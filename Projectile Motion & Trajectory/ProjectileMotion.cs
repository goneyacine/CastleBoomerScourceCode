using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMotion : MonoBehaviour
{
    public float startVelocity;
    public float maxTime;
    private float maxTimeMultiplyer = 1f;
    public float deltaTime;
    public float startAngle;
    // private LineRenderer lineRenderer;
    public float gravity = 9.81f;
    public Vector2 startPosition;
    public GameObject pointPrefab;
    public float scaleChanging = .1f;
    private List<GameObject> points;
    private string controlMode = "Mouse";
    private void Start(){
        controlMode = DataSerialization.GetObject("ControlMode") as string;
    }
    private void Update()
    {
        //setting the max time multiplyer value
        if ((startVelocity > 0.1f && Input.GetMouseButton(0)) || (controlMode != "Mouse" && startVelocity > .1f))
            maxTimeMultiplyer = 1;
        else
            if(controlMode == "Mouse" || (controlMode != "Mouse" && startVelocity <.1f))
            maxTimeMultiplyer = 0;
        if (Input.GetMouseButton(0) || Input.GetMouseButtonUp(0) || Input.GetAxis("Horizontal") != 0)
        {
            UpdateProjectileMotion();
        }
    }
    public void UpdateProjectileMotion(){
        //calculate and set the points number 
            int pointsNumber = (int)(maxTime * maxTimeMultiplyer / deltaTime);
            float currentPointScale = pointPrefab.transform.localScale.x;
            //find the position of every point
            if (points != null)
            {
                foreach (GameObject point in points)
                {
                    Destroy(point.gameObject);
                }
            }
            //genrating trajectory points
            points = new List<GameObject>();
            for (int i = 0; i < pointsNumber; i++)
            {

                float angle = startAngle;
                float v = startVelocity;

                Vector2 direction = new Vector2(Mathf.Cos((angle) * Mathf.Deg2Rad), Mathf.Sin((angle) * Mathf.Deg2Rad));
                float Vx = direction.x * v;
                float Vy = direction.y * v;

                float xPosition = Vx * (deltaTime * i);
                float yPosition = Vy * (deltaTime * i) - 9.81f * Mathf.Pow((deltaTime * i), 2) / 2;

                if (currentPointScale > 0)
                {
                    GameObject point = Instantiate(pointPrefab, new Vector2(xPosition + startPosition.x, yPosition + startPosition.y
                    ), Quaternion.identity);
                    point.transform.localScale = new Vector2(currentPointScale, currentPointScale);
                    points.Add(point);
                    currentPointScale -= scaleChanging;
                }
            }
    }
}


