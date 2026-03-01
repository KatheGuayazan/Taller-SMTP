using TMPro;
using UnityEngine;

public class MailManager : MonoBehaviour
{
    public TMP_Text textoEstadoCorreo;

    void Update()
    {
        textoEstadoCorreo.text = SimpleEmailSender.EmailStatus.mensaje;
        textoEstadoCorreo.color = SimpleEmailSender.EmailStatus.enviado
            ? Color.green
            : Color.red;
    }
}
