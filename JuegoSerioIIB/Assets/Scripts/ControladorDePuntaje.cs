using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorDePuntaje : MonoBehaviour
{
    //puntaje en este instante
    public static int puntajeActual;

    //numero de preguntas totales
    public static int numeroDePreguntasTotal;

    //numero de preguntas respondidas en este instante
    public static int preguntasRespondidas=1;
    //array con respuestas 0 si fue fallida o 1 si fue correcta
    int[] respuestas;
    public Text textoPuntaje;
    public Text textoNumeroDePreguntas;

    
    //creo una instacia singleton
    public static ControladorDePuntaje Instancia;
    
    void Start()
    {
        Instancia=this;
        respuestas= new int[numeroDePreguntasTotal];
        numeroDePreguntasTotal=25;
    }

    

    public void puntuarRespuestaCorrecta () {
        puntajeActual=puntajeActual+4;
        preguntasRespondidas++;
        Asignador.Instancia.mostrarPuntaje(textoPuntaje);
    }

    public void puntuarRespuestaIncorrecta () {
        puntajeActual=puntajeActual-4;
        if(puntajeActual<0){
            puntajeActual=0;
        }
        preguntasRespondidas++;
        Asignador.Instancia.mostrarPuntaje(textoPuntaje);
    }
}
