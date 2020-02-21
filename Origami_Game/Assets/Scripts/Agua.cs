using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agua : MonoBehaviour
{
    GameObject _agua;
    ParticleSystem _partAgua;

    void Start()
    {
        _agua = transform.Find("Particula Agua Grande").gameObject;
        _partAgua = _agua.GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 _nuevaPos;
        if (collision.CompareTag("Player"))
        {
            _nuevaPos = _agua.transform.position;
            _nuevaPos.x = collision.transform.position.x;
            _agua.transform.position = _nuevaPos;
            _partAgua.Play();
        }
    }
}
