using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diChuyen : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public Animator animator;
    public int tocDo = 4;
    public float traiPhai;
    public bool xoay = true;
    public float nhay;
    public bool duocPhepNhay;
    public Transform _duocPhepNhay;
    public LayerMask san;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        traiPhai = Input.GetAxisRaw("Horizontal");
        rb2D.velocity = new Vector2(tocDo * traiPhai,rb2D.velocity.y);

        if(xoay == true && traiPhai == -1){
            transform.localScale = new Vector3((float)-1.588894, (float)1.614793, (float)1.588894);
            xoay = false;
        }
        else if(xoay == false && traiPhai == 1){
            transform.localScale = new Vector3((float)1.588894,(float)1.614793, (float)1.588894);
            xoay = true;
        }
        //Animation
        animator.SetFloat("dichuyen", Mathf.Abs(traiPhai));

        if(Input.GetKeyUp(KeyCode.J)){
            animator.SetTrigger("tancong");
        }
        duocPhepNhay = Physics2D.OverlapCircle(_duocPhepNhay.position,0.2f,san);
        if(Input.GetKeyDown(KeyCode.K) && duocPhepNhay){
            rb2D.velocity = new Vector2(rb2D.velocity.x,nhay);
        }
    }
}
