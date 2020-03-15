using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SaltarVideo : MonoBehaviour
{
    public string Escena;
    public float time;
    private void Start()
    {
        Invoke("saltarEscena",time);
    }

    public void saltarEscena()
    {
        SceneManager.LoadScene(Escena);
    }
}
