using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Nadar : MonoBehaviour
{
    Animator _myAnim;
    Rigidbody2D _rb;
    GameObject _go;
    Player_Movimiento _instanciaMov;
    float _inputX;
    bool _miraDerecha = true;

    [Tooltip("Asigna la velocidad a la que se mueve paper boy en el agua")]
    public float velocidadNado = 5;
    [Tooltip("Asigna la capacidad de salto de paper boy en el agua")]
    public float saltoAgua = 2;

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
        GestionNado();
        GestionOrientacion();
    }

    //Sirve para dar el movimiento en el agua
    void GestionNado()
    {
        _inputX = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(_inputX * velocidadNado, _rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            _rb.velocity = Vector2.up * saltoAgua;
        }
    }

    void GestionOrientacion()
    {
        if (_inputX > 0.01 && _miraDerecha == false)
        {
            _miraDerecha = true;

            if (transform.rotation != Quaternion.Euler(0, 0, 0))
                transform.Rotate(0, 180, 0);
        }
        else if (_inputX < -0.01 && _miraDerecha == true)
        {
            _miraDerecha = false;

            if (transform.rotation != Quaternion.Euler(0, 180, 0))
                transform.Rotate(0, 180, 0);
        }
    }

    //Desactiva el código de movimiento y activa la animación de transformación a pez
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Agua"))
        {
            _enAgua = true;
            _instanciaMov.enabled = false;
            _myAnim.Play("Trans_Pez");
        }
    }

    //Desactiva el código de nadar y reactiva el del movimiento. Además activa la animación de transformación a pez
    private void OnTriggerExit2D(Collider2D collision)
    {
        _enAgua = false;
        _instanciaMov.enabled = true;
        this.enabled = false;
        _myAnim.Play("Trans_Player");
    }
}
