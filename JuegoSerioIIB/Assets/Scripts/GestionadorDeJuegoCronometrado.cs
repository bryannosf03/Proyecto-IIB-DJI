using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GestionadorDeJuegoCronometrado : MonoBehaviour
{
    public Image imagen;

    public SpriteRenderer spriteRenderer;

    //Es un array que tiene el nómbre del país correcto y su número en el array, en ese orden
    private string[] opcionCorrecta = { "", "" };

    private string[] nivelActual;

    //creo una instacia singleton
    public static GestionadorDeJuegoCronometrado Instancia;
    


    //tabla de puntajes
    [SerializeField] HighscoreHandler highscoreHandler;
    [SerializeField] string playerName;
    
    void Start(){
        Instancia=this;
        nivelActual = Continentes.Mundo;
        inicializarJuego();
    }

    //método para hacer un nivel y llamará a: 
    public void inicializarJuego()
    {
        obtenerBandera();
        string[] opciones = seleccionarOpciones();
        Asignador.Instancia.mostrarOpciones(opciones);
    }

    public void finalizarJuego()
    {
        ControladorDePuntaje.Instancia.activarPowerUp();
       // SceneManager.LoadScene("TablaDePuntajes");
       GestionadorDeEscenas.Instancia.cargarEscena("TablaDePuntajes");
      
        //TODO mostrar tabla de puntajes
    }
    //leer sprites(banderas) de la carpeta de assets según el nivel
    public void obtenerBandera()
    {
        /*
        1.Tomar un país del array creado
        2.Encontrar el sprite con ese nombre
        3.Asignarle opcion correcta
        4.Llamarle al mostrar bandera
        */

        int paisAleatorio = Random.Range(0, nivelActual.Length);
        string pais = nivelActual[paisAleatorio]; //AQUÍ DEBEN IR LOS PAISES

        opcionCorrecta[0] = pais;
        opcionCorrecta[1] = paisAleatorio + "";
        Debug.Log(opcionCorrecta[0]);

        spriteRenderer.sprite = Resources.Load<Sprite>(pais);
        Asignador.Instancia.mostrarBandera(imagen, spriteRenderer.sprite);

    }

    //seleccionar 4 opciones una de ellas correcta
    public string[] seleccionarOpciones()
    {
        //opciones y sus índices
        string[] opciones = new string[4];
        int[] indicesDeOpciones = new int[4];

        indicesDeOpciones[0] = int.Parse(opcionCorrecta[1]);

        bool flag = false;
        int indiceAuxiliar = 1;
        int randomicoAuxiliar;
        do
        {
            randomicoAuxiliar = Random.Range(0, nivelActual.Length);

            //verifico que no se repita en todo el arreglo
            for (int j = 0; j < 4; j++)
            {
                if (randomicoAuxiliar == indicesDeOpciones[j])
                {//si se repite cambio la flag a false y salgo
                    flag = true;
                    //Debug.Log("Igual" +randomicoAuxiliar+" - indice "+flag);
                    break;
                }
                else //por el contrario la mantengo en verdadera
                    flag = false;

            }

            //Debug.Log(indiceAuxiliar);
            if (indiceAuxiliar < 4 & !flag)
            {
                flag = true;
                //solo si pasó sin novedades, entonces asigno y continuamos con el siguiente índice
                if (flag)
                {
                    //Debug.Log("indice" +indiceAuxiliar+" - indice "+flag);
                    indicesDeOpciones[indiceAuxiliar] = randomicoAuxiliar;
                    indiceAuxiliar++;
                }
            }

        } while (flag);
        //Debug.Log(indicesDeOpciones[0]+"-"+indicesDeOpciones[1]+"-"+indicesDeOpciones[2]+"-"+indicesDeOpciones[3]);
        indicesDeOpciones = BarajarOrdenDeArray(indicesDeOpciones, 0);

        opciones[0] = nivelActual[indicesDeOpciones[0]];
        opciones[1] = nivelActual[indicesDeOpciones[1]];
        opciones[2] = nivelActual[indicesDeOpciones[2]];
        opciones[3] = nivelActual[indicesDeOpciones[3]];

        return opciones;

    }

    //cada que selecciona verificar si es correcta o incorrecta
    public void verificarRespuesta(Text respuesta)
    {

        if (respuesta.text.Equals(opcionCorrecta[0]))
        {
            ControladorDePuntaje.Instancia.puntuarRespuestaCorrecta();
            Asignador.Instancia.mostrarPreguntasRespondidasSinTotal(ControladorDePuntaje.Instancia.textoNumeroDePreguntas);
            Tiempo.Instancia.aumentarTiempo(3.0f);//aumentamos el tiempo
            inicializarJuego();

        }
        else
        {
            ControladorDePuntaje.Instancia.puntuarRespuestaIncorrecta();
            Asignador.Instancia.mostrarPreguntasRespondidasSinTotal(ControladorDePuntaje.Instancia.textoNumeroDePreguntas);
            inicializarJuego();
        }


    }

    //retornar array randomizado
    public int[] BarajarOrdenDeArray(int[] listaABarajar, int tempGO)
    {
        for (int i = 0; i < listaABarajar.Length; i++)
        {
            int rnd = Random.Range(0, listaABarajar.Length);
            tempGO = listaABarajar[rnd];
            listaABarajar[rnd] = listaABarajar[i];
            listaABarajar[i] = tempGO;
        }

        return listaABarajar;
    }

    public string[] getOpcionCorrecta(){
        return opcionCorrecta;
    }

}
