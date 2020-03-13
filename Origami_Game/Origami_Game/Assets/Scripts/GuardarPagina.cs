using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardarPagina : MonoBehaviour
{
    int[] paginas = { 0, 0, 0, 0, 0 };
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            if (PlayerPrefs.HasKey("pag" + i))
            {
                paginas[i] = 1;
            }
        }
    }
   

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 5; i++)
        {
            if (PlayerPrefs.HasKey("pag" + i))
            {
                paginas[i] = 1;
            }
        }
    }

   
}
