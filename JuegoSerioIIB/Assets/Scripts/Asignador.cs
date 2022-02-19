using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Asignador : MonoBehaviour
{
    GameObject boton1;
    GameObject boton2;
    GameObject boton3;
    GameObject boton4;

    //creo una instacia singleton
    public static Asignador Instancia;
    
    void Start(){
        Instancia=this;
        boton1 = GameObject.Find("Opcion1");
        boton2 = GameObject.Find("Opcion2");
        boton3 = GameObject.Find("Opcion3");
        boton4 = GameObject.Find("Opcion4");
    }

    //método para mezclar y mostrar opciones en los botones
    public void mostrarOpciones(string[] opciones){
        boton1.GetComponentInChildren<Text>().text = opciones[0];
        boton2.GetComponentInChildren<Text>().text = opciones[1];
        boton3.GetComponentInChildren<Text>().text = opciones[2];
        boton4.GetComponentInChildren<Text>().text = opciones[3];
    }

    //método para cambiar la imágen
    //gameobject donde cambiaremos la imágen y la imagen de la bandera a cambiar
    public void mostrarBandera(Image imagenUI, Sprite banderaACambiar){
        imagenUI.sprite = banderaACambiar;
    }

    public void mostrarPuntaje(Text textPuntaje){
        textPuntaje.text = ControladorDePuntaje.puntajeActual+"";
    }

    public void mostrarPreguntasRespondidas(Text textPreguntasRespondidas){
        textPreguntasRespondidas.text = ControladorDePuntaje.preguntasRespondidas + "/"+ ControladorDePuntaje.numeroDePreguntasTotal;
    }
    
    public void mostrarPreguntasRespondidasSinTotal(Text textPreguntasRespondidas){
        textPreguntasRespondidas.text = ""+ControladorDePuntaje.preguntasRespondidas;
    }
}
