using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementoSXFDistraccion : MonoBehaviour {

    public AudioClip audioClip;
    private AudioSource audioSource;
    
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "jugador")
        {
            Debug.Log("suena");
            audioSource.Play();
        }
    }
    
}
