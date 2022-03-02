using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class ControladorDePuntaje : MonoBehaviour
{
    //puntaje en este instante
    public static int puntajeActual;

    //numero de preguntas totales
    public static int numeroDePreguntasTotal;

    //numero de preguntas respondidas en este instante
    public static int preguntasRespondidas = 1;

    //si llega a cinco doy un power up
    int contadorRacha;

    //powerUp actual
    string powerUpActual;

    public Text textoPuntaje;
    public Text textoNumeroDePreguntas;
    public SpriteRenderer spriteRenderer;

    // Colores
    public GameObject panel;

    // Variables de Sonido
    public AudioSource fuenteSonido;
    public AudioClip clipCorrecto;
    public AudioClip clipIncorrecto;

    //creo una instacia singleton
    public static ControladorDePuntaje Instancia;

    void Start()
    {
        panel = GameObject.Find("PanelJuego");
        powerUpActual = "";
        contadorRacha = 0;
        Instancia = this;
        numeroDePreguntasTotal = 25;
    }



    public void puntuarRespuestaCorrecta()
    {
        puntajeActual = puntajeActual + getPuntaje();
        preguntasRespondidas++;
        Asignador.Instancia.mostrarPuntaje(textoPuntaje);
        contadorRacha = contadorRacha + 1;
        Debug.Log(contadorRacha);
        verificarRacha();

        // Color
        panel.GetComponent<Image>().color = Color.green;
        StartCoroutine(cambiarColor());

        //Sonido
        fuenteSonido.clip = clipCorrecto;
        fuenteSonido.Play();

        //tiempo interno
        Tiempo.Instancia.resetTiempo();
    }

    public void puntuarRespuestaIncorrecta()
    {
        puntajeActual = puntajeActual - getPuntaje();
        preguntasRespondidas++;
        if (puntajeActual < 0)
        {
            puntajeActual = 0;
        }
        Asignador.Instancia.mostrarPuntaje(textoPuntaje);
        contadorRacha = 0;

        // Color
        panel.GetComponent<Image>().color = Color.red;
        StartCoroutine(cambiarColor());

        //Sonido
        fuenteSonido.clip = clipIncorrecto;
        fuenteSonido.Play();

        //tiempo interno
        Tiempo.Instancia.resetTiempo();
    }

    public int getPuntaje()
    {
        switch (Tiempo.Instancia.getTiempo())
        {
            case <=1.0f:
                return 5;
            case <=4.0f:
                return 3;
            case <=7.0f:
                return 2;
            default:
                return 1;
        }
    }



    public void verificarRacha()
    {
        if (contadorRacha == 5)
        {
            getPowerUp();
            spriteRenderer.sprite = Resources.Load<Sprite>(powerUpActual);
            foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
            {
                if (go.name.Equals("BotonPowerUps"))
                {
                    Asignador.Instancia.mostrarPowerUp(go, spriteRenderer.sprite);
                    break;
                }
            }

        }
    }



    // 
    IEnumerator cambiarColor()
    {
        yield return new WaitForSeconds(0.5f);
        panel.GetComponent<Image>().color = new Color(0.3396226f,0.3396226f,0.3396226f,0.7450981f);
    }


    //de manera randómica nos devuelve un power up
    public void getPowerUp()
    {
        int numeroRandomico;
        if (GestionadorDeEscenas.Instancia.getEscena().Equals("ModoContrareloj"))
        {//verifico en que escena estoy
            string[] powerUps = { "PU5050", "PUDoblePuntos", "PUEliminar", "PUMas10" };
            numeroRandomico = Random.Range(0, 4);
            powerUpActual = powerUps[numeroRandomico];
        }
        else
        {
            string[] powerUps = { "PU5050", "PUDoblePuntos", "PUEliminar" };
            numeroRandomico = Random.Range(0, 3);
            powerUpActual = powerUps[numeroRandomico];
        }
    }

    public void activarPowerUp()
    {
        contadorRacha = 0;
        switch (powerUpActual)
        {

            case "PU5050":
                powerUp5050();
                break;

            case "PUDoblePuntos":
                powerUpDoblePuntos();
                break;

            case "PUEliminar":
                powerUpEliminar();
                break;

            case "PUMas10":
                powerUpMas10();
                break;

            default:
                break;
        }
    }

    public void powerUp5050()
    {
        string opcionCorrecta = "";
        int contador = 0;

        if (GestionadorDeEscenas.Instancia.getEscena().Equals("ModoContrareloj"))
        {

            opcionCorrecta = GestionadorDeJuegoCronometrado.Instancia.getOpcionCorrecta()[0];

            if (!(Asignador.Instancia.boton1.GetComponentInChildren<Text>().text
            .Equals(opcionCorrecta)) && contador < 2)
            {
                Debug.Log(Asignador.Instancia.boton1.GetComponentInChildren<Text>().text.Equals(opcionCorrecta));
                Asignador.Instancia.mostrarOpcion(Asignador.Instancia.boton1, "");
                contador++;
            }
            if (!(Asignador.Instancia.boton2.GetComponentInChildren<Text>().text
            .Equals(opcionCorrecta)) && contador < 2)
            {
                Asignador.Instancia.mostrarOpcion(Asignador.Instancia.boton2, "");
                contador++;
            }
            if (!(Asignador.Instancia.boton3.GetComponentInChildren<Text>().text
            .Equals(opcionCorrecta)) && contador < 2)
            {
                Asignador.Instancia.mostrarOpcion(Asignador.Instancia.boton3, "");
                contador++;
            }
            if (!(Asignador.Instancia.boton4.GetComponentInChildren<Text>().text
            .Equals(opcionCorrecta)) && contador < 2)
            {
                Asignador.Instancia.mostrarOpcion(Asignador.Instancia.boton4, "");
                contador++;
            }
        }
        else
        {

            opcionCorrecta = GestionadorDeJuegoNormal.Instancia.getOpcionCorrecta()[0];
            if (!(Asignador.Instancia.boton1.GetComponentInChildren<Text>().text
            .Equals(opcionCorrecta)) && contador < 2)
            {
                Asignador.Instancia.mostrarOpcion(Asignador.Instancia.boton1, "");
                contador++;
            }
            if (!(Asignador.Instancia.boton2.GetComponentInChildren<Text>().text
            .Equals(opcionCorrecta)) && contador < 2)
            {
                Asignador.Instancia.mostrarOpcion(Asignador.Instancia.boton2, "");
                contador++;
            }
            if (!(Asignador.Instancia.boton3.GetComponentInChildren<Text>().text
            .Equals(opcionCorrecta)) && contador < 2)
            {
                Asignador.Instancia.mostrarOpcion(Asignador.Instancia.boton3, "");
                contador++;
            }
            if (!(Asignador.Instancia.boton4.GetComponentInChildren<Text>().text
            .Equals(opcionCorrecta)) && contador < 2)
            {
                Asignador.Instancia.mostrarOpcion(Asignador.Instancia.boton4, "");
                contador++;
            }
        }
        powerUpActual = "";
    }

    public void powerUpDoblePuntos()
    {
        puntajeActual = puntajeActual * 2;
        Asignador.Instancia.mostrarPuntaje(textoPuntaje);
        powerUpActual = "";
    }

    //Eliminar una pregunta incorrecta y añadir una nueva
    public void powerUpEliminar()
    {
        preguntasRespondidas--;
        puntajeActual = puntajeActual + 4;
        Asignador.Instancia.mostrarPuntaje(textoPuntaje);
        if (GestionadorDeEscenas.Instancia.getEscena().Equals("ModoContrareloj"))
        {
            Asignador.Instancia.mostrarPreguntasRespondidasSinTotal(textoNumeroDePreguntas);
        }
        else
        {
            Asignador.Instancia.mostrarPreguntasRespondidas(textoNumeroDePreguntas);
        }
        powerUpActual = "";
    }

    public void powerUpMas10()
    {
        Tiempo.Instancia.aumentarTiempo(10);
        powerUpActual = "";
    }
    
    public void resetearControladorPuntaje(){
        powerUpActual = "";
        contadorRacha = 0;
        numeroDePreguntasTotal = 25;
        preguntasRespondidas = 1;
        puntajeActual = 0;
    }
    

}
