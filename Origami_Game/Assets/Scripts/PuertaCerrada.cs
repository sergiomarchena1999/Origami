using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaCerrada : MonoBehaviour
{
    public Animator puertaCerrada;
    
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entra");
        if (collision.transform.CompareTag("Player"))
        {
            MuertePlayer.Scene = "Muerte";
            puertaCerrada.SetBool("Activar",true);

            Debug.Log("activa");
        }
    }
}