using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using static RecogerEmail;
public enum ResultadoJuego //un numerador para saber el resultado del juego
{
    VictoriaJugador1,
    VictoriaJugador2
}
//-----------------------------Envio del Correo-----------------------------//
public class SimpleEmailSender
{
    public static class EmailStatus //mira si el mensaje se ha enviado
    {
        public static bool enviado = false;
        public static string mensaje = "Enviando correo...";
    }

    public static async Task SendEmailAsync(ResultadoJuego resultado) 
    {
        EmailStatus.enviado = false;
        EmailStatus.mensaje = "Enviando correo...";

        if (string.IsNullOrEmpty(PlayerEmail.correo))
        {
            EmailStatus.mensaje = "Correo no válido";
            return;
        }

        await Task.Run(() =>
        {
            try
            {
                string fromEmail = "vsebasjrincon12@gmail.com";
                string password = "ptax pdax wxss hvxc";
                string toEmail = PlayerEmail.correo;

                string body = resultado == ResultadoJuego.VictoriaJugador1
                    ? "Alicia has ganado la partida pero la reina no ha querido.\n" + "Cedele tu lugar :)" //si el jugador 1 gana sale este mensaje
                    : "ciudadano promedio has ganado la partida pero la reina no ha querido.\n" + "Cedele tu lugar :)"; //si no sale este

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(fromEmail);
                mail.To.Add(toEmail);
                mail.Subject = "Ganaste";
                mail.Body = body;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(fromEmail, password),
                    EnableSsl = true
                };

                smtp.Send(mail);

                EmailStatus.enviado = true;
                EmailStatus.mensaje = "Email sended succesfuly";
            }
            catch (Exception ex)
            {
                EmailStatus.enviado = false;
                EmailStatus.mensaje = "Error: \n" + ex.Message;
            }
        });
      }
    }
