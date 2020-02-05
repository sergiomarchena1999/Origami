using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #238 Guardar y cargar posición
/// Javier Egea López
/// 29/01
/// </summary>

public class Checkpoint : MonoBehaviour
{
    //Los colliders de checkpoints deberán tener la tag "Checkpoint"
    Vector3 checkpoint;

    private void Start()
    {
        //Asigna la posición guardada por PlayerPrefs a la transform del player al iniciar la escena
        if (PlayerPrefs.HasKey("posicionx"))
        {
            checkpoint.x = PlayerPrefs.GetFloat("posicionx");
            checkpoint.y = PlayerPrefs.GetFloat("posiciony");
            checkpoint.z = PlayerPrefs.GetFloat("posicionz");
            transform.position = checkpoint;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.CompareTag("Checkpoint"))
        {
            //Guarda la posición de un nuevo checkpoint cuando se alcanza 
            PlayerPrefs.SetFloat("posicionx", transform.position.x);
            PlayerPrefs.SetFloat("posiciony", transform.position.y);
            PlayerPrefs.SetFloat("posicionz", transform.position.z);
            PlayerPrefs.Save();
        }
    }

    //Borra la posición guardada por PlayerPrefs
    public void DeleteCheckpoint()
    {
        PlayerPrefs.DeleteAll();
    }
}
