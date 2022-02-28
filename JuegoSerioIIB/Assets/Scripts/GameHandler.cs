using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameHandler : MonoBehaviour {

    [SerializeField] HighscoreHandler highscoreHandler;
    //[SerializeField] string playerName;
    [SerializeField]  string filename;


    List<InputEntry> entries = new List<InputEntry> ();
  //  List<InputEntry> entries2 = new List<InputEntry> ();

    public void Start () {
      //  InputHandler inputHandler = new InputHandler();
        //inputHandler.AddNameToList(playerName,ControladorDePuntaje.puntajeActual)

        entries = FileHandler.ReadListFromJSON<InputEntry> (filename);
        string nombre = entries[entries.Count - 1].playerName;
        entries[entries.Count - 1].points=ControladorDePuntaje.puntajeActual;

        string path = Application.persistentDataPath + "/" + filename;
       

        System.IO.File.WriteAllText(path,string.Empty);


        FileHandler.SaveToJSON<InputEntry> (entries, filename);
        //highscoreHandler.AddHighscoreIfPossible (new HighscoreElement (nombre, ControladorDePuntaje.puntajeActual));
        Debug.Log("Accede al gamehandler");
    }
}