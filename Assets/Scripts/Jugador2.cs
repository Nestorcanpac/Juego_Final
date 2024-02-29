using UnityEngine;


public class Jugador2 : MonoBehaviour
{
    private float speed = 7f;

    private void FixedUpdate()
    {
        float VerticalDirection = Input.GetAxisRaw("MovimientoP2");

        GetComponent<Rigidbody2D>().velocity = Vector2.up * VerticalDirection * speed;
    }
}