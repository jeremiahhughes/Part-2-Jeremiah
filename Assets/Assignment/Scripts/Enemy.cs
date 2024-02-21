using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject gameobject;
    public float CheeseEnemySpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FixedUpdate()
    {
        transform.Translate(0, CheeseEnemySpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SendMessage("TakeDamage", 1, SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
