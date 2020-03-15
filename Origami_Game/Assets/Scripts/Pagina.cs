using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pagina : MonoBehaviour
{
    public GameManager gM;

    private void Start()
    {
        
    }
    [Tooltip("Sirve para indicar el número de página al que corresponde siendo 0 el tutorial y 4 la última")]
    public int numPagina = 0;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //llama a los metosdos para guardar info y salvarla en playerPref
            gM.SaveData("pag1", "1");
            gM.SavePlayerData();
            Invoke("NextScene", 0.2f);
        }
    }

    void NextScene()
    {

        SceneManager.LoadScene("Prueba_Nivel_02");
        
    }
}
