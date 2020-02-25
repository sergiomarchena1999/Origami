using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Rata : MonoBehaviour
{
    Animator _anim;
    Rigidbody2D _rb;

    public Transform posIzq;
    public Transform posDer;

    public float velocidadRata = 4;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();

        transform.position = posDer.position;
    }
    
    void Update()
    {
        Correr();
    }

    void Correr()
    {
        Transform posicionActual = transform;
        Transform objetivo = posIzq;

        while (objetivo.position.x == posDer.position.x)
        {
            _rb.velocity = Vector2.left * velocidadRata;
            _anim.SetTrigger("Correr");

            if (transform.position.x == objetivo.position.x)
            {
                Debug.Log("Parate");
                objetivo = posDer;
                _rb.velocity = Vector2.zero;
                transform.Rotate(0, 180, 0);
            }
        }

        while (objetivo.position.x == posIzq.position.x)
        {
            _rb.velocity = Vector2.left * velocidadRata;
            _anim.SetTrigger("Correr");

            if (transform.position.x == objetivo.position.x)
            {
                Debug.Log("Parate");
                objetivo = posIzq;
                _rb.velocity = Vector2.zero;
                transform.Rotate(0, 180, 0);
            }
        }
    }

    void Ataque1()
    {
        _anim.SetTrigger("Ataque 1");
    }

    void Muerte()
    {
        _anim.SetTrigger("Muerte");
    }
}