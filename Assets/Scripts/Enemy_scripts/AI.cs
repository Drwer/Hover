using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AI : MonoBehaviour
{

    public float moveSpeed = 3f;
    public float detectionRadius = 5f;

    private GameObject targetObject;

    void Update()
    {
        // Cerca l'oggetto nelle vicinanze
        SearchForObjects();

        // Se c'è un oggetto da raccogliere, muoviti verso di esso
        if (targetObject != null)
        {
            MoveTowardsObject();
        }
    }

    void SearchForObjects()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius);

        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag("Flag"))
            {
                // Trovato un oggetto da raccogliere
                targetObject = collider.gameObject;
                return;
            }
        }

        // Nessun oggetto da raccogliere trovato
        targetObject = null;
    }

    void MoveTowardsObject()
    {
        // Muovi verso l'oggetto
        Vector3 direction = (targetObject.transform.position - transform.position).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime);

        // Se l'oggetto è raggiunto, raccoglilo e resetta il target
        float distanceToTarget = Vector3.Distance(transform.position, targetObject.transform.position);
        if (distanceToTarget < 1f)
        {
            CollectObject();
            targetObject = null;
        }
    }

    void CollectObject()
    {
        // Esegui l'azione di raccolta (rimuovi l'oggetto, incrementa il punteggio, ecc.)
        Destroy(targetObject);
        // Aggiungi qui il codice per gestire la raccolta dell'oggetto
    }
}

