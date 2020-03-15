using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ayuda : MonoBehaviour
{
    //public GameObject imagenAyuda;
    


    void Start()
    {
        //imagenAyuda = transform.Find("Ayuda").gameObject;
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("hello");
        if(collision.transform.CompareTag("Player"))
        {
            //imagenAyuda.SetActive(true);

            Invoke("SiguienteNivel",0.2f);
        }
    }

    void SiguienteNivel()
    {
        SceneManager.LoadScene("Prueba_Nivel_02");
    }
}
