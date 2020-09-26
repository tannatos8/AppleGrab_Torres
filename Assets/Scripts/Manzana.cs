using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manzana : MonoBehaviour
{
    [Header("Velocidad de la manzana cuando se transladan")]
    [SerializeField] private float velocidadManzana;
    private bool movimientoTubo = true;

    private void FixedUpdate()
    {
        if (movimientoTubo)
        {
            transform.position += (Vector3.down * velocidadManzana) * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name.Equals("Canasta"))
        {
            ControladorJuego.Instancia.IncrementarPuntaje();
            Destroy(gameObject);
        }
        else if (collision.collider.name.Equals("LimiteInferior"))
        {
            ControladorJuego.Instancia.ContadorVidas();
            Destroy(gameObject);
        }
    }
}
