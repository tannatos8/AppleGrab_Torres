using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCanasta : MonoBehaviour
{
    [Header("Velocidad en el vector X")]
    [SerializeField] private Vector2 vector2;
    [Header("Controles para el game pad:")]
    [SerializeField] private KeyCode leftControl;
    [SerializeField] private KeyCode rightControl;

    void FixedUpdate()
    {
        if (Input.GetKey(rightControl))
        {
            transform.Translate(vector2);
        }
        else if (Input.GetKey(leftControl))
        {
            transform.Translate(-vector2);
        }
    }
}
