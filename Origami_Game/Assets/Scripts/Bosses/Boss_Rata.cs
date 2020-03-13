using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Rata : MonoBehaviour
{
    Animator _anim;
    Rigidbody2D _rb;

    public Transform suelo;
    public Transform destIzq;
    public Transform destDer;

    public GameObject pincho;
    public Transform spawnPinchos;

    public float velocidad = 15f;
    public float tiempoEntreEmbestidas = 4f;

    float random;

    float _timerEmbestida = 0;
    float _timerAtaque = 0;
    bool _embestir = false;
    bool _meCagoEnLaPuta = false;
    bool _miraDerecha = false;
    bool _enExtremo = false;

    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _rb = GetComponent<Rigidbody2D>();

        transform.position = destDer.position;

        _timerAtaque = Random.Range(5, 10);
    }
    
    void Update()
    {
        if (!_miraDerecha)
            transform.rotation = Quaternion.identity;
        else
            transform.rotation = Quaternion.Euler(0, 180, 0);

        if(Time.time > _timerAtaque)
        {
            random = Random.Range(-10.0f, 10.0f);

            if (random >= 0)
            {                
                _embestir = true;

                if(_embestir && !_meCagoEnLaPuta)
                {
                    _timerEmbestida = Time.time;
                    _timerEmbestida += tiempoEntreEmbestidas;
                    _meCagoEnLaPuta = true;
                }
            }
            else
            {
                Ataque1();
            }
            _timerAtaque = Time.time + Random.Range(5, 10);
        }

        if(_meCagoEnLaPuta)
        {
            _enExtremo = false;
            Embestida();
        }
    }

    void Embestida()
    {
        Debug.Log("Embisto");
        _anim.SetBool("Run", _embestir);       

        if (transform.position.x == destDer.position.x && _embestir)
        {
            _miraDerecha = false;
            _enExtremo = true;
        }

        if (transform.position.x == destIzq.position.x && _embestir)
        {
            _miraDerecha = true;
            _enExtremo = true;
        }

        if (_embestir && _miraDerecha)
        {
            transform.position = Vector2.MoveTowards(transform.position, destDer.position, velocidad * Time.deltaTime);            
        }

        if (_embestir && !_miraDerecha)
        {
            transform.position = Vector2.MoveTowards(transform.position, destIzq.position, velocidad * Time.deltaTime);            
        }

        if (Time.time > _timerEmbestida && (transform.position.x == destDer.position.x || transform.position.x == destIzq.position.x))
        {
            Debug.Log("No embisto");
            _embestir = false;
            _meCagoEnLaPuta = false;
            _anim.SetBool("Run", _embestir);
            _miraDerecha = !_miraDerecha;
        }
    }

    void Ataque1()
    {
        Debug.Log("Ataco 1");
        _anim.SetTrigger("Ataque1");

        float num1 = Random.Range(destIzq.position.x, destDer.position.x);
        float num2 = num1 + Random.Range(destIzq.position.x/3, destDer.position.x/3);
        float num3 = num1 + Random.Range(destIzq.position.x/4, destDer.position.x/4);

        if (num2 > destDer.position.x || num3 > destDer.position.x)
        {
            num2 -= destDer.position.x;
            num3 -= destDer.position.x;
        }

        Vector2 pos1 = new Vector2(num1, spawnPinchos.position.y);
        Vector2 pos2 = new Vector2(num2, spawnPinchos.position.y);
        Vector2 pos3 = new Vector2(num3, spawnPinchos.position.y);

        Instantiate(pincho, pos1, Quaternion.identity, suelo);
        Instantiate(pincho, pos2, Quaternion.identity, suelo);
        Instantiate(pincho, pos3, Quaternion.identity, suelo);
    }

    void Muerte()
    {

    }
}