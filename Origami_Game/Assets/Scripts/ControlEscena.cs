using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlEscena : MonoBehaviour
{
    int _siguienteNivel;
    // Start is called before the first frame update
    void Start()
    {
        _siguienteNivel = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("NivelActual", _siguienteNivel);

            SceneManager.LoadScene(_siguienteNivel);
        }
    }
}
