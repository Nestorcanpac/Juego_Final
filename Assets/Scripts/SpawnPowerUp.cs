using System.Collections;
using UnityEngine;

public class SpawnPowerUp : MonoBehaviour
{
    public GameObject[] powerUps;
    public float interval = 10f; // Interval between each spawn
    public float speed = 2f; // Adjust the speed as needed

    private void Start()
    {
        // Start the coroutine to spawn the power-up
        StartCoroutine(SpawnBall());
    }

    private IEnumerator SpawnBall()
    {
        while (true)
        {
            // Wait for the specified interval
            yield return new WaitForSeconds(interval);

            // Calculate a new position for the power-up
            float newX = Mathf.PingPong(Time.time * speed, 8) - 4;
            Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z);
            
            int randomIndex = Random.Range(0, powerUps.Length);
            GameObject selectedPowerUp = powerUps[randomIndex];


            // Instantiate the power-up at the new position
            Instantiate(selectedPowerUp, newPosition, Quaternion.identity);
        }
    }
}