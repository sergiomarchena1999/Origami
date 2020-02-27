using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Rata : MonoBehaviour
{
    Animator _anim;
    Rigidbody2D _rb;

    public Transform destIzq;
    public Transform destDer;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();

        transform.position = destDer.position;
    }
    
    void Update()
    {
        Debug.Log(new Vector2(destDer.position.x, destDer.position.y));
    }

    void Embestida()
    {
        Vector2 auxPos = transform.position;

        if (auxPos == new Vector2(destDer.position.x, destDer.position.y))
        {

        }
    }

    void Ataque1()
    {

    }

    void Muerte()
    {

    }
}