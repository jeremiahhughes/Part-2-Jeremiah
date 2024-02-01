using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBehaviour : MonoBehaviour
{
    public float dangerDistance = 2.0f; // Define the danger distance
    private bool isInDangerZone = false; // Flag to check if the plane is in danger zone

    void Start()
    {
        // Ensure the plane has a Collider component that triggers events and is marked as a trigger
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.isTrigger = true;
        }
    }

    void Update()
    {
        GameObject[] planes = GameObject.FindGameObjectsWithTag("Plane");
        isInDangerZone = false; // Reset the danger flag

        foreach (var plane in planes)
        {
            if (plane != gameObject && Vector3.Distance(transform.position, plane.transform.position) < dangerDistance)
            {
                isInDangerZone = true; // Set flag to true if any plane is too close
                break; // No need to check other planes once one is found to be too close
            }
        }

        // Change color based on danger zone flag
        GetComponent<SpriteRenderer>().color = isInDangerZone ? Color.red : Color.white;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}