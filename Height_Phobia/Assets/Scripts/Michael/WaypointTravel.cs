using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WaypointTravel : MonoBehaviour {

    [SerializeField]
    List<Vector3> Path = new List<Vector3>();

    //[SerializeField]
    private int pathGoalIndex;

    [Tooltip("Helicopter asset to be moved through path")]
    [SerializeField]
    private GameObject Helicopter;

    [Tooltip("Player Character")]
    [SerializeField]
    private GameObject Player;

    [Tooltip("Socket/Location transform to attach the player to on the helicopter")]
    [SerializeField]
    private Transform Socket;

    [Tooltip("Speed to travel at")]
    [Range(0f, 20f)]
    public float travelSpeed;

    [Tooltip("Speed to rotate at")]
    [Range(0f, 20f)]
    public float rotationSpeed;

    [Tooltip("Distance the helicopter must be from a path-node in order to progress onto the next node")]
    [Range(0, 5f)]
    public float distanceThreshold;

    public bool DebugPath;

    // Use this for initialization
    void Start () {

        
		
	}
	
	// Update is called once per frame
	void Update () {

        MoveHelicopter();
        RotatePlayer();
        CheckDistance();
        CheckFinish();

        
        
	}

    /// <summary>
    /// Move the helicopter according to travel speed
    /// </summary>
    private void MoveHelicopter()
    {
        Helicopter.transform.Translate(transform.forward * (Time.deltaTime * travelSpeed));
        
        
        Player.transform.position = Socket.transform.position;
    }

    /// <summary>
    /// Rotate the helicopter according to rotation speed
    /// </summary>
    private void RotatePlayer()
    {
        Helicopter.transform.rotation = Quaternion.Lerp(Helicopter.transform.rotation, Quaternion.LookRotation(Path[pathGoalIndex] - Helicopter.transform.position), Time.deltaTime * rotationSpeed);
    }

    /// <summary>
    /// Check distance to current node in the path
    /// </summary>
    private void CheckDistance()
    {
        if (Vector3.Distance(Helicopter.transform.position, Path[pathGoalIndex]) < distanceThreshold && pathGoalIndex < Path.Count)
        {
            pathGoalIndex++;
        }
    }

    /// <summary>
    /// Check if the helicopter has reached the end of the path
    /// </summary>
    private void CheckFinish()
    {
        if (pathGoalIndex == Path.Count)
        {
            enabled = false;
        }
    }

    /// <summary>
    /// Gather gameobject children and store them as nodes for the waypoint
    /// </summary>
    public void StorePathNodes()
    {
        Debug.Log("Nodes gathered and generated");
        Path.Clear();
        
        for (int i = 0; i < transform.childCount; i++)
        {
            Path.Add(transform.GetChild(i).transform.position);

        }
    }

    /// <summary>
    /// Draw path if DebugPath is turned on
    /// </summary>
    private void OnDrawGizmos()
    {
        if (DebugPath)
        {

            for (int i = 0; i < Path.Count; i++)
            {
                Gizmos.DrawSphere(Path[i], 1);

            }
        }
    }
}


/// <summary>
/// Button for gathering nodes for the path
/// </summary>
[CustomEditor(typeof(WaypointTravel))]
public class ObjectBuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        WaypointTravel Waypoint = (WaypointTravel)target;
        if (GUILayout.Button("Generate Path"))
        {
            Waypoint.StorePathNodes();
        }
    }
}
