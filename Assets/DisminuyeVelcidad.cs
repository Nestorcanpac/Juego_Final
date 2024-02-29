using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisminuyeVelcidad : MonoBehaviour
{
    private bool colisionOcurrida = false;
    private float tiempoColision;
    private float speed;
    private float speedPowerUp = 2.3f;

    void FixedUpdate()
    {
        
        transform.Translate(Vector3.down * speedPowerUp * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        speed = Pelota.Instance.speed;
        if (col.gameObject.name == "Pelota de Beisball")
        {
            colisionOcurrida = true;
            tiempoColision = Time.time;
            Pelota.Instance.speed = Pelota.Instance.speed + 4f;
    
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.enabled = false;
            
            
        }
        if (col.gameObject.name == "DestruyePowerUps")
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
            Pelota.Instance.speed = speed;
            colisionOcurrida = false;
            Destroy(gameObject);
        }
    }
    
    
}
