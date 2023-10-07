using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassBehaviour : MonoBehaviour
{
    [SerializeField]
    private Score score;

    [SerializeField]
    private int scorePoint;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sickle"))
        {
            score.AddScores(scorePoint);

            Destroy(gameObject);
        }
    }
}
