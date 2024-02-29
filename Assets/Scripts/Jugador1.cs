using UnityEngine;


public class Jugador1 : MonoBehaviour
{
    private float speed = 7f;

    private void FixedUpdate()
    {
        float VerticalDirection = Input.GetAxisRaw("MovimientoP1");

        GetComponent<Rigidbody2D>().velocity = Vector2.up * VerticalDirection * speed;
    }
    
    
}