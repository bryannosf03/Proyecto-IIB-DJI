using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorDePuntaje : MonoBehaviour
{
    //puntaje en este instante
    public static int puntajeActual;

    //numero de preguntas totales
    public static int numeroDePreguntasTotal;

    //numero de preguntas respondidas en este instante
    public static int preguntasRespondidas=1;

    //si lelga a cino doy un power up
    int contadorRacha;

    //powerUp actual
    string powerUpActual;

    public Text textoPuntaje;
    public Text textoNumeroDePreguntas;
    public SpriteRenderer spriteRenderer;

    
    //creo una instacia singleton
    public static ControladorDePuntaje Instancia;
    
    void Start()
    {
        powerUpActual="";
        contadorRacha=0;
        Instancia=this;
        numeroDePreguntasTotal=25;
    }

    

    public void puntuarRespuestaCorrecta () {
        puntajeActual=puntajeActual+4;
        preguntasRespondidas++;
        Asignador.Instancia.mostrarPuntaje(textoPuntaje);
        contadorRacha=contadorRacha + 1 ;
        Debug.Log(contadorRacha);
        verificarRacha();
    }

    public void puntuarRespuestaIncorrecta () {
        puntajeActual=puntajeActual-4;
        if(puntajeActual<0){
            puntajeActual=0;
        }
        preguntasRespondidas++;
        Asignador.Instancia.mostrarPuntaje(textoPuntaje);
        contadorRacha=0;
    }

    public void verificarRacha(){
        if(contadorRacha==5){
            getPowerUp();
            spriteRenderer.sprite = Resources.Load<Sprite>(powerUpActual);
            foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
            {
                if (go.name.Equals("BotonPowerUps")){
                    Asignador.Instancia.mostrarPowerUp(go,spriteRenderer.sprite);
                    break;
                }
            }
            
        }
    }

    //de manera randómica nos devuelve un power up
    public void getPowerUp(){
        int numeroRandomico;
        if(GestionadorDeEscenas.Instancia.getEscena().Equals("ModoContrareloj")){//verifico en que escena estoy
            string[] powerUps = {"PU5050","PUDoblePuntos","PUEliminar","PUMas10"};
            numeroRandomico = Random.Range(0, 4);
            powerUpActual=powerUps[numeroRandomico];
        }else{
            string[] powerUps = {"PU5050","PUDoblePuntos","PUEliminar"};
            numeroRandomico = Random.Range(0, 3);
            powerUpActual=powerUps[numeroRandomico];
        }
    }

    public void activarPowerUp(){
        contadorRacha=0;
        switch (powerUpActual) {
              
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

    public void powerUp5050() {
        
        if(GestionadorDeEscenas.Instancia.getEscena().Equals("ModoContrareloj")){
            int contador=0;
            if(!(Asignador.Instancia.boton1.GetComponentInChildren<Text>().text
            .Equals(GestionadorDeJuegoCronometrado.Instancia.getOpcionCorrecta()))&&contador<2){
                Debug.Log(Asignador.Instancia.boton1.GetComponentInChildren<Text>().text.Equals(GestionadorDeJuegoCronometrado.Instancia.getOpcionCorrecta()));
                Asignador.Instancia.mostrarOpcion(Asignador.Instancia.boton1,"");
                contador++;
            }
            if(!(Asignador.Instancia.boton2.GetComponentInChildren<Text>().text
            .Equals(GestionadorDeJuegoCronometrado.Instancia.getOpcionCorrecta()))&&contador<2){
                Asignador.Instancia.mostrarOpcion(Asignador.Instancia.boton2,"");
                contador++;
            }
            if(!(Asignador.Instancia.boton3.GetComponentInChildren<Text>().text
            .Equals(GestionadorDeJuegoCronometrado.Instancia.getOpcionCorrecta()))&&contador<2){
                Asignador.Instancia.mostrarOpcion(Asignador.Instancia.boton3,"");
                contador++;
            }
            if(!(Asignador.Instancia.boton4.GetComponentInChildren<Text>().text
            .Equals(GestionadorDeJuegoCronometrado.Instancia.getOpcionCorrecta()))&&contador<2){
                Asignador.Instancia.mostrarOpcion(Asignador.Instancia.boton4,"");
                contador++;
            }
        }else{
            int contador=0;
            if(!(Asignador.Instancia.boton1.GetComponentInChildren<Text>().text
            .Equals(GestionadorDeJuegoNormal.Instancia.getOpcionCorrecta()))&&contador<2){
                Asignador.Instancia.mostrarOpcion(Asignador.Instancia.boton1,"");
                contador++;
            }
            if(!(Asignador.Instancia.boton2.GetComponentInChildren<Text>().text
            .Equals(GestionadorDeJuegoNormal.Instancia.getOpcionCorrecta()))&&contador<2){
                Asignador.Instancia.mostrarOpcion(Asignador.Instancia.boton2,"");
                contador++;
            }
            if(!(Asignador.Instancia.boton3.GetComponentInChildren<Text>().text
            .Equals(GestionadorDeJuegoNormal.Instancia.getOpcionCorrecta()))&&contador<2){
                Asignador.Instancia.mostrarOpcion(Asignador.Instancia.boton3,"");
                contador++;
            }
            if(!(Asignador.Instancia.boton4.GetComponentInChildren<Text>().text
            .Equals(GestionadorDeJuegoNormal.Instancia.getOpcionCorrecta()))&&contador<2){
                Asignador.Instancia.mostrarOpcion(Asignador.Instancia.boton4,"");
                contador++;
            }
        }
        powerUpActual="";
    }

    public void powerUpDoblePuntos() {
        puntajeActual=puntajeActual*2;
        Asignador.Instancia.mostrarPuntaje(textoPuntaje);
        powerUpActual="";
    }

    //Eliminar una pregunta incorrecta y añadir una nueva
    public void powerUpEliminar() {
        preguntasRespondidas--;
        puntajeActual=puntajeActual+4;
        Asignador.Instancia.mostrarPuntaje(textoPuntaje);
        if(GestionadorDeEscenas.Instancia.getEscena().Equals("ModoContrareloj")){
            Asignador.Instancia.mostrarPreguntasRespondidasSinTotal(textoNumeroDePreguntas);
        }else{
            Asignador.Instancia.mostrarPreguntasRespondidas(textoNumeroDePreguntas);
        }
        powerUpActual="";
    }

    public void powerUpMas10() {
        Tiempo.Instancia.aumentarTiempo(10);
        powerUpActual="";
    }

    
}
