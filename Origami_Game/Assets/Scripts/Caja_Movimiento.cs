using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caja_Movimiento : MonoBehaviour
{
    Rigidbody2D _rb;

    Transform playerPos;

    public int pesoCaja;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;

        _rb.mass = pesoCaja;
    }

    public void EmpujarCaja()
    {
        transform.parent = playerPos;
        Destroy(_rb);
    }

    public void DejarCaja()
    {
        transform.parent = null;
        _rb = gameObject.AddComponent<Rigidbody2D>();
        _rb.mass = pesoCaja;
        _rb.isKinematic = true;
    }
}