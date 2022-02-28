using UnityEngine;
using System.IO;

public static class SaveManager
{

    public static string path = "/Datos/";
    public static string filename = "Jugadores.txt";

    public static void Save(Jugador jugador)
    {
        string dir = Application.persistentDataPath + path;
        Debug.Log(dir);
        if (!Directory.Exists(dir)){
                Directory.CreateDirectory(dir);
        }
            

        string json = JsonUtility.ToJson(jugador);
        File.AppendAllText(dir + filename, json);

    }
    public static Jugador Load()
    {
        string fullPath = Application.persistentDataPath + path + filename;
        Jugador jugador = new Jugador();

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            jugador = JsonUtility.FromJson<Jugador>(json);
        }
        else
        {
            Debug.Log("No existe documento donde guardar");
        }
        return jugador;

    }

}


