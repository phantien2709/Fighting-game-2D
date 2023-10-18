using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    int currentHealth;
    public GameObject player1;
    public GameObject player2;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    public void takenDmg(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");
        if(currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Enemy died");

        animator.SetBool("Isdead",true);

        Collider2D colliderA = player1.GetComponent<Collider2D>();
        Collider2D colliderB = player2.GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(colliderA,colliderB);
        this.enabled = false;
    }
}
