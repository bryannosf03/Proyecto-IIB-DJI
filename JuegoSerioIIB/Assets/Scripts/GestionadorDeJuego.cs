using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class GestionadorDeJuego : MonoBehaviour
{
    public Sprite bandera;
    public Image imagen;
    public SpriteRenderer spriteRenderer;

    private string opcionCorrecta="";

    void Start()
    {
        //Asignador.Instancia.mostrarOpciones(opciones);
        //Asignador.Instancia.mostrarBandera(imagen,bandera);
       // mostrarBandera(imagen,bandera);
       obtenerBandera();
       string[] opciones = seleccionarOpciones();
        mostrarOpciones(opciones);
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

    
    //método para hacer un país(y opciones) y llamará a: 
    public void inicializarJuego(){
        obtenerBandera();
        
        seleccionarOpciones();
    }
    //leer sprites(banderas) de la carpeta de assets según el nivel
    public void obtenerBandera(){
            /*
            TODO: Verificar el nivel en el que estamos(continente)

            1.Tomar un país del array creado
            2.Encontrar el sprite con ese nombre
            3.Asignarle opcion correcta
            4.Llamarle al mostrar bandera
            */
      
        int paisAleatorio=  Random.Range(0,Continentes.America.Length);
        string pais=Continentes.America[paisAleatorio]; //AQUÍ DEBEN IR LOS PAISES
        spriteRenderer.sprite=Resources.Load<Sprite>(pais);
        opcionCorrecta=pais;
        mostrarBandera(imagen,spriteRenderer.sprite);

    }
    //seleccionar 4 opciones una de ellas correcta
    public string[] seleccionarOpciones(){
        string[] opciones = new string[4];

        int paisAleatorio =  Random.Range(0,Continentes.America.Length);

        opciones[0]=Continentes.America[paisAleatorio]; 

        opciones[1]=Continentes.America[paisAleatorio];

        opciones[2]=Continentes.America[paisAleatorio];

        opciones[3]=Continentes.America[paisAleatorio];

        return opciones;

    }
    //cada que selecciona verificar si es correcta o incorrecta
    public void verificarRespuesta(string respuesta){

    }

}