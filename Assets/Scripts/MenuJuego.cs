using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuJuego : MonoBehaviour
{
    // Variables para referenciar objetos de la interfaz de usuario
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;
  

    // Variable para rastrear si el juego está pausado o no
    private bool juegoPausado = false;


    
    private void Update()
    {
        // Verifica si la tecla Espacio se ha soltado
        if (Input.GetKeyUp(KeyCode.Space))
        {
            // Si el juego está pausado, lo reanuda; de lo contrario, lo pausa
            if (juegoPausado)
            {
                Reanudar();
            }
            else
            {
                Pausa();
            }
        }
    }

    // Método para pausar el juego
    public void Pausa()
    {
        juegoPausado = true;  // Marca el juego como pausado
        Time.timeScale = 0f; // Detiene el tiempo en el juego
        botonPausa.SetActive(false); // Oculta el botón de pausa
        menuPausa.SetActive(true);   // Muestra el menú de pausa
    }

    // Método para reanudar el juego
    public void Reanudar()
    {
        juegoPausado = false;  // Marca el juego como no pausado
        Time.timeScale = 1f;   // Reanuda el tiempo en el juego
        botonPausa.SetActive(true);  // Muestra el botón de pausa
        menuPausa.SetActive(false);  // Oculta el menú de pausa
    }

    // Método para reiniciar el nivel
    public void Reiniciar()
    {
        Time.timeScale = 1f;  // Reanuda el tiempo en el juego
        // Carga la escena actual (reinicia el nivel)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Método para salir del nivel y volver a la escena anterior
    public void Salir()
    {
        // Carga la escena anterior en la secuencia de construcción de escenas
        SceneManager.LoadScene("MenuPrincipal");
    }
}
