﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Audio : MonoBehaviour
{
    AudioSource _as;
    AudioSource _asAire;
    Player_Movimiento _pm;
    
    public AudioClip sonidoIdle;
    public AudioClip sonidoPaso;
    public AudioClip sonidoDash;    
    public AudioClip sonidoSalto;
    public AudioClip sonidoAterrizaje;

    void Start()
    {
        _as = GetComponent<AudioSource>();
        _pm = GetComponent<Player_Movimiento>();
        _asAire = GameObject.Find("AudioAire").GetComponent<AudioSource>();
    }

    void Update()
    {
        SonidoEnAire();
    }

    /// <summary>
    /// Se ejecuta desde la animación Idle.
    /// </summary>
    public void SonidoIdle()
    {
        bool lastIdle = false;
        int randomAux = Random.Range(1, 4);
        if(randomAux == 2 && !lastIdle)
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
    /// Se ejecuta desde la animación Dash.
    /// </summary>
    public void SonidoSalto()
    {
        _as.PlayOneShot(sonidoSalto);
    }

    /// <summary>
    /// Se ejecuta desde la animación Landing.
    /// </summary>
    public void SonidoAterrizaje()
    {
        _as.PlayOneShot(sonidoAterrizaje);
    }

    public void SonidoEnAire()
    {
        if (!_pm._enSuelo)
        {
            if (!_asAire.isPlaying)
                _asAire.Play();
        }
        else
        {
            if (_asAire.isPlaying)
                _asAire.Stop();
        }
    }
}