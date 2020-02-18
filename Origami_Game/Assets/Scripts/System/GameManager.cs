using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    //##########---[ Variablees ]---##########################################<

    #region Variablees
    //----[Menu de Opciones]--------<
    [Header("Actual Options Data")]
    
    public bool pantallaCompleta=false;
    public bool vibracionDePantalla =false;
    [Range(0, 1)]
    public float volumenGeneral =0;
    [Range(0, 1)]
    public float musica =0;
    [Range(0, 1)]
    public float efectos =0;



    //----[Player Settings]--------<
    [Header("Actual Player Settings Data")]
    
    public int[] paginas = { 0, 0, 0, 0, 0 };

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
    public bool resetPantallaCompleta = false;
    public bool resetVibracionDePantalla = false;
    [Range(0, 1)]
    public float resetVolumenGeneral = 0;
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
    private void Start()
    {
        deletePlayerPref();
    }
    #endregion



    //##########---[ Metodos ]---#############################################<

    #region Metodos
    void RestartPlayerSettings()
    {
        //Reset posicion checkpoint a valores dados en el inspector.
        PlayerPrefs.SetFloat("posicionx", resetLastCheckpointX);
        PlayerPrefs.SetFloat("posiciony", resetLastCheckpointY);
        PlayerPrefs.SetFloat("posicionz", resetLastCheckpointZ);
        //Reset paginas a valores dados en el inspector.
        for (int i = 0; i < 5; i++)
        {
            if (PlayerPrefs.HasKey("pag" + i))
            {
                PlayerPrefs.SetFloat("pag" + i, resetPaginas);
            }
        }
        //Reset Checkpoint a valores dados en el inspector.
        PlayerPrefs.SetInt("NivelActual", resetLastCheckpoint);
        //Reset Opciones a valores dados en el inspector.
        PlayerPrefs.SetFloat("VolumenGeneral", resetVolumenGeneral);
        PlayerPrefs.SetFloat("VolumenMusica", resetMusica);
        PlayerPrefs.SetFloat("VolumenEfectos", resetLastCheckpoint);

        //reset Pantalla y Vabracion.
        if (pantallaCompleta)
        {
            PlayerPrefs.SetInt("PantallaCompleta", 1);
        }
        else
        {
            PlayerPrefs.SetInt("PantallaCompleta", 0);
        }
        if (resetVibracionDePantalla)
        {
            PlayerPrefs.SetInt("VibracionDePantalla", 1);
        }
        else
        {
            PlayerPrefs.SetInt("VibracionDePantalla", 0);
        }



        PlayerPrefs.Save();
    }

    void StartingLoad()
    {
        //Opciones del menu.
        if (PlayerPrefs.GetFloat(CheckPref("PantallaCompleta", "Float"))==0)
        {
            pantallaCompleta = false;
        }
        else
        {
            pantallaCompleta = true;
        }

        if (PlayerPrefs.GetFloat(CheckPref("VibracionDePantalla", "Float")) == 0)
        {
            vibracionDePantalla = false;
        }
        else
        {
            vibracionDePantalla = true;
        }
        volumenGeneral = PlayerPrefs.GetFloat(CheckPref("VolumenGeneral", "Float"));
        musica = PlayerPrefs.GetFloat(CheckPref("VolumenMusica", "Float"));
        efectos = PlayerPrefs.GetFloat(CheckPref("VolumenEfectos", "Float"));

        //Checkpoint.
        lastCheckpoint = PlayerPrefs.GetInt(CheckPref("NivelActual", "Int"));
        lastCheckpointX = PlayerPrefs.GetFloat(CheckPref("posicionx", "Float"));
        lastCheckpointY = PlayerPrefs.GetFloat(CheckPref("posiciony", "Float"));
        lastCheckpointZ = PlayerPrefs.GetFloat(CheckPref("posicionz", "Float"));

        //Paginas
        for (int i = 0; i < 5; i++)
        {
                paginas[i] = PlayerPrefs.GetInt(CheckPref("pag"+i, "Int"));
            
        }
    }

    string CheckPref(string PrefName, string KindOfValueFloatOrInt)
    {
        if (!PlayerPrefs.HasKey(PrefName))
        {
            if (KindOfValueFloatOrInt == "Int" | KindOfValueFloatOrInt == "int")
            {
                PlayerPrefs.SetInt(PrefName, 0);
                return PrefName;
            }

            if (KindOfValueFloatOrInt == "Float" | KindOfValueFloatOrInt == "float")
            {
                PlayerPrefs.SetFloat(PrefName, 0);
                return PrefName;
            }
        }
        return PrefName;
    }

    void deletePlayerPref()
    {
        PlayerPrefs.DeleteAll();
    }

    public void SaveData(string variableAGuardar, string valorAGuardar)
    {
        switch (variableAGuardar)
        {
            case "pantallaCompleta":
                pantallaCompleta= bool.Parse(valorAGuardar);
                break;
            case "vibracionDePantalla":
                vibracionDePantalla= bool.Parse(valorAGuardar);
                break;
            case "volumenGeneral":
                volumenGeneral= float.Parse(valorAGuardar);
                break;
            case "musica":
                musica= float.Parse(valorAGuardar);
                break;
            case "efectos":
                efectos= float.Parse(valorAGuardar);
                break;
            case "pag1":
                paginas[0]= int.Parse(valorAGuardar);
                break;
            case "pag2":
                paginas[1] = int.Parse(valorAGuardar);
                break;
            case "pag3":
                paginas[2] = int.Parse(valorAGuardar);
                break;
            case "pag4":
                paginas[3] = int.Parse(valorAGuardar);
                break;
            case "pag5":
                paginas[4] = int.Parse(valorAGuardar);
                break;

            case "lastCheckpoint":
                lastCheckpoint= int.Parse(valorAGuardar);
                break;
            case "lastCheckpointX":
                lastCheckpointX= float.Parse(valorAGuardar);
                break;
            case "lastCheckpointY":
                lastCheckpointY= float.Parse(valorAGuardar);
                break;
            case "lastCheckpointZ":
                lastCheckpointZ= float.Parse(valorAGuardar);
                break;

        }
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
