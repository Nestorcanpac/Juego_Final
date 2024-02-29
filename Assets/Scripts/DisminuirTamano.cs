using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DisminuirTamano : MonoBehaviour
{
    public float disminucionX = 0.1f;
    public float disminucionY = 0.1f;
    public float disminucionZ = 0.1f;
    private bool colisionOcurrida = false;
    private float tiempoColision;
    private float speedPowerUp = 2.3f;

    void FixedUpdate()
    {
        
        transform.Translate(Vector3.down * speedPowerUp * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        
        if (collider2D.gameObject.name == "Pelota de Beisball")
        {
            Pelota.Instance.speed=10.0f;
            colisionOcurrida = true;
            tiempoColision = Time.time;
            
            GameObject Jugador1 = GameObject.Find("Jugador1");
            GameObject Jugador2 = GameObject.Find("Jugador2");
            
            Vector3 disminucionPersonalizada = new Vector3(disminucionX, disminucionY, disminucionZ);
            
            Jugador1.transform.localScale -= disminucionPersonalizada;
            Jugador2.transform.localScale -= disminucionPersonalizada;
            
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.enabled = false;
        }
            
        if (collider2D.gameObject.name == "DestruyePowerUps")
        {
            
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.enabled = false;
            colisionOcurrida = true;
        }
            
        
    }
    void Update()
    {
        if (colisionOcurrida && Time.time >= tiempoColision + 3f)
        {
            Debug.Log("Cacacacacacacacac");
            GameObject Jugador1 = GameObject.Find("Jugador1");
            GameObject Jugador2 = GameObject.Find("Jugador2");
            colisionOcurrida = false;
            Vector3 normalidad = new Vector3(0.04294116f, 0.0531657f, 1f);
            
            Jugador1.transform.localScale = normalidad;
            Jugador2.transform.localScale = normalidad;
            Destroy(gameObject);
        }
    }

    
}

