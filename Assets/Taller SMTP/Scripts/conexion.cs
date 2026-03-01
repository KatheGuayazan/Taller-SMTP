using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class conexion : MonoBehaviour
{
    //-----------------------------Deteccion de modelos-----------------------------//
    public Transform Jugador1;        // Cubo controlado por sensor A
    public Transform Jugador2;        // Cubo controlado por sensor B

    public Transform PosJugador1; // posicion inicial jugador1
    public Transform PosJugador2; // posicion inicial jugador2
    public Transform meta;        // referencia a la plataforma

    //-----------------------------Puntaje-----------------------------//
    int puntosJugador1 = 0; // puntos
    int puntosJugador2 = 0;
    int maxPuntos = 3;

    //-----------------------------UI-----------------------------//
    public Image barraPuntos1;
    public Image barraPuntos2;
    public Text textoCuenta;
    //-----------------------------Valores pre establecidos-----------------------------//
    public float movimientoCubo = 3f; // velocidad del movimiento
    bool juegoIniciado = false;

    //-----------------------------Inicia el programa-----------------------------//
    void Start()
    {
        // Asegurarnos de que las barras inician vacias
        barraPuntos1.fillAmount = 0f;
        barraPuntos2.fillAmount = 0f;

        StartCoroutine(Cuenta());
    }

    //-----------------------------Corrutina-----------------------------//
    IEnumerator Cuenta()
    {
        textoCuenta.gameObject.SetActive(true); //Activa la cuenta

        textoCuenta.text = "3";
        yield return new WaitForSeconds(1f);

        textoCuenta.text = "2";
        yield return new WaitForSeconds(1f);

        textoCuenta.text = "1";
        yield return new WaitForSeconds(1f);

        textoCuenta.text = "¡VAMOS!";
        yield return new WaitForSeconds(1f); 

        textoCuenta.gameObject.SetActive(false); //Desactiva la cuenta
        Debug.Log("sirve");

        juegoIniciado = true; //Ahora si empieza el juego bb
    }
    //-----------------------------El mientras se ejecuta-----------------------------//
    void Update()
    {
        if (!juegoIniciado) return; //para que no se muevan los cubos
        
        // Controles por teclado
        if (Input.GetKey(KeyCode.W))
            Jugador1.Translate(Vector3.up * movimientoCubo * Time.deltaTime);

        if (Input.GetKey(KeyCode.UpArrow))
            Jugador2.Translate(Vector3.up * movimientoCubo * Time.deltaTime);

        RevisarMeta(Jugador1, PosJugador1,1); //llamado de la funcion
        RevisarMeta(Jugador2, PosJugador2,2);
    }

    //-----------------------------Programacion para la posicion segun llegue al limite-----------------------------//
    void RevisarMeta(Transform Jugador, Transform posInicial, int jugador)
    {
        // Si el cubo esta a la altura de la plataforma (o mas arriba)
        if (Jugador.position.y >= meta.position.y)
        {
            // sumar puntos al jugador correcto
            if (jugador == 1)
                SumarPlayer1();
            else
                SumarPlayer2();

            // Reiniciar cubo a su posicion inicial
            Jugador.position = posInicial.position;
        }
    }

    //-----------------------------Puntaje del jugador 1-----------------------------//
    void SumarPlayer1()
    {
        if (puntosJugador1 >= maxPuntos) return;

        puntosJugador1++; //Suma de puntos
        barraPuntos1.fillAmount = (float)puntosJugador1 / maxPuntos; //aparece la imagen

        if (puntosJugador1 == maxPuntos) 
        {
            _ = SimpleEmailSender.SendEmailAsync(ResultadoJuego.VictoriaJugador1);
            GameManager.CursorVisible(true);
            SceneManager.LoadScene("Ganaste");
        }
    }

    //-----------------------------Puntaje del jugador 2-----------------------------//
    void SumarPlayer2()
    {
        if (puntosJugador2 >= maxPuntos) return;

        puntosJugador2++; //Suma de puntos
        barraPuntos2.fillAmount = (float)puntosJugador2 / maxPuntos; //aparece la imagen

        if (puntosJugador2 == maxPuntos)
        {
            _ = SimpleEmailSender.SendEmailAsync(ResultadoJuego.VictoriaJugador2);
            GameManager.CursorVisible(true);
            SceneManager.LoadScene("Ganaste");
        }
    }    
}

