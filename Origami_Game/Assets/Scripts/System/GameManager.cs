using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    //##########---[ Variablees ]---##########################################<

    #region Variablees
    //----[Menu de Opciones]--------<
    [SerializeField]
    [Header("Actual Options Data")]
    
    bool pantallaCompleta=false;
    [SerializeField]
    bool vibracionDePantalla =false;
    [SerializeField]
    [Range(0, 1)]
    float volumenGeneral =0;
    [SerializeField]
    [Range(0, 1)]
    float musica =0;
    [SerializeField]
    [Range(0, 1)]
    float efectos =0;
    


    //----[Player Settings]--------<
    [SerializeField]
    [Header("Actual Player Settings Data")]
    
    int[] paginas = { 0, 0, 0, 0, 0 };

    // info Checpoint//
    [SerializeField]
    [Range(0, 5)]
    int lastCheckpoint = 0;
    //
    [SerializeField]
    float lastCheckpointX;
    [SerializeField]
    float lastCheckpointY;
    [SerializeField]
    float lastCheckpointZ;
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
    [SerializeField]
    [Header("Reset Settings to Default Data")]
    [Space(10)]
    bool deseaResetearPlayerPreferences = false;
    [SerializeField]
    [Space(20)]
    bool resetPantallaCompleta = false;
    [SerializeField]
    bool resetVibracionDePantalla = false;
    [SerializeField]
    [Range(0, 1)]
    float resetVolumenGeneral = 0;
    [SerializeField]
    [Range(0, 1)]
    float resetMusica = 0;
    [SerializeField]
    [Range(0, 1)]
    float resetEfectos = 0;
    [SerializeField]
    [Range(0, 5)]
    float resetPaginas = 0;
    [SerializeField]
    [Range(0, 5)]
    int resetLastCheckpoint = 0;
    [SerializeField]
    float resetLastCheckpointX;
    [SerializeField]
    float resetLastCheckpointY;
    [SerializeField]
    float resetLastCheckpointZ;
    #endregion



    //##########---[ Start - Update - Awake ]---##############################<
    #region Start - Update - Awake
    void Awake()
    {
        RestartPlayerSettings();
        StartingLoad();
        KeepOnLoadStart();
        


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
        if (deseaResetearPlayerPreferences== true)
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
            PlayerPrefs.SetFloat("VolumenEfectos", resetEfectos);

            //reset Pantalla y Vabracion.
            if (resetPantallaCompleta == true)
            {
                PlayerPrefs.SetInt("PantallaCompleta", 1);
            }
            else
            {
                PlayerPrefs.SetInt("PantallaCompleta", 0);
            }
            if (resetVibracionDePantalla == true)
            {
                PlayerPrefs.SetInt("VibracionDePantalla", 1);
            }
            else
            {
                PlayerPrefs.SetInt("VibracionDePantalla", 0);
            }



            PlayerPrefs.Save();
        }
        
    }

    public void StartingLoad()
    {
        //Opciones del menu.
        if (PlayerPrefs.GetInt(CheckPref("PantallaCompleta", "Int")) == 0)
        {
            pantallaCompleta = false;
        }
        else
        {
            pantallaCompleta = true;
        }

        if (PlayerPrefs.GetInt(CheckPref("VibracionDePantalla", "Int")) == 0)
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
                PlayerPrefs.Save();
                return PrefName;
            }

            if (KindOfValueFloatOrInt == "Float" | KindOfValueFloatOrInt == "float")
            {
                PlayerPrefs.SetFloat(PrefName, 0);
                PlayerPrefs.Save();
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


    public void SavePlayerData()
    {


        //Reset posicion checkpoint a valores dados en el inspector.
        PlayerPrefs.SetFloat("posicionx", lastCheckpointX);
        PlayerPrefs.SetFloat("posiciony", lastCheckpointY);
        PlayerPrefs.SetFloat("posicionz", lastCheckpointZ);
        //Reset paginas a valores dados en el inspector.
        for (int i = 0; i < 5; i++)
        {
            if (PlayerPrefs.HasKey("pag" + i))
            {
                PlayerPrefs.SetFloat("pag" + i, paginas[i]);
            }
        }
        //Reset Checkpoint a valores dados en el inspector.
        PlayerPrefs.SetInt("NivelActual", lastCheckpoint);
        //Reset Opciones a valores dados en el inspector.
        PlayerPrefs.SetFloat("VolumenGeneral", volumenGeneral);
        PlayerPrefs.SetFloat("VolumenMusica", musica);
        PlayerPrefs.SetFloat("VolumenEfectos", efectos);

        //reset Pantalla y Vabracion.
        if (pantallaCompleta == true)
        {
            PlayerPrefs.SetInt("PantallaCompleta", 1);
        }
        else
        {
            PlayerPrefs.SetInt("PantallaCompleta", 0);
        }
        if (vibracionDePantalla == true)
        {
            PlayerPrefs.SetInt("VibracionDePantalla", 1);
        }
        else
        {
            PlayerPrefs.SetInt("VibracionDePantalla", 0);
        }


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
