using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_paginas : MonoBehaviour
{
   


  
    public void Continuar()
    {
        //guardar las opciones que se han usado
        SceneManager.UnloadSceneAsync("Menu paginas");
    }
}
