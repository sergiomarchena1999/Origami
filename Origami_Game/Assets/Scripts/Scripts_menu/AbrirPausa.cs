using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AbrirPausa : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)& GameManager.pausa == false)
        {
            GameManager.pausa = true;
            SceneManager.LoadScene("Menu pausa", LoadSceneMode.Additive);
        } 
    }
}
