using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Asignador : MonoBehaviour
{
    public GameObject boton1;
    public GameObject boton2;
    public GameObject boton3;
    public GameObject boton4;
    public GameObject canvasGameObject;

    public Canvas canvas;


    //creo una instacia singleton
    public static Asignador Instancia;
    
    void Start(){
        Instancia=this;
        boton1 = GameObject.Find("Opcion1");
        boton2 = GameObject.Find("Opcion2");
        boton3 = GameObject.Find("Opcion3");
        boton4 = GameObject.Find("Opcion4");
        canvasGameObject =  GameObject.FindGameObjectsWithTag("CanvasMenu")[0];
        canvas = canvasGameObject.GetComponent<Canvas>();
    }

    //método para mezclar y mostrar opciones en los botones
    public void mostrarOpciones(string[] opciones){
        boton1.GetComponentInChildren<Text>().text = opciones[0];
        boton2.GetComponentInChildren<Text>().text = opciones[1];
        boton3.GetComponentInChildren<Text>().text = opciones[2];
        boton4.GetComponentInChildren<Text>().text = opciones[3];
    }

    public void mostrarOpcion(GameObject boton,string opcion){
        boton.GetComponentInChildren<Text>().text = opcion;
    }

    //método para cambiar la imágen
    //gameobject donde cambiaremos la imágen y la imagen de la bandera a cambiar
    public void mostrarBandera(Image imagenUI, Sprite banderaACambiar){
        imagenUI.sprite = banderaACambiar;
    }

      //método para cambiar la imágen de fondo
    //gameobject donde cambiaremos la imágen y la imagen de la bandera a cambiar
    public void mostrarContinente(Sprite spriterenderer){
        canvas.GetComponent<Image>().sprite = spriterenderer;
    }

    // Cambiar Color Panel Correcta
    public void cambiarPanel(Image panel, Sprite color){
        panel.sprite = color;
    }


    public void mostrarPuntaje(Text textPuntaje){
        textPuntaje.text = ControladorDePuntaje.puntajeActual+"";
    }

    public void mostrarPowerUp(GameObject powerUp, Sprite imagenACambiar){
        powerUp.SetActive(true);
        powerUp.GetComponent<Image>().sprite = imagenACambiar;
    }

    public void mostrarPreguntasRespondidas(Text textPreguntasRespondidas){
        textPreguntasRespondidas.text = ControladorDePuntaje.preguntasRespondidas + "/"+ ControladorDePuntaje.numeroDePreguntasTotal;
    }
    
    public void mostrarPreguntasRespondidasSinTotal(Text textPreguntasRespondidas){
        textPreguntasRespondidas.text = ""+ControladorDePuntaje.preguntasRespondidas;
    }


}
