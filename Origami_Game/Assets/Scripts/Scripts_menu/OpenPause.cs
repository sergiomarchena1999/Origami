using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenPause : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&& GameManager.pausa == false)
        {
            GameManager.pausa = true;
            SceneManager.LoadScene("Menu pausa", LoadSceneMode.Additive);
        }
    }
}
