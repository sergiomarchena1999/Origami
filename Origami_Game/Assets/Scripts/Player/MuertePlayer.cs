using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MuertePlayer : MonoBehaviour
{
    public string Scene;
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

            
            Destroy(GetComponent<Player_Movimiento>());
            Invoke("restart", 6);
            Destroy(gameObject, 6.1f);
        }
        
    }
    void restart()
    {
        SceneManager.LoadScene((Scene));
    }
}