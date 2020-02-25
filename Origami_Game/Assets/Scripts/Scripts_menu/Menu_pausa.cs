using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_pausa : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0f;
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) & GameManager.pausa == true & GameManager.pausaSettings == false & GameManager.pausapaginas==false)
        {
            Volver();
        }
    }

    public void Volver()
    {
        Time.timeScale = 1;
        GameManager.pausa = false;
        SceneManager.UnloadSceneAsync("Menu pausa");
    }

    public void Paginas()
    {
        GameManager.pausapaginas = true;
        SceneManager.LoadScene("Menu paginas", LoadSceneMode.Additive);
    }

    public void Opciones()
    {
        GameManager.pausaSettings = true;
        SceneManager.LoadScene("Menu opciones", LoadSceneMode.Additive);
    }

    public void Exit()
    {
        Time.timeScale = 1;
        GameManager.pausa = false;
        GameManager.pausapaginas = true;
        GameManager.pausaSettings = true;
        SceneManager.UnloadSceneAsync("Testing Nivel");
        SceneManager.UnloadSceneAsync("Menu pausa");
        SceneManager.LoadScene("Menu principal");
    }

}