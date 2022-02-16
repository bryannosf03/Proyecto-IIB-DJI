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
    }

    //método para hacer un nivel y llamará a: 

    //leer sprites de la carpeta de assets según el nivel

    //seleccionar 4 opciones una de ellas correcta

    //cada que selecciona verificar si es correcta o incorrecta

}
