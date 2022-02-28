using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour {
    [SerializeField] public InputField nameInput;
    [SerializeField]  string filename;


    List<InputEntry> entries = new List<InputEntry> ();
    List<InputEntry> entries2 = new List<InputEntry> ();

    public static string name;


    private void Start () {
        entries = FileHandler.ReadListFromJSON<InputEntry> (filename);

    }

    public void AddNameToList () {
        
        entries.Add (new InputEntry (nameInput.text,0));
        nameInput.text = "";

        FileHandler.SaveToJSON<InputEntry> (entries, filename);

    }

   /* public void AddNameToList (string nombre, int puntos) {
        
        entries.Add (new InputEntry (nombre,puntos));
        nameInput.text = "";

        FileHandler.SaveToJSON<InputEntry> (entries, filename);
    }*/
}