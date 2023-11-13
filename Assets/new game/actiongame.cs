
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class actiongame : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    [SerializeField] float tocdo = 4.0f;
    public float phaitrai;
    public bool rotate = true;
    public Transform attackPoint;
    public float attackRange = 0.4f;
    public LayerMask enemyLayers;
    public float attackrate = 2f;
    float nextAttackTime = 0.5f;
    public int attackDamage = 40;
    public bool isJump = false;
    [SerializeField] float jump = 7f;
    public onLanding landing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isJump && landing.State()) {
            isJump = true;
            animator.SetBool("isJump", isJump);
        }

        //Check if character just started falling
        if(isJump && !landing.State()) {
            isJump = false;
            animator.SetBool("isJump", isJump);
        }
        phaitrai = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(tocdo * phaitrai, rb.velocity.y);
        if(rotate == true && phaitrai == 1)
        {
            transform.localScale = new Vector3(-(float)1.5,(float)1.5,(float)1.5);
            rotate = false;
        }
        else if(rotate == false && phaitrai == -1)
        {
            transform.localScale = new Vector3((float)1.5,(float)1.5,(float)1.5);
            rotate = true;
        }

        animator.SetFloat("dichuyen", Mathf.Abs(phaitrai));

        if(Time.time >= nextAttackTime)
        {
            if(Input.GetKeyDown(KeyCode.J))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackrate;
            }
        }
        if (Input.GetKeyDown(KeyCode.K) && isJump) 
        {
            animator.SetTrigger("jump");
            isJump = true;
            animator.SetBool("isJump", isJump);
            rb.velocity = new Vector2(rb.velocity.x, jump);
            landing.Disable(0.2f);  
        }     
    }
    void Attack()
    {
        animator.SetTrigger("attack");
        //Detect enemies in rage of attack
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayers);
        //Damege them
        foreach(Collider2D enemy in hitEnemy)
        {
            enemy.GetComponent<Enemy>().takenDmg(attackDamage); 
        }
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }
}
