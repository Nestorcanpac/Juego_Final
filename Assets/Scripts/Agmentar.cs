using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agmentar : MonoBehaviour
{
    private bool colisionOcurrida = false;
    public float disminucionZ;
    private float tiempoColision;
    private float speedPowerUp = 2.3f;

    void FixedUpdate()
    {
        
        transform.Translate(Vector3.down * speedPowerUp * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
      
        if (collision.gameObject.name == "Pelota de Beisball")
        {
            
            colisionOcurrida = true;
            tiempoColision = Time.time;
            GameObject Jugador1 = GameObject.Find("Jugador1");
            GameObject Jugador2 = GameObject.Find("Jugador2");
            
            Vector3 augmentoPersonalizada = new Vector3(0.03294116f, 0.0431657f, disminucionZ);
            Jugador1.transform.localScale = augmentoPersonalizada;
            Jugador2.transform.localScale = augmentoPersonalizada;
            
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.enabled = false;
            
        }

        if (collision.gameObject.name == "DestruyePowerUps")
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
