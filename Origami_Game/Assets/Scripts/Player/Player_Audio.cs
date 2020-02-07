using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Audio : MonoBehaviour
{
    AudioSource _as;

    public AudioClip sonidoIdle;
    public AudioClip sonidoPaso;
    public AudioClip sonidoDash;    
    public AudioClip sonidoAterrizaje;

    private void Start()
    {
        _as = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Se ejecuta desde la animación Idle.
    /// </summary>
    public void SonidoIdle()
    {
        bool lastIdle = false;
        int randomAux = Random.Range(1, 4);
        if(randomAux == 2)
        {
            _as.PlayOneShot(sonidoIdle);
            lastIdle = true;
        }
        else
        {
            lastIdle = false;
        }
    }

    /// <summary>
    /// Se ejecuta desde la animación Run.
    /// </summary>
    public void SonidoPasos()
    {
        _as.PlayOneShot(sonidoPaso);
    }

    /// <summary>
    /// Se ejecuta desde la animación Dash.
    /// </summary>
    public void SonidoDash()
    {
        _as.PlayOneShot(sonidoDash);
    }

    /// <summary>
    /// Se ejecuta desde la animación Landing.
    /// </summary>
    public void SonidoAterrizaje()
    {
        _as.PlayOneShot(sonidoAterrizaje);
    }
}