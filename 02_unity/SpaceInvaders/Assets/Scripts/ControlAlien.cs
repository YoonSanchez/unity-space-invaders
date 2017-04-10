using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ControlAlien : MonoBehaviour
{
	// Conexión al marcador, para poder actualizarlo
	private GameObject marcador;

	// Por defecto, 100 puntos por cada alien
	public int puntos = 100;
    //  Nivel de vida por cada alien.
    public int vida = 1;

	// Objeto para reproducir la explosión de un alien
	private GameObject efectoExplosion;

	private GameObject nave;

    private float limiteAbajo;

	// Use this for initialization
	void Start ()
	{
		// Localizamos el objeto que contiene el marcador
		marcador = GameObject.Find ("Marcador");

		// Objeto para reproducir la explosión de un alien
		efectoExplosion = GameObject.Find ("EfectoExplosion");

		Time.timeScale = 1;

		nave = GameObject.Find ("Nave");

        // Calculamos la anchura visible de la cámara en pantalla
        float distanciaHorizontal = Camera.main.orthographicSize * Screen.width / Screen.height;

        // Calculamos el límite de abajo.
        limiteAbajo = -1.0f * distanciaHorizontal + 1;
    }
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		// Detectar la colisión entre el alien y otros elementos

		// Necesitamos saber contra qué hemos chocado
		if (coll.gameObject.tag == "disparo") {

			// Sonido de explosión
			GetComponent<AudioSource> ().Play ();

			// El disparo desaparece (cuidado, si tiene eventos no se ejecutan)
			Destroy (coll.gameObject);

            //Restamos uno a su vida.
            vida -= 1;

            if (vida == 0){
                // El alien desaparece (no hace falta retraso para la explosión, está en otro objeto)
                efectoExplosion.GetComponent<AudioSource>().Play();
                Destroy(gameObject);

                // Sumar la puntuación al marcador
                marcador.GetComponent<ControlMarcador>().puntos += puntos;
            }
		} else if (coll.gameObject.tag == "nave") {
			nave.GetComponent<ControlNave>().alive = false;
			Time.timeScale = 0;
		} else if (coll.gameObject.tag == "LimiteJuego"){
            nave.GetComponent<ControlNave>().alive = false;
            Time.timeScale = 0;
        }

        Debug.Log(coll.gameObject.tag);

	}
}
