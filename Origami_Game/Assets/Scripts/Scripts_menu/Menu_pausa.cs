using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_pausa : MonoBehaviour
{
    public GameObject menuPausa;


    public void Volver()
    {
        menuPausa.SetActive(false);
    }

    public void Paginas()
    {
    }

    public void Opciones()
    {
        SceneManager.LoadScene("Menu opciones", LoadSceneMode.Additive);
    }

    public void Exit()
    {
        SceneManager.LoadScene("Menu principal");
    }
    void Pausa()
    {
        Time.timeScale = 0;
        Time.timeScale = 1;
    }
  
}

