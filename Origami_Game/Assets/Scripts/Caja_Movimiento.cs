using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caja_Movimiento : MonoBehaviour
{
    Rigidbody2D _rb;
    GameObject player;

    [Tooltip("Peso que ha de tener la caja.")]
    public int pesoCaja;
    [Tooltip("Longitud del rayo usado para el raycast.")]
    public float distRayo = 0.3f;

    [Space]
    [Tooltip("Posicion del raycast de la izquierda.")]
    public Transform raycastIzq;
    [Tooltip("Posicion del raycast de la izquierda.")]
    public Transform raycastDer;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");        
    }
    
    //Función llamada por Player_Movimiento cuanco el jugador empuja la caja.
    public void EmpujarCaja()
    {
        RaycastHit2D rayIzq = Physics2D.Raycast(raycastIzq.position, -transform.up, distRayo);
        RaycastHit2D rayDer = Physics2D.Raycast(raycastDer.position, -transform.up, distRayo);

        if (rayIzq.collider != null || rayDer.collider != null)
        {
            Debug.Log("Me empujan.");
            _rb.velocity = player.GetComponent<Rigidbody2D>().velocity * 0.85f;
        }       
    }

    //Función llamada por Player_Movimiento cuanco el jugador deja la caja.
    public void DejarCaja()
    {
        _rb.velocity = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!player.GetComponent<Player_Movimiento>()._conCaja && collision.transform.name == "Paper Boy")
        {
            _rb.mass = 100;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!player.GetComponent<Player_Movimiento>()._conCaja && collision.transform.name == "Paper Boy")
        {
            _rb.mass = pesoCaja;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(raycastIzq.position, raycastIzq.position + (-transform.up) * distRayo);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(raycastDer.position, raycastDer.position + (-transform.up) * distRayo);
    }
}