using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionadorDeEscenas : MonoBehaviour
{
    //creo una instacia singleton
    public static GestionadorDeEscenas Instancia;
    private string escenaActual;
    
    void Start(){
        escenaActual=SceneManager.GetActiveScene().name;
        Instancia=this;
    }

    public void cargarEscena (string nombreDeEscena)
    {
        SceneManager.LoadScene(nombreDeEscena);
    }

    public string getEscena(){
        return escenaActual;
    }

    public void Salir(){
        Application.Quit();
    }

}
