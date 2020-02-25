using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca : MonoBehaviour
{    
    Animator _anim;
    Activable _act;
    Player_Movimiento _pm;

    public GameObject objetoActivable;
    public bool activada = false;
    
    void Start()
    {
        _anim = GetComponent<Animator>();
        _pm = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movimiento>();

        if (objetoActivable == null)
            Debug.LogError("Introduce que activa la palanca.");
        else
            _act = objetoActivable.GetComponent<Activable>();
    }

    public void UsarPalanca()
    {
        _anim.SetTrigger("Activar");
        _pm._usandoPalanca = false;
        activada = true;

        _act.Activar();
    }
}