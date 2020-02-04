using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_opciones : MonoBehaviour
{
    public GameObject menuOpciones;
    void Start()
    {
    }

    public void Volver()
    {
        SceneManager.UnloadSceneAsync("Menu opciones");
    }
    public void Continuar()
    {
        //guardar las opciones que se han usado
        SceneManager.UnloadSceneAsync("Menu opciones");

    }
}
