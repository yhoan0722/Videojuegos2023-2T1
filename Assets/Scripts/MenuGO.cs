using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGO : MonoBehaviour
{
    
   public void Reiniciar()
    {
        Time.timeScale = 1f;  // Reanuda el tiempo en el juego
        // Carga la escena actual (reinicia el nivel)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }


    // Este método es llamado cuando el botón "Salir" es presionado
    public void Salir()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
