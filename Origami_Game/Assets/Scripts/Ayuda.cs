using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ayuda : MonoBehaviour
{
    public SpriteRenderer fotoJump;

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Pito");
        if(collision.transform.name == "Paper Boy")
        {
            fotoJump.enabled = true;
            Debug.Log("Pene");
        }
    }
}
