using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorManzanas : MonoBehaviour
{
    [Header("Pre.Fabricados de la manzana")]
    [SerializeField] private GameObject manzana;
    [Header("Tiempo en segundos para la creacion de las manzanas")]
    [SerializeField] private float tiempoCreacionManzanas;
    private float tiempoTemporar;

    void Start()
    {
        tiempoTemporar = tiempoCreacionManzanas;
    }

    private void FixedUpdate()
    {
        tiempoTemporar -= Time.deltaTime;
        if (tiempoTemporar <= 0)
        {
            Instantiate(manzana, new Vector3(Random.Range(-8f, 8.1f), transform.position.y, 0), Quaternion.identity, transform);
            tiempoTemporar = tiempoCreacionManzanas;
        }
    }
}
