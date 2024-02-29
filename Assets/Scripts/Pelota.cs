using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class Pelota : MonoBehaviour
{

    public static Pelota Instance;
    public float speed = 10f;
    private int golJugador1;
    private int golJugador2;
    public TextMeshProUGUI text;
    public TextMeshProUGUI textoGanar;

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        golJugador1 = 0;
        golJugador2 = 0;
        text.text = "Puntos 0 | 0";
    }
    
    float hitFactor(Vector2 ballPos, Vector2 racketPos,
        float racketHeight) {
        return (ballPos.y - racketPos.y) / racketHeight;
    }
    
    
    void OnCollisionEnter2D(Collision2D col)
    {
        speed= speed+ 0.15f;
        GameObject Jugador1 = GameObject.Find("Jugador1");
        GameObject Jugador2 = GameObject.Find("Jugador2");
        if (col.gameObject.name == "ObjetoCampoIzquierda")
        {
            golJugador1++;
            if (golJugador1 == 5)
            {
               
                transform.position = new Vector3(0, 0, transform.position.z);
                Jugador1.transform.position = new Vector3(-6.71f , 0, transform.position.z);
                Jugador2.transform.position = new Vector3(6.71f, 0, transform.position.z);
                
                StartCoroutine(PauseForSeconds2(2f));
                textoGanar.text = " ";
                GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
                
            }
            else
            {
                text.text = "Puntos: " + golJugador2 + " | " + golJugador1;
                StartCoroutine(PauseForSeconds(2f));
                transform.position = new Vector3(0, 0, transform.position.z);
            }
            
        }
        if (col.gameObject.name == "ObjetoCampoDerecha")
        {
            golJugador2++;
            
            if (golJugador2 == 5)
            {
                
                transform.position = new Vector3(0, 0, transform.position.z);
                Jugador1.transform.position = new Vector3(-6.71f , 0, transform.position.z);
                Jugador2.transform.position = new Vector3(6.71f, 0, transform.position.z);
                
                StartCoroutine(PauseForSeconds2(2f));
                textoGanar.text = " ";


            }
            else
            {
                text.text = "Puntos: " + golJugador2 + " | " + golJugador1;
                StartCoroutine(PauseForSeconds(2f));
                transform.position = new Vector3(0, 0, transform.position.z);
                
            }
            
            
            
        }
        
        
        if (col.gameObject.name == "Jugador1" || col.gameObject.name == "Jugador2") 
        {          
            
            float x = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.x);
            float angle = x * Mathf.PI / 2; 
            Vector2 dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed; 
        }

    }
    
    IEnumerator PauseForSeconds(float seconds)
    {
        speed = 7f;
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(seconds); 
        Time.timeScale = 1f;
        

    }
    IEnumerator PauseForSeconds2(float seconds)
    {
        Start();
        speed = 7f;
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(seconds); 
        Time.timeScale = 1f;
    }


}
