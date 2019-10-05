using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogBehavior : MonoBehaviour
{

    public float jump;
    public bool isGrounded = false;
    public Transform GroundCheck1;
    public LayerMask groundLayer;

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck1.position, 0.15f, groundLayer); // checks if you are within 0.15 position in the Y of the ground
    }

    void Start()
    {
        
    }

}
