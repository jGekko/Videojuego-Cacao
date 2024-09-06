using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirJugador : MonoBehaviour
{
    public Transform jugador;
    public Vector3 offset; 

    void Update()
    {
        if (jugador != null)
        {
            // hacer que la posicion de la camara sea igual a la del jugador en cada frame
            transform.position = jugador.position + offset;
        }
    }
}
