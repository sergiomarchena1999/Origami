using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activable : MonoBehaviour
{
    Animator _anim;

    public bool multiactivo = true;
    public bool activado = false;

    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void Activar()
    {
        if (multiactivo)
        {
            activado = !activado;
        }
        else
        {
            activado = true;
        }

        _anim.SetBool("Activado", activado);
    }
}