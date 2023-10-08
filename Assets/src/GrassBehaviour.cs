using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

public class GrassBehaviour : MonoBehaviour
{
    [SerializeField]
    private Score _score;

    [SerializeField]
    private int _scorePoint;
    public Action OnCut;

    public void SetScore(Score score, int scorePoint)
    {
        _score = score;
        _scorePoint = scorePoint;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sickle"))
        {
            _score.AddScores(_scorePoint);
            OnCut?.Invoke();
            Destroy(gameObject);
        }
    }
}
