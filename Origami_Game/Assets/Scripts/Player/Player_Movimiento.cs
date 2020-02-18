using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// #71 Programación del Movimiento, Sergio Marchena, 29/1.
/// </summary>
public class Player_Movimiento : MonoBehaviour
{
    Animator _anim;
    Rigidbody2D _rb;
    Caja_Movimiento _caja;

    [Header("Movimiento")]
    [Tooltip("Tiempo que está el personaje en el aire durante un salto.")]
    public float tiempoSalto = 3f;
    [Tooltip("Altura a la que llega el salto del personaje.")]
    public float alturaSalto = 4f;
    [Tooltip("Tiempo que tienes que esperar hasta poder usar el siguiente dash.")]
    public float tiempoDash = .4f;
    [Tooltip("Velocidad a la que el jugador va al usar el dash.")]
    public float velocidadDash = 20f;
    [Tooltip("Cuanto más grande, menos vertical es el dash.")]
    public float verticalidadDash = 2f;
    [Tooltip("Velocidad máxima del personaje al correr.")]
    public float velocidadEnSuelo = 5f;
    [Tooltip("Velocidad máxima del personaje al empujar o tirar.")]
    public float velocidadEmpujando = 3f;
    [Tooltip("Longitud del rayo usado para el raycast.")]
    public float distRayoCaja = 1;
    [Tooltip("Longitud del rayo usado para el raycast.")]
    public float distRayoPies = .2f;

    [HideInInspector]
    public bool _conCaja = false;
    [HideInInspector]
    public bool _enSuelo = false;
    bool _dashDisponible = false;
    bool _cargandoDash = false;
    bool _miraDerecha = true;    

    //Fuerza del salto del personaje.
    float fuerzaSalto;
    //Variable que guarda hacia que lado en el eje horizontal se quiere mover el jugador.
    float _inputX;
    //Variable que almacena la velocidad real del jugador.
    float _velocidadPlayer;
    //Variable que guarda la gravedad ajustada al salto.
    float _newGravity;

    public float _timerDash = 0f;

    [Header("Layers")]
    [Tooltip("Seleccionar la layer Suelo.")]
    public LayerMask capaSuelo;
    [Tooltip("Seleccionar la layer Caja.")]
    public LayerMask capaCaja;

    [Space]
    [Tooltip("Posicion del raycast de la izquierda.")]
    public Transform raycastIzq;
    [Tooltip("Posicion del raycast de la izquierda.")]
    public Transform raycastDer;

    //Variables Animator
    bool isMoving = false;
    float _velocidadY;

    //Copia para acceder al script de nadar
    Player_Nadar _instaciaNadar;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        
        //Ajuste de la gravedad para el salto.
        _newGravity = (2 * (alturaSalto *= 10)) / Mathf.Pow(tiempoSalto, 2);
        _rb.gravityScale = _newGravity;
        //Calculo de la fuerza del salto.
        fuerzaSalto = _rb.gravityScale * tiempoSalto;

        _instaciaNadar = GetComponent<Player_Nadar>();
    }
    
    void Update()
    {
        GestionMovimiento();
        GestionCaja();
        GestionDash();
        GestionAnimacion();

        if(!_conCaja || _cargandoDash)
            GestionOrientacion();    
    }

    //Esta función se encarga de detectar el input del jugador y convertirlo en movimiento.
    void GestionMovimiento()
    {
        RaycastHit2D rayIzq = Physics2D.Raycast(raycastIzq.position, -transform.up, distRayoPies, capaSuelo);
        RaycastHit2D rayDer = Physics2D.Raycast(raycastDer.position, -transform.up, distRayoPies, capaSuelo);

        _inputX = Input.GetAxisRaw("Horizontal");

        if (rayIzq.collider != null || rayDer.collider != null)
        {
            _enSuelo = true;
            _dashDisponible = true;
        }            
        else if (rayIzq.collider == null && rayDer.collider == null)
            _enSuelo = false;
    
        //Convertir el input en eje x en movimiento
        if(!_cargandoDash)
            _rb.velocity = new Vector2((_inputX * _velocidadPlayer), _rb.velocity.y);

        //Detectar input salto.
        if (Input.GetButtonDown("Jump") && _enSuelo && !_conCaja && !_cargandoDash)
        {
            _rb.velocity = (transform.up * fuerzaSalto);
            _anim.SetTrigger("Jump");
        }

        _velocidadY = _rb.velocity.y;
    }
    
    void GestionDash()
    {
        //Detectar input dash.
        if (Input.GetButtonDown("Dash") && !_conCaja && !_cargandoDash && _dashDisponible)
        {
            if (Input.GetAxis("Vertical") > .1 && _inputX > .1)
            {
                transform.Rotate(0, 0, 45);
                _timerDash = Time.time;
                _cargandoDash = true;
                _anim.SetTrigger("Dash");
                _dashDisponible = false;

                _rb.velocity = (transform.right * velocidadDash);
            }
            else if (Input.GetAxis("Vertical") > .1 && _inputX < -.1)
            {
                transform.Rotate(0, 0, 45);
                _timerDash = Time.time;
                _cargandoDash = true;
                _anim.SetTrigger("Dash");
                _dashDisponible = false;

                _rb.velocity = (transform.right * velocidadDash);
            }
            else if (Input.GetAxis("Vertical") < .1 && _inputX > .1)
            {
                _timerDash = Time.time;
                _cargandoDash = true;
                _anim.SetTrigger("Dash");
                _dashDisponible = false;

                _rb.velocity = (transform.right * velocidadDash);
            }
            else if (Input.GetAxis("Vertical") < .1 && _inputX < -.1)
            {
                _timerDash = Time.time;
                _cargandoDash = true;
                _anim.SetTrigger("Dash");
                _dashDisponible = false;

                _rb.velocity = (transform.right * velocidadDash);
            }
        }

        //Timer Dash.
        if (Time.time > _timerDash + tiempoDash && _cargandoDash)
        {
            _cargandoDash = false;

            if (_miraDerecha)
                transform.rotation = Quaternion.identity;
            else
                transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (_cargandoDash)
            _rb.gravityScale = _newGravity/verticalidadDash;
        else
            _rb.gravityScale = _newGravity;
    }

    //Esta función cambia la orientación al personaje cuando gira.
    void GestionOrientacion()
    {
        if (_inputX > 0.01 && _miraDerecha == false)
        {
            _miraDerecha = true;
            transform.rotation = Quaternion.identity;            
        }
        else if (_inputX < -0.01 && _miraDerecha == true)
        {
            _miraDerecha = false;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        } 
    }

    //Función que se encarga de qué hacer cuando se empuja o tira de una caja.
    void GestionCaja()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position + new Vector3(0,.1f,0), transform.forward, distRayoCaja, capaCaja);

        if (ray.collider != null)
        {
            if (Input.GetButton("Empujar") && _enSuelo)
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
        else
        {
            _conCaja = false;
        }

        if (_conCaja)
            _velocidadPlayer = velocidadEmpujando;
        else
            _velocidadPlayer = velocidadEnSuelo;


        _anim.SetBool("Empujando", _conCaja);
    }

    //Función que se encarga de mandarle información al Animator.
    void GestionAnimacion()
    {
        if (_inputX != 0)
            isMoving = true;
        else
            isMoving = false;

        _anim.SetBool("Running", isMoving);
        _anim.SetBool("Grounded", _enSuelo);
        _anim.SetFloat("VelocidadY", _velocidadY);
    }

    //Dibuja el círculo de la posición de los pies.
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(raycastIzq.position, raycastIzq.position + (-transform.up) * distRayoPies);
        Gizmos.DrawLine(raycastDer.position, raycastDer.position + (-transform.up) * distRayoPies);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + new Vector3(0, .1f, 0), transform.position + new Vector3(0, .1f, 0) + transform.right * distRayoCaja);
    }

    //Activa el script de nadar
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Agua"))
        {
            _instaciaNadar.enabled = true;
        }
    }
}