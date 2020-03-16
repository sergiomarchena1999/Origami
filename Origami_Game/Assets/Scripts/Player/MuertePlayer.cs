﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MuertePlayer2 : MonoBehaviour
{
    public string Scene2 = "Testing Nivel";
    Animator _myAnim2;
    ParticleSystem[] _myPS2;

    void Start()
    {
        _myAnim2 = GetComponent<Animator>();        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Muerte"))
        {            
            _myAnim2.SetTrigger("Death");
            transform.rotation = Quaternion.identity;
            _myPS2 = GetComponentsInChildren<ParticleSystem>();

            for (int i = 0; i < _myPS2.Length; i ++)
            {
                _myPS2[i].Play();
            }

            
            Destroy(GetComponent<Player_Movimiento>());
            Invoke("restart", 6);
            Destroy(gameObject, 6.1f);
        }
        
    }
    void restart()
    {
        SceneManager.LoadScene((Scene2));
    }
}