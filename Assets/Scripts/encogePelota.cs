using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class encogePelota : MonoBehaviour
{
    private bool colisionOcurrida = false;
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
            
            
            Vector3 disminucionPersonalizada = new Vector3(0.003f, 0.003f, 1);
            Pelota.Instance.transform.localScale = disminucionPersonalizada;
            
            
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
           
            GameObject pelota = GameObject.Find("Pelota de Beisball");
            
            colisionOcurrida = false;
            Vector3 normalidad = new Vector3(0.002f, 0.002f, 1);
            
            pelota.transform.localScale = normalidad;
            
            Destroy(gameObject);
        }
    }
}
