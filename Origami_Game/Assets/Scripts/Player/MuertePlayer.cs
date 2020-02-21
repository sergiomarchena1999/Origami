using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MuertePlayer : MonoBehaviour
{
    Animator _myAnim;
    ParticleSystem[] _myPS;

    void Start()
    {
        _myAnim = GetComponent<Animator>();        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Muerte"))
        {            
            _myAnim.SetTrigger("Death");
            transform.rotation = Quaternion.identity;
            _myPS = GetComponentsInChildren<ParticleSystem>();

            for (int i = 0; i < _myPS.Length; i ++)
            {
                _myPS[i].Play();
            }

            SceneManager.LoadScene(("Menu muerte"), LoadSceneMode.Additive);
            Destroy(GetComponent<Player_Movimiento>());
            Destroy(gameObject, 6f);            
        }
    }
}