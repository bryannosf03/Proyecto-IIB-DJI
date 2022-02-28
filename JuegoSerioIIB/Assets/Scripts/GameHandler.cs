using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameHandler : MonoBehaviour {

    [SerializeField] HighscoreHandler highscoreHandler;
    [SerializeField]  string filename;


    List<InputEntry> entries = new List<InputEntry> ();
    List<InputEntry> entries2 = new List<InputEntry> ();

    public void Start () {
      //  InputHandler inputHandler = new InputHandler();
        //inputHandler.AddNameToList(playerName,ControladorDePuntaje.puntajeActual)

        entries = FileHandler.ReadListFromJSON<InputEntry> (filename);
      
        string nombre = entries[entries.Count - 1].playerName;
        entries[entries.Count - 1].points= ControladorDePuntaje.puntajeActual;

      string path = Application.persistentDataPath + "/" + filename;
//       Debug.Log("Path secujndario"+path);
       FileStream fileStream = File.Open(path, FileMode.Open); 
       fileStream.SetLength(0); 
       fileStream.Close(); 
        System.IO.File.WriteAllText(path,string.Empty);
        FileHandler.SaveToJSON<InputEntry> (entries, filename);

        ordernar();

        highscoreHandler.AddHighscoreIfPossible (new HighscoreElement (nombre, ControladorDePuntaje.puntajeActual));
        Debug.Log("Accede al gamehandler");
    }

    public void ordernar(){
        entries2 = FileHandler.ReadListFromJSON<InputEntry> (filename);
        int puntos=0;
        string nombre="";

        for (int i = 0; i < entries2.Count-1; i++){
            for (int j = 0; j < entries2.Count - i - 1; j++){
                if (entries2[j].points < entries2[j + 1].points)
                {
                    int temp = entries2[j].points;
                    string tempS= entries2[j].playerName;
                    Debug.Log("De la j primera"+entries2[j].points);
                    entries2[j].points = entries2[j + 1].points;
                    Debug.Log("De la j segunda"+entries2[j].points);
                    entries2[j].playerName = entries2[j + 1].playerName;
                    entries2[j + 1].points = temp;
                    entries2[j+1].playerName=tempS;
                    
                }
                

            }
        }
            

        FileHandler.SaveToJSON<InputEntry> (entries2, filename);       
    }
}