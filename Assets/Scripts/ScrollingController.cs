using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingController : MonoBehaviour {

    public float velocidadScroll = -1.5f;
    private Rigidbody2D rigidbody;
    
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        
    }

    private void Start()
    {
        rigidbody.velocity= Vector2.right * velocidadScroll;
    }



}
