using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //##########---[Variablees]---############################################<

    //----[Menu de Opciones]--------<
    [Header("SettingsOpciones")]
    
    public bool pantalaCompleta=false;
    public bool vibracionDePantalla =false;
    [Range(0, 1)]
    public float volumenGeneral =0;
    [Range(0, 1)]
    public float musica =0;
    [Range(0, 1)]
    public float efectos =0;

    

    // Script para que no se destruya en una carga de escena.
    void Awake()
    {
        KeepOnLoadStart();
    }

    
    void StartLoadPlayerPrefs()
    {
        volumenGeneral = PlayerPrefs.GetFloat("OpcioneVolumenGeneral", 0);
        musica = PlayerPrefs.GetFloat("OpcionesMusica", 0);
        efectos = PlayerPrefs.GetFloat("OpcioneEfectos", 0);
    }


    // Mantine los objetos con tag "No Destuir on Load" al cargar escenas al inicio.
    void KeepOnLoadStart()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("No Destuir on Load");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        //Indicar abajao el numero de la escena que se carga al iniciar el juego en el menu de builds setings (Por defecto "Menu principal")
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }
}
