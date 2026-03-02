using TMPro;
using UnityEngine;

public class MailManager : MonoBehaviour
{
    public TMP_Text textoEstadoCorreo;

    // Actualiza el estado del correo en cada frame con diferentes colores
    void Update()
    {
        textoEstadoCorreo.text = SimpleEmailSender.EmailStatus.mensaje;
        textoEstadoCorreo.color = SimpleEmailSender.EmailStatus.enviado
            ? Color.green
            : Color.red;
    }
}
