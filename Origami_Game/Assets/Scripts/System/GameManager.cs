﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    //##########---[ Variablees ]---##########################################<

    #region Variablees
    //----[Menu de Opciones]--------<
    [Header("Actual Options Data")]
    
    public bool pantalaCompleta=false;
    public bool vibracionDePantalla =false;
    [Range(0, 1)]
    public float volumenGeneral =0;
    [Range(0, 1)]
    public float musica =0;
    [Range(0, 1)]
    public float efectos =0;



    //----[Player Settings]--------<
    [Header("Actual Player Settings Data")]
    [Range(0, 5)]
    public float paginas = 0;

    // info Checpoint//
    [Range(0, 5)]
    public int lastCheckpoint = 0;
    //
    public float lastCheckpointX;
    public float lastCheckpointY;
    public float lastCheckpointZ;
    //
    // 0 = Biblioteca
    // 1 = Sala del Diario
    // 2 = Desague
    // 3 = Calderas
    // 4 = Naturaleza
    // 5 = Mina encantadas
    //
    //---------------:
    


    //----[Reset Settings to Default]--------<

    [Header("Reset Settings to Default Data")]
    [Space(10)]
    public bool deseaResetearPlayerPreferences = false;
    [Space(20)]
    public bool resetPantalaCompleta = false;
    public bool resetVibracionDePantalla = false;
    [Range(0, 1)]
    public float resetvolumenGeneral = 0;
    [Range(0, 1)]
    public float resetMusica = 0;
    [Range(0, 1)]
    public float resetEfectos = 0;

    [Range(0, 5)]
    public float resetPaginas = 0;
    
    [Range(0, 5)]
    public int resetLastCheckpoint = 0;
    
    public float resetLastCheckpointX;
    public float resetLastCheckpointY;
    public float resetLastCheckpointZ;
    #endregion



    //##########---[ Start - Update - Awake ]---##############################<
    #region Start - Update - Awake
    void Awake()
    {
        KeepOnLoadStart();
        
        if (PlayerPrefs.HasKey("posicionx"))
        {
            lastCheckpointX = PlayerPrefs.GetFloat("posicionx");
            lastCheckpointY = PlayerPrefs.GetFloat("posiciony");
            lastCheckpointZ = PlayerPrefs.GetFloat("posicionz");
            
        }
    }
    #endregion



    //##########---[ Metodos ]---#############################################<

    #region Metodos
    void RestartPlayerSettings()
    {
        //Reset posicion checkpoint.
        PlayerPrefs.SetFloat("posicionx", 0);
        PlayerPrefs.SetFloat("posiciony", 0);
        PlayerPrefs.SetFloat("posicionz", 0);
        //Reset paginas a 0.
        for (int i = 0; i < 5; i++)
        {
            if (PlayerPrefs.HasKey("pag" + i))
            {
                PlayerPrefs.SetFloat("posicionz" + i, 0);
            }
        }
        //Reset Checkpoint a 0.
        PlayerPrefs.SetInt("NivelActual", 0);

        PlayerPrefs.Save();
    }
    #endregion



    //##########---[ Canvas ]---##############################################<

    #region Canvas
    void StartLoadPlayerPrefs()
    {
        volumenGeneral = PlayerPrefs.GetFloat("OpcioneVolumenGeneral", 0);
        musica = PlayerPrefs.GetFloat("OpcionesMusica", 0);
        efectos = PlayerPrefs.GetFloat("OpcioneEfectos", 0);
    }
    #endregion



    //##########---[ Unity ]---###############################################<

    #region Unity
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
    #endregion

}
