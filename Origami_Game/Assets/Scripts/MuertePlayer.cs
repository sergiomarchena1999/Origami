﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MuertePlayer : MonoBehaviour
{
    Animator _myAnim;
    ParticleSystem _myPS;
    // Start is called before the first frame update
    void Start()
    {
        _myAnim = GetComponent<Animator>();
        _myPS = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Muerte"))
        {

            _myAnim.Play("Death");
            _myPS.Play(); 
            SceneManager.LoadScene(("Menu Muerte"), LoadSceneMode.Additive);
            Destroy(GetComponent<Player_Movimiento>());
            Destroy(gameObject, 1f);
            
        }
    }
}
