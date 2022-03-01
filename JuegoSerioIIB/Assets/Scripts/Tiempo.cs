using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tiempo: MonoBehaviour
{
    public float tiempoFaltante = 10;
    bool tiempoEstaCorriendo = false;
    public Text textoTiempo;

    float contadorDeTiempo;


    public static Tiempo Instancia;


   
    private void Start()
    {
        Instancia=this;
        contadorDeTiempo=0;
        tiempoEstaCorriendo = true;
    }

    void Update()
    {

        contadorDeTiempo+= Time.deltaTime;
        if (tiempoEstaCorriendo && textoTiempo!=null)
        {
            if (tiempoFaltante > 0)
            {
                tiempoFaltante -= Time.deltaTime;
                mostrarTiempo(tiempoFaltante);
            }
            else
            {
                tiempoFaltante = 0;
                tiempoEstaCorriendo = false;
                finalizarJuego();
            }
        }
        
    }
    void mostrarTiempo(float tiempoAMostrar)
    {
        tiempoAMostrar += 1;
        float minutos = Mathf.FloorToInt(tiempoAMostrar / 60); 
        float segundos = Mathf.FloorToInt(tiempoAMostrar % 60);
        textoTiempo.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }

    public void aumentarTiempo(float tiempoAAumentar){
        tiempoFaltante=tiempoFaltante+tiempoAAumentar;
    }

    public void resetTiempo(){
        contadorDeTiempo=0;
    }

    public float getTiempo(){
        return contadorDeTiempo;
    }

    public void finalizarJuego()
    {
        //escena de tabla de puntajes
        SceneManager.LoadScene("TablaDePuntajes");
    }
}