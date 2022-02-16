using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GestionadorDeJuego : MonoBehaviour
{
    public Sprite bandera;
    public Image imagen;

    void Start()
    {
        string[] opciones={"Ecuador", "Guayakill","El Sur","HELL"};
        Asignador.Instancia.mostrarOpciones(opciones);
        Asignador.Instancia.mostrarBandera(imagen,bandera);
       // mostrarBandera(imagen,bandera);
        //mostrarOpciones(opciones);
    }

    public void mostrarBandera(Image imagenUI, Sprite banderaACambiar){
        imagenUI.sprite = banderaACambiar;
    }

    public void mostrarOpciones(string[] opciones){
        GameObject boton1 = GameObject.Find("Opcion1");
        GameObject boton2 = GameObject.Find("Opcion2");
        GameObject boton3 = GameObject.Find("Opcion3");
        GameObject boton4 = GameObject.Find("Opcion4");

        boton1.GetComponentInChildren<Text>().text = opciones[0];
        boton2.GetComponentInChildren<Text>().text = opciones[1];
        boton3.GetComponentInChildren<Text>().text = opciones[2];
        boton4.GetComponentInChildren<Text>().text = opciones[3];
    }
    //método para hacer un nivel y llamará a: 

    //leer sprites(banderas) de la carpeta de assets según el nivel

    //seleccionar 4 opciones una de ellas correcta

    //cada que selecciona verificar si es correcta o incorrecta

}