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

    public float velocidadNado = 5;
    public float saltoAgua = 2;

    bool _enAgua;

    void Start()
    {
        _myAnim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _instanciaMov = GetComponent<Player_Movimiento>();
    }

    void Update()
    {
        GestionNado();
    }

    void GestionNado()
    {
        _inputX = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(_inputX * velocidadNado, _rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            _rb.velocity = Vector2.up * saltoAgua;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Agua"))
        {
            _instanciaMov.enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _instanciaMov.enabled = true;
        this.enabled = false;
    }
}
