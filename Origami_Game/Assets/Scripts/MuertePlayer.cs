using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MuertePlayer : MonoBehaviour
{
    Animator _myAnim;
    ParticleSystem[] _myPS;
    // Start is called before the first frame update
    void Start()
    {
        _myAnim = GetComponent<Animator>();
        
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
