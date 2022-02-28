using UnityEngine;

public class SaveTest: MonoBehaviour
{
    public Jugador jugador;



    public void Update(){
        SaveManager.Save(jugador);
    }


}