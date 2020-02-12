using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Nadar : MonoBehaviour
{
    Animator _myAnim;
    Rigidbody2D _rb;
    GameObject _go;
    Player_Movimiento _instanciaMov;
    Player_Nadar;
    float _inputX;

    public float velocidadNado = 5;
    public float saltoAgua = 2;

    bool _enAgua;

    // Start is called before the first frame update
    void Start()
    {
        _myAnim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _instanciaMov = GetComponent<Player_Movimiento>();
    }

    // Update is called once per frame
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
}
