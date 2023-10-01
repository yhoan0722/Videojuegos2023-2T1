using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerController : MonoBehaviour
{    
     
    [SerializeField] private GameObject GameOver;
    private AudioSource audioSource;
    public AudioClip monedaSound;
    public AudioClip gameOverSound;
    public Text textoMuertos; 
    public Text textoVidas;
    public Text textoMonedas;
    public float contadorVidas;
    // public int contadorBalas;
    public int contadorMuertos;
    public int contadorMonedas;
    
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        contadorVidas = 3;
        contadorMuertos = 0;
        contadorMonedas = 0;
        
        printVidas();
        printMuertos();
        printMonedas();
        
       
    }
   
    public void perderVidas() {
        contadorVidas--;
        printVidas();
        if(contadorVidas == 0) {
            Time.timeScale = 0;
            audioSource.Stop();
            GameOver.SetActive(true);
            audioSource.PlayOneShot(gameOverSound);
        }
    }
    
    private void printVidas() {
        textoVidas.text = "Vidas: " + contadorVidas;
    }
    
    private void printMuertos() {
        textoMuertos.text = "Muertos: " + contadorMuertos;
    }
    public void matarZombie() {
        contadorMuertos++;
        printMuertos();
        if(contadorMuertos==5){
            SceneManager.LoadScene("Scene2");
        }    
    }
   public void printMonedas() {
        textoMonedas.text = "Monedas: " + contadorMonedas;
    }
     public void comerMonedas() {
        contadorMonedas++;
        audioSource.PlayOneShot(monedaSound);
        printMonedas();
    }
}
