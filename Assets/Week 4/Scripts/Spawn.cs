using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    float timer;
    public GameObject PlanePrefab;
    float timertarget;
    public Sprite[] planeSprites;

    void Start()
    {
        timertarget = Random.Range(1, 5);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timertarget)
        {
            Vector3 position = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
            Quaternion rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
            GameObject newPlane = Instantiate(PlanePrefab, position, rotation);

            SpriteRenderer spriteRenderer = newPlane.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null && planeSprites.Length > 0)
            {
                spriteRenderer.sprite = planeSprites[Random.Range(0, planeSprites.Length)];
            }

            // Set a random speed directly if speed is public in Plane script
            Plane planeScript = newPlane.GetComponent<Plane>();
            if (planeScript != null)
            {
                planeScript.speed = Random.Range(1, 3); // Assuming speed is a public field in Plane
            }

            timer = 0;
            timertarget = Random.Range(1, 5);
        }
    }
}
