using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;

    private Rigidbody2D rb;

    public int maxHealth = 100;
    int currentHealth;
    private bool isFell = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.name == "Tilemap_fg")
        {
            Debug.Log(collisionInfo.collider.name);
            rb.gravityScale = 0;
            GetComponent<Collider2D>().enabled = false;
            rb.velocity = Vector2.zero;
            isFell = true;
        }
    }

    void Die()
    {
        Debug.Log("Enemy died");

        animator.SetBool("IsDead", true);

        rb.gravityScale = 1;
        if (isFell)
        {
            this.enabled = false;
        }

    }



}
