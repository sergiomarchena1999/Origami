
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonPagina : MonoBehaviour
{

    Text textopagina;
    Text cabeceraPagina;
    [Tooltip("Escribir aquí la cabecera de la página")]
    public string cabecera;
    [Tooltip("Escribir aquí el contenido de la página")]
    [TextArea]
    public string texto;   
    GameObject panelPagina;
    Animator controlPanel;
    Scrollbar barra;

    
    void Start()
    {     
        panelPagina = GameObject.Find("PanelInfoPaginas");
        controlPanel = GameObject.Find("PanelInfoPaginas").GetComponent<Animator>();
        barra = GameObject.Find("ScrollTexto").GetComponent<Scrollbar>();
    }

    void Update()
    {
        
    }

    public void MostrarPagina()
    {
        controlPanel.SetBool("Mostrar", true);
        textopagina = GameObject.Find("TextoInfoPaginas").GetComponent<Text>();
        textopagina.text = texto;
        barra.value = 1;
        cabeceraPagina = GameObject.Find("CabeceraInfoPaginas").GetComponent<Text>();
        cabeceraPagina.text = cabecera;
    }

}
