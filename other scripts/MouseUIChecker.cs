using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[ExecuteInEditMode]
public class MouseUIChecker : MonoBehaviour
{
    private Camera camera;
    public List<UICircleScriptableObj> UICircleScriptableObjs;
    public List<RectTransform> rectTransforms;
    public ShootingManager shootingManager;
    private List<Vector2> circleAreaPositions;
    private List<float> circleAreaRadius;
    private bool entered = false;
    private Vector2 startCamPosition;
    private float startCamSize;
    public bool showGizoms = true;

    private void Start()
    {
        camera = GetComponent<Camera>();
        startCamPosition = transform.position;
        startCamSize = camera.orthographicSize;
    }
    private void Update()
    {
        UpdateVariables();
        CheckEnter();
        shootingManager.enabled = !entered;
    }
    //check if the mouse entered any of the UI Circle Area
    private void CheckEnter() {
        Vector2 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        entered = false;
        for (int i = 0; i < circleAreaPositions.Count; i++)
        {
            if (Vector2.Distance(mousePosition,WorldPosition(startCamPosition,circleAreaPositions[i])) < circleAreaRadius[i])
            {
                entered = true;
                break;
            }
            else { continue; }
        }
    }
    //Updating the needed variables
    private void UpdateVariables()
    {
        circleAreaPositions = new List<Vector2>();
        circleAreaRadius = new List<float>();
     for(int i = 0; i < UICircleScriptableObjs.Count; i++)
        {
            Vector2 circlePosition = (rectTransforms[i].TransformPoint(Vector3.zero) * camera.orthographicSize) / startCamSize;
            float circleRadius = (UICircleScriptableObjs[i].raduis * camera.orthographicSize) / startCamSize;
            circleAreaPositions.Add(startCamPosition);
            circleAreaRadius.Add(circleRadius);
        }
    }
    //return the local position of an object
    private Vector2 LocalPosition(Vector2 parentPosition,Vector2 worldPosition) { return worldPosition - parentPosition;}
    //return the world position of an object
    private Vector2 WorldPosition(Vector2 parentPosition,Vector2 localPosition) { return localPosition + parentPosition;}
    private void OnDrawGizmos()
    {
        if (showGizoms)
        {
            if (entered)
                Gizmos.color = Color.green;
            else
                Gizmos.color = Color.red;
            for (int i = 0; i < circleAreaPositions.Count; i++) { Gizmos.DrawWireSphere(WorldPosition(startCamPosition,circleAreaPositions[i]), circleAreaRadius[i]); }
        }
    }

}
