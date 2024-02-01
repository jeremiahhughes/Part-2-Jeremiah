using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBehaviour : MonoBehaviour
{
    public float dangerDistance = 2; // Define the danger distance
    public AnimationCurve landingCurve;
    public float landingDuration = 5; // Duration for landing
    public static int score = 0; // Public score variable
    private bool isLanding = false;
    private float landingTimer = 0;
    private bool isInDangerZone = false; // Flag for danger zone

    void Start()
    {
        // Use the correct type for 2D physics
        Collider2D collider = GetComponent<Collider2D>();
        if (collider == null)
        {
            collider = gameObject.AddComponent<CircleCollider2D>();
            collider.isTrigger = true;
        }
    }

    void Update()
    {
        if (isLanding)
        {
            LandPlane();
        }
        else
        {
            CheckProximityToOtherPlanes();
        }
    }

    void CheckProximityToOtherPlanes()
    {
        GameObject[] planes = GameObject.FindGameObjectsWithTag("Plane");
        isInDangerZone = false;

        foreach (var plane in planes)
        {
            if (plane != gameObject && Vector3.Distance(transform.position, plane.transform.position) < dangerDistance)
            {
                isInDangerZone = true;
                break;
            }
        }

        // Update plane color based on proximity
        GetComponent<SpriteRenderer>().color = isInDangerZone ? Color.red : Color.white;
    }

    void LandPlane()
    {
        landingTimer += Time.deltaTime;
        float scale = landingCurve.Evaluate(landingTimer / landingDuration);
        transform.localScale = new Vector3(scale, scale, scale);

        if (landingTimer >= landingDuration)
        {
            Destroy(gameObject); // Destroy plane after landing
            score++; // Increase the score
        }
    }

    // Adjust to OnTriggerEnter2D for 2D physics
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Runway") && !isLanding)
        {
            isLanding = true;
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
