using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerrarPagina : MonoBehaviour
{
    Animator controlPanel;

    
    void Start()
    {     
        controlPanel = GameObject.Find("PanelInfoPaginas").GetComponent<Animator>();
    }

    public void OcultarPagina()
    {
        controlPanel.SetBool("Mostrar", false);
    }
}
