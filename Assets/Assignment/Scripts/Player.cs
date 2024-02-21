using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Apple;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    Vector2 destination;
    Vector2 movement;
    public float speed = 3;
    public float health;
    public float maxHealth = 5;
    bool isDead;
    public HealthBar healthBar;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        healthBar = GetComponent<HealthBar>();
        isDead = false;
        health = maxHealth;
        health = PlayerPrefs.GetFloat("currentHealth", maxHealth);
        SendMessage("InitializeHealth", health);
        PlayerPrefs.SetFloat("currentHealth", health);
    }

    private void FixedUpdate()
    {
        if (isDead) return;
        movement = destination - (Vector2)transform.position;
        if (movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
        }
        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);
    }

    void Update()
    {
        if (isDead) return;
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(1))
        {
            animator.SetTrigger("Attack");
        }
        animator.SetFloat("Movement", movement.magnitude);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        SendMessage("UpdateHealthUI", health);

        if (health <= 0)
        {
            isDead = true;
            animator.SetTrigger("Death");
            SceneManager.LoadScene("Game over page");
        }
        else
        {
            isDead = false;
            animator.SetTrigger("Take Damage");
        }
        PlayerPrefs.SetFloat("currentHealth", health);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {

            SendMessage("OnPlayerHit", SendMessageOptions.DontRequireReceiver);
        }
    }
}
