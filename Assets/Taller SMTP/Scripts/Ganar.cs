using UnityEngine;
using UnityEngine.SceneManagement;

public class Ganar : MonoBehaviour
{
    public string SigNivel; // Nombre de la escena a cargar
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica si el que choca es el jugador
        {
            Debug.Log("Sirve o no");
            SceneManager.LoadScene(SigNivel); // Carga el nivel
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (other.CompareTag("Fin")) // Verifica si el que choca es el jugador
        {
            Debug.Log("Sirves?");
            SceneManager.LoadScene(SigNivel); // Carga el nivel
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
