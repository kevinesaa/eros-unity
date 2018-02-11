using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReapeactController : MonoBehaviour {

    private SceneController sceneController;
    private BoxCollider2D boxCollider;
    private float lenthg;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        sceneController = GameObject.Find("escenario").GetComponent<SceneController>();
        
    }

    // Use this for initialization
    void Start () {
        lenthg = boxCollider.size.x;

    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < (-lenthg)) {
            
            transform.Translate(sceneController.backgroundCount * lenthg * Vector2.right);
        }
	}
}
