using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// #71 Programación del Movimiento, Sergio Marchena, 29/1.
/// </summary>
public class Player_Movimiento : MonoBehaviour
{
    Rigidbody2D _rb;
    Caja_Movimiento _caja;

    [Header("Movimiento")]
    [Tooltip("Tiempo que está el personaje en el aire durante un salto.")]
    public float tiempoSalto;
    [Tooltip("Altura a la que llega el salto del personaje.")]
    public float alturaSalto;
    [Tooltip("Velocidad máxima del personaje al correr.")]
    public float velocidadEnSuelo = 5f;
    [Tooltip("Velocidad máxima del personaje al empujar o tirar.")]
    public float velocidadEmpujando = 3f;
    [Tooltip("Posición de los pies para el detector de colisión con el suelo.")]
    public Transform piesPos;
    [Tooltip("Longitud del rayo usado para el raycast.")]
    public float distRayo = 1f;

    bool _miraDerecha = true;
    bool _conCaja = false;
    bool _enSuelo = true;
    
    //Fuerza del salto del personaje.
    float fuerzaSalto;
    //Variable que guarda hacia que lado en el eje horizontal se quiere mover el jugador.
    float _inputX;
    //Variable que almacena la velocidad real del jugador.
    float _velocidadPlayer;
    
    [Header("Layers")]
    [Tooltip("Seleccionar la layer Suelo.")]
    public LayerMask capaSuelo;
    [Tooltip("Seleccionar la layer Caja.")]
    public LayerMask layerCaja;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        
        //Ajuste de la gravedad para el salto.
        _rb.gravityScale = (2 * (alturaSalto *= 10)) / Mathf.Pow(tiempoSalto, 2);
        //Calculo de la fuerza del salto.
        fuerzaSalto = _rb.gravityScale * tiempoSalto;
    }
    
    void Update()
    {
        _inputX = Input.GetAxisRaw("Horizontal");

        GestionMovimiento(_velocidadPlayer);
        GestionCaja();

        if(!_conCaja)
            GestionOrientacion();
        
    }

    //Esta función se encarga de detectar el input del jugador y convertirlo en movimiento.
    void GestionMovimiento(float velocidad)
    {
        _rb.velocity = new Vector2((_inputX * velocidad), _rb.velocity.y);
        _enSuelo = Physics2D.OverlapCircle(piesPos.position, 0.2f, capaSuelo);

        //Detectar input salto.
        if (Input.GetButtonDown("Jump") && _enSuelo && !_conCaja)
        {
            _rb.velocity = (Vector2.up * fuerzaSalto);
        }
    }

    //Esta función cambia la orientación al personaje cuando gira.
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

    //Función que se encarga de qué hacer cuando se empuja o tira de una caja.
    void GestionCaja()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, transform.forward, distRayo, layerCaja);

        if (ray.collider != null)
        {
            if (Input.GetButtonDown("Empujar") && _enSuelo)
            {
                Debug.Log("Empujando");
                _conCaja = true;
                _caja = ray.transform.gameObject.GetComponent<Caja_Movimiento>();
                
                _caja.EmpujarCaja();                
            }

            if (Input.GetButtonUp("Empujar"))
            {
                Debug.Log("Soltando");
                _conCaja = false;
                
                _caja.DejarCaja();
            }
        }

        if (_conCaja)
            _velocidadPlayer = velocidadEmpujando;
        else
            _velocidadPlayer = velocidadEnSuelo;
    }

    //Dibuja el círculo de la posición de los pies.
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(piesPos.position, 0.2f);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.right * distRayo);
    }
}