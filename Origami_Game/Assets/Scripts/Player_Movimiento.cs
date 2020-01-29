using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movimiento : MonoBehaviour
{
    Rigidbody2D _rb;

    [Header("Movimiento")]

    public float tiempoSalto;
    public float alturaSalto;
    
    public float velocidadEnSuelo = 5f;

    public Transform piesPos;

    bool _miraDerecha = true;
    bool _enSuelo = true;
    Vector3 movimiento;
    float fuerzaSalto;
    float _inputX;

    [Space]
    public LayerMask capaSuelo;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        
        _rb.gravityScale = (2 * (alturaSalto *= 10)) / Mathf.Pow(tiempoSalto, 2);
        fuerzaSalto = _rb.gravityScale * tiempoSalto;
    }
    
    void Update()
    {
        _inputX = Input.GetAxisRaw("Horizontal");

        GestionMovimiento();
        GestionOrientacion();
    }

    void GestionMovimiento()
    {
        _rb.velocity = new Vector2((_inputX * velocidadEnSuelo), _rb.velocity.y);
        _enSuelo = Physics2D.OverlapCircle(piesPos.position, 0.2f, capaSuelo);

        if (Input.GetButtonDown("Jump") && _enSuelo)
        {
            _rb.velocity = (Vector2.up * fuerzaSalto);
        }
    }

    void GestionOrientacion()
    {
        if(_inputX > 0.01 && _miraDerecha == false)
        {
            _miraDerecha = true;
            transform.Rotate(0, 180, 0);
        }
        else if (_inputX < -0.01 && _miraDerecha == true)
        {
            _miraDerecha = false;
            transform.Rotate(0, 180, 0);
        } 
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(piesPos.position, 0.2f);
    }
}