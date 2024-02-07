using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject gameobject;
    public float katanaSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if  
    }

    public void FixedUpdate()
    {
        transform.Translate(0, katanaSpeed * Time.deltaTime, 0);
    }

     void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
