using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Menu_principal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void NuevaPartida()
    {
        //TODO: Borrar el player pref
        SceneManager.LoadScene(4);
    }
    public void CargarPartida()
    {
        //cargar el nivel que te diga el player pref

    }

    public void Paginas()
    {
        SceneManager.LoadScene("Menu paginas", LoadSceneMode.Additive);
    }

    public void Opciones()
    {
        SceneManager.LoadScene("Menu opciones", LoadSceneMode.Additive);
    }

    public void Exit()
    {
        Application.Quit();
    }

  
}

