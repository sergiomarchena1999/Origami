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

    public void Volver()
    {
        Time.timeScale = 1;
        GameManager.pausa = false;
        SceneManager.UnloadSceneAsync("Menu pausa");
    }

    public void Paginas()
    {
        SceneManager.LoadScene("Menu paginas", LoadSceneMode.Additive);
    }

    public void Opciones()
    {
        SceneManager.LoadScene("Menu opciones", LoadSceneMode.Additive);
    }

    public void Exit()
    {
        Time.timeScale = 1;
        GameManager.pausa = false;
        SceneManager.LoadScene("Menu principal");
    }

}