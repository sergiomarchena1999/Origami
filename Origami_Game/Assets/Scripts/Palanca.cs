using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca : MonoBehaviour
{
    
    Animator _anim;
    bool palancaUsada = false;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && palancaUsada)
        {
            Debug.Log("3");
            _anim.SetTrigger("Activar");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("1");
        if (collision.transform.tag == "Player")
        {
          palancaUsada = true;
         
        }
    }
}


