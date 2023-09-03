using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerController : MonoBehaviour
{    
    public Text textoMuertos; 
    public Text textoVidas;
    public Text textoHongos;
    public int contadorVidas;
    // public int contadorBalas;
    public int contadorMuertos;
    public int contadorHongos;
    
    // Start is called before the first frame update
    void Start()
    {
        
        contadorVidas = 3;
        contadorMuertos = 0;
        contadorHongos = 0;
        
        printVidas();
        printMuertos();
        printHongos();
       
    }

    public void perderVidas() {
        contadorVidas--;
        printVidas();
        if(contadorVidas == 0) {
            Time.timeScale = 0;
        }
    }
    
    private void printVidas() {
        textoVidas.text = "VIDAS: " + contadorVidas;
    }
    
    private void printMuertos() {
        textoMuertos.text = "Muertos: " + contadorMuertos;
    }
    public void matarZombie() {
        contadorMuertos++;
        printMuertos();
    }
   public void printHongos() {
        textoHongos.text = "Hongos: " + contadorHongos;
    }
     public void comerHongos() {
        contadorHongos++;
        printHongos();
    }
}
