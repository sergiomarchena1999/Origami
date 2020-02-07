using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ayuda : MonoBehaviour
{
    GameObject imagenAyuda;
    


    void Start()
    {
        imagenAyuda = transform.Find("Ayuda").gameObject;
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Pito");
        if(collision.transform.CompareTag("Player"))
        {
            imagenAyuda.SetActive(true);
           
            Debug.Log("Pene");
        }
    }
}
