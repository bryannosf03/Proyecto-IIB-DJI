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

        int [] opcionesNumeros = new int[4];
        int numeroOpcionCorrecta =0;

        for(int i=0;i<Continentes.America.Length;i++){
            if(Continentes.America[i].Equals(opcionCorrecta)){
                numeroOpcionCorrecta=i;
            }
        }

        opcionesNumeros[0]=numeroOpcionCorrecta;
        for(int j=1;j<4;j++){
            int randomico = Random.Range(0,Continentes.America.Length);
            opcionesNumeros[j]= randomico;
        }

        int l = 0;
        opcionesNumeros= Shuffle(opcionesNumeros,l);
        
        opciones[0]=Continentes.America[opcionesNumeros[0]]; 

        opciones[1]=Continentes.America[opcionesNumeros[1]];

        opciones[2]=Continentes.America[opcionesNumeros[2]];

        opciones[3]=Continentes.America[opcionesNumeros[3]];

        return opciones;

    }
    //cada que selecciona verificar si es correcta o incorrecta
    public void verificarRespuesta(string respuesta){

    }

    public int[] Shuffle(int[] decklist, int tempGO) {
         for (int i = 0; i < decklist.Length; i++) {
             int rnd = Random.Range(0, decklist.Length);
             tempGO = decklist[rnd];
             decklist[rnd] = decklist[i];
             decklist[i] = tempGO;
         }

         return decklist;
    }

}