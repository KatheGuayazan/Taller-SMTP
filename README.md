# Taller SMTP
<!-- Evento que dispara la notificación -->
## Evento que dispara la notificación

El evento que dispara la notificación es la finalización de la partida cuando uno de los jugadores alcanza el puntaje máximo.  
Dependiendo del jugador ganador, el sistema genera un mensaje de correo diferente, adaptado al resultado del juego.

---

<!-- Flujo básico de envío SMTP -->
## Flujo de envío SMTP

![Flujo de envío SMTP](Assets/Flujo.png)

---

<!-- Manejo de respuestas del servidor -->
## Manejo de respuestas del servidor

El manejo de las respuestas del servidor se realiza mediante la captura de las acciones del servidor SMTP durante el proceso de envío del correo.  
Si el mensaje se envía correctamente, el sistema actualiza su estado indicando el éxito de la operación.  
En caso de que ocurra un error durante el envío, el sistema captura la excepción correspondiente y actualiza el estado con un mensaje descriptivo.

Este estado es posteriormente notificado al usuario al finalizar la partida, a través de la interfaz gráfica del juego.

---