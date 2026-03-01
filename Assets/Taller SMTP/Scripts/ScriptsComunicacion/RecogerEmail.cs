using TMPro;
using UnityEngine;

public class RecogerEmail : MonoBehaviour
{
    public TMP_InputField inputCorreo;

    public static class PlayerEmail //Clase para guardar el Correo
    {
        public static string correo = "";
    }

    public void GuardarCorreo()
    {
        PlayerEmail.correo = inputCorreo.text;
        Debug.Log("Correo guardado: " + PlayerEmail.correo);
    }
}
