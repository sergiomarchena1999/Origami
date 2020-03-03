using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Menu_opciones : MonoBehaviour
{
    public GameObject menuOpciones;
    

    // Valorespara el slider
    public AudioMixer mixer;

    public GameManager sliders;

    //////////////////////////////////////
    public void Volver()
    {
        GameManager.pausaSettings = false;
        SceneManager.UnloadSceneAsync("Menu opciones");
    }
    public void Continuar()
    {
        GameManager.pausaSettings = false;
        //guardar las opciones que se han usado
        SceneManager.UnloadSceneAsync("Menu opciones");

    }

    private void Awake()
    {
        
    }

    ///////////////////////////// Datos para canvas ///////////////////////////

    public void VolumenSliderMaster(float sliderInput)
    {
        mixer.SetFloat("Master", Mathf.Log10(sliderInput) * 20);
    }

    public void VolumenSliderMusica(float sliderInput)
    {
        mixer.SetFloat("Musica", Mathf.Log10(sliderInput) * 20);
    }

    public void VolumenSliderEfectos(float sliderInput)
    {
        mixer.SetFloat("Efectos", Mathf.Log10(sliderInput) * 20);
    }

}
