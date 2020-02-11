
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonPagina : MonoBehaviour
{

    Text textopagina;
    Text cabeceraPagina;
    public string cabecera;
    [TextArea]
    public string texto;   
    GameObject panelPagina;
    Animator controlPanel;

    
    void Start()
    {     
        panelPagina = GameObject.Find("PanelInfoPaginas");
        controlPanel = GameObject.Find("PanelInfoPaginas").GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void MostrarPagina()
    {
        controlPanel.SetBool("Mostrar", true);
        textopagina = GameObject.Find("TextoInfoPaginas").GetComponent<Text>();
        textopagina.text = texto;
        cabeceraPagina = GameObject.Find("CabeceraInfoPaginas").GetComponent<Text>();
        cabeceraPagina.text = cabecera;
    }

}
