using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class khongdichuyen : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject ground;
    // Start is called before the first frame update
    void Start()
    {
        Collider2D colliderA = player1.GetComponent<Collider2D>();
        Collider2D colliderB = player2.GetComponent<Collider2D>();

    Physics2D.IgnoreCollision(colliderA, colliderB); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
