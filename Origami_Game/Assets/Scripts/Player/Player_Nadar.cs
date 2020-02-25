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

    [HideInInspector]
    public bool _enAgua = false;

    void Start()
    {
        _myAnim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _instanciaMov = GetComponent<Player_Movimiento>();
    }

    void Update()
    {
        if (_enAgua)
        {
            CapturarEjes();
            GestionNado();
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
        float direccion = Mathf.Sign(Vector2.Dot(_rb.velocity, _rb.GetRelativeVector(Vector2.up)));
        _rb.velocity = transform.up * _rb.velocity.magnitude * direccion;

        float torque = _inputX * giro * Time.deltaTime;
        _rb.AddTorque(-torque * direccion);

        vmax = velocidadNado;

        //if (_rb.velocity.magnitude < vmax)
        //{
            float aceleracion = _inputY * potencia * Time.deltaTime;
            _rb.AddForce(transform.up * aceleracion);
        //}

        if (Input.GetButtonDown("Jump"))
        {
            _rb.velocity = Vector2.up * saltoAgua;
        }
    }

    //Desactiva el código de movimiento y activa la animación de transformación a pez
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Agua") && !_enAgua )
        {
            _enAgua = true;
            _instanciaMov.enabled = false;
            _myAnim.SetTrigger("Pez");
        }
    }

    //Desactiva el código de nadar y reactiva el del movimiento. Además activa la animación de transformación a pez
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Agua") && _enAgua)
        {
            Debug.Log("Fuera Agua");
            _enAgua = false;
            _instanciaMov.enabled = true;
            _myAnim.SetTrigger("Humano");
        } 
    }
}
