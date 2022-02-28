using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Text;


public class ReadInput : MonoBehaviour
{
    private string input;
    private  string path = "/Datos/";
    private  string filename = "Jugadores.txt";

    private Jugador jugador = new Jugador();


    public void ReadStringInput(string campo)
    {
        input = campo;
        
        Save(input);
    }

    public  void Save(string nombre)
    {
        Jugador jugador = new Jugador();
        jugador.nombre=nombre;
        jugador.puntuacion=0;
        string dir = Application.dataPath + path;
        Debug.Log(dir);
        if (!Directory.Exists(dir)){
                Directory.CreateDirectory(dir);
        }
        string json = JsonUtility.ToJson(jugador);
        File.AppendAllText(dir + filename, json+"\n");
    }

}
