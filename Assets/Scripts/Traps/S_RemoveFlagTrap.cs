using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_RemoveFlagTrap : MonoBehaviour
{
    public GameObject collectedObject; // Reference to the collected object
    public Transform[] spawnPoints; // Array of spawn points

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider is the player
        if (other.CompareTag("Player"))
        {
            // Remove the collected object and respawn it at a random spawn point
            RespawnCollectedObject();
        }
    }

    private void RespawnCollectedObject()
    {
        // Check if the collected object exists
        if (collectedObject != null)
        {
            // Disable the collected object (assuming it has a Collider component)
            collectedObject.GetComponent<Collider>().enabled = false;

            // Choose a random spawn point from the array
            Transform randomSpawnPoint = GetRandomSpawnPoint();

            // Reposition the collected object to the random spawn point
            collectedObject.transform.position = randomSpawnPoint.position;

            // Enable the collected object (assuming it has a Collider component)
            collectedObject.GetComponent<Collider>().enabled = true;

            Debug.Log("Collected object respawned at " + randomSpawnPoint.position);
        }
        else
        {
            Debug.LogError("Collected object reference not set!");
        }
    }

    private Transform GetRandomSpawnPoint()
    {
        // Check if there are spawn points in the array
        if (spawnPoints.Length > 0)
        {
            // Choose a random index within the array
            int randomIndex = Random.Range(0, spawnPoints.Length);

            // Return the chosen spawn point
            return spawnPoints[randomIndex];
        }
        else
        {
            Debug.LogError("No spawn points available!");
            return null;
        }
    }
}

