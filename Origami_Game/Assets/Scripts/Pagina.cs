using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pagina : MonoBehaviour
{
    GameManager gm = new GameManager();
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
            //gm.SaveData("pag1","1");
            //gm.SavePlayerData();
            //gm.StartingLoad();
            Invoke("NextScene", 0.2f);
        }
    }

    void NextScene()
    {

        SceneManager.LoadScene("Transicion 1 2");
        
    }
}
