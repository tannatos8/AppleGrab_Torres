using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorJuego : MonoBehaviour
{
    public static ControladorJuego Instancia;

    [Header("UI para mostrar el puntaje")]
    [SerializeField] private TextMeshProUGUI txtPuntaje;
    [Header("UI para mostrar las vidas")]
    [SerializeField] private TextMeshProUGUI txtVidas;
    [Header("UI para mostrar el titulo")]
    [SerializeField] private TextMeshProUGUI txtTitulo;
    [Header("UI para mostrar el controles")]
    [SerializeField] private TextMeshProUGUI txtControles;
    [Header("UI para mostrar el iniciar juego")]
    [SerializeField] private TextMeshProUGUI txtIniciarJuego;
    [Header("Audio de fondo")]
    [SerializeField] private AudioClip audioFondo;
    [Header("Audio de ganar")]
    [SerializeField] private AudioClip audioGanar;
    [Header("Audio de perder")]
    [SerializeField] private AudioClip audioPerder;
    [Header("Numero de vidas")]
    [SerializeField] private int vidas;
    [Header("Numero del puntaje maximo")]
    [SerializeField] private int puntajeMaximo = 0;
    private int puntaje = 0;
    private bool banderaEstadoJuego = true;
    AudioSource fuenteDeAudio;

    private void Awake()
    {
        Instancia = this;
    }

    void Start()
    {
        fuenteDeAudio = GetComponent<AudioSource>();
        txtVidas.text = string.Concat("VIDAS: ", vidas.ToString());
        txtPuntaje.text = string.Concat("PUNTAJE: ", puntaje.ToString());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && banderaEstadoJuego)
        {
            IniciarJuego();
            fuenteDeAudio.clip = audioFondo;
            fuenteDeAudio.Play();
        }
        else if (Input.GetKeyDown(KeyCode.Return) && !banderaEstadoJuego)
        {
            SceneManager.LoadScene("AppleGrab.Juego");
        }
    }

    public void IniciarJuego()
    {
        Time.timeScale = 1;
        txtTitulo.enabled = false;
        txtControles.enabled = false;
        txtIniciarJuego.enabled = false;
        txtPuntaje.enabled = true;
        txtVidas.enabled = true;
    }

    void FixedUpdate()
    {
        if (vidas <= 0)
        {
            Time.timeScale = 0;
            txtTitulo.text = "Perdiste T.T se te acabaron las vidas";
            EstadoJuego();
            fuenteDeAudio.clip = audioPerder;
            fuenteDeAudio.Play();
        }
        else if (puntaje >= puntajeMaximo)
        {
            Time.timeScale = 0;
            txtTitulo.text = string.Concat("Ganaste =)");
            EstadoJuego();
            fuenteDeAudio.clip = audioGanar;
            fuenteDeAudio.Play();
        }
    }

    public void EstadoJuego() 
    {
        txtTitulo.enabled = true;
        txtIniciarJuego.enabled = true;
        txtIniciarJuego.text = "Para volver a jugar precionar la tecla enter";
        banderaEstadoJuego = false;
    }

    public void IncrementarPuntaje()
    {
        txtPuntaje.text = string.Concat("PUNTAJE: ", (puntaje += 1).ToString());
    }

    public void ContadorVidas()
    {
        txtVidas.text = string.Concat("VIDAS: ", (vidas -= 1).ToString());
    }
}
