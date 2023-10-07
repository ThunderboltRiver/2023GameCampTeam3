using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassBehaviour : MonoBehaviour
{
    [SerializeField]
    private Score _score;

    [SerializeField]
    private int scorePoint;

    public void SetScore(Score score)
    {
        _score = score;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sickle"))
        {
            _score.AddScores(scorePoint);

            Destroy(gameObject);
        }
    }
}
