using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca : MonoBehaviour
{    
    Animator _anim;    
    
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void UsarPalanca()
    {
        _anim.SetTrigger("Activar");
    }
}