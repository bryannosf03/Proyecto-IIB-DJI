using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonido : MonoBehaviour
{

    // Variables de Sonido
    public AudioSource fuenteSonido;

    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        fuenteSonido.clip = clip;
    }

    public void Reproducir(){
        fuenteSonido.Play();
    }
}
