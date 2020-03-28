using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftPlatform : MonoBehaviour
{
    private BoxCollider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        collider.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collider.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if(collision.CompareTag("Player"))
        {
            collider.enabled = true;
        }
    }
}
