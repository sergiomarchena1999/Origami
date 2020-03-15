using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pagina : MonoBehaviour
{
    [Tooltip("Sirve para indicar el número de página al que corresponde siendo 0 el tutorial y 4 la última")]
    public int numPagina = 0;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            PlayerPrefs.SetInt("pag" +numPagina, 1);

            PlayerPrefs.Save();
            
        }
    }
}
