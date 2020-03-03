using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Nadar : MonoBehaviour
{
    Animator _myAnim;
    Rigidbody2D _rb;
    Player_Movimiento _instanciaMov;
    float _inputX;
    float _inputY;

    [Tooltip("Asigna la velocidad a la que se mueve paper boy en el agua")]
    public float velocidadNado = 5;
    [Tooltip("Asigna la capacidad de salto de paper boy en el agua")]
    public float saltoAgua = 2;
    [Tooltip("Capacidad de giro en el agua")]
    public float giro = 5;
    [Tooltip("Potencia de nado")]
    public float potencia = 10;

    public float velocidadDashAgua;

    public float tiempoDashAgua;

    public float rotacionFlipMin = 90;
    public float rotacionFlipMax = 270;

    [HideInInspector]
    public bool _enAgua = false;

    bool _cargandoDash = false;
    bool _dashDisponible = true;
    public float timerDashAgua = 1f;
    SpriteRenderer _sr;

    void Start()
    {
        _myAnim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _instanciaMov = GetComponent<Player_Movimiento>();
        _sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (_enAgua)
        {
            CapturarEjes();
            GestionNado();
            GestionDashAgua();
        }  
    }

    void CapturarEjes()
    {
        _inputX = Input.GetAxisRaw("Horizontal");
        _inputY = Input.GetAxisRaw("Vertical");
    }

    //Sirve para dar el movimiento en el agua
    void GestionNado()
    {
        float vmax;
        

        float torque = _inputX * giro * Time.deltaTime;
        _rb.AddTorque(-torque * 100);
      

        vmax = velocidadNado;

        if (_rb.velocity.magnitude < vmax)
        {
            float aceleracion = _inputY * potencia * Time.deltaTime;
           
            _rb.AddForce(transform.right * aceleracion * 100);
            
        }

        if (gameObject.transform.localEulerAngles.z > rotacionFlipMin && gameObject.transform.localEulerAngles.z < rotacionFlipMax)
        {
            _sr.flipY = true;
            Debug.Log("Gira");
        }
        else
        {
            _sr.flipY = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            _rb.velocity = Vector2.up * saltoAgua;
        }
    }

    void GestionDashAgua()
    {
        //Detectar input dash.
        if (Input.GetButtonDown("Dash") && !_cargandoDash && _dashDisponible)
        {
               timerDashAgua = Time.time;
               _cargandoDash = true;
               _dashDisponible = false;
               _rb.velocity = (_rb.velocity * velocidadDashAgua);
        }
        //Timer Dash.
        if (Time.time > timerDashAgua + tiempoDashAgua && _cargandoDash)
        {
            _cargandoDash = false;
            _dashDisponible = true;
        }
    }

    //Desactiva el código de movimiento y activa la animación de transformación a pez
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Agua") && !_enAgua )
        {
            _enAgua = true;
            _instanciaMov.enabled = false;
            _rb.constraints = RigidbodyConstraints2D.None;
            _myAnim.SetTrigger("Pez");
            _myAnim.SetBool("Humano", false);
        }
    }

    //Desactiva el código de nadar y reactiva el del movimiento. Además activa la animación de transformación a pez
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Agua") && _enAgua)
        {
            _enAgua = false;
            _sr.flipY = false;
            _instanciaMov.enabled = true;
            _myAnim.SetBool("Humano",true);
           _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            transform.rotation = Quaternion.identity;
        }
    }
}
