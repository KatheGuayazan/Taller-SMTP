using UnityEngine;

public class Mecanica : MonoBehaviour
{

    public Transform[] jugadores; // asigna aquí los cubos desde el inspector
    public Transform[] posicionesIniciales; // puntos donde se reinician
    public Transform Meta;

    public float velocidadSubida = 3f;
    public int[] puntajes = new int[4];

    private bool juegoActivo = true;

    void Update()
    {
        if (!juegoActivo) return;
        // Controles por teclado
        if (Input.GetKey(KeyCode.W)) MoverJugador(0);
        if (Input.GetKey(KeyCode.UpArrow)) MoverJugador(1);
    }

    void MoverJugador(int id)
    {
            jugadores[id].Translate(Vector3.up * velocidadSubida * Time.deltaTime);
    }

    public void JugadorGana(int id)
    {
        juegoActivo = false;
        puntajes[id]++;
        Debug.Log("¡Jugador " + (id + 1) + " gana! Puntos: " + puntajes[id]);

        Invoke("ReiniciarRonda", 2f); // Espera 2 segundos antes de reiniciar
    }

    void ReiniciarRonda()
    {
        for (int i = 0; i < jugadores.Length; i++)
        {
            jugadores[i].position = posicionesIniciales[i].position;
        }

        juegoActivo = true;
    }
}
