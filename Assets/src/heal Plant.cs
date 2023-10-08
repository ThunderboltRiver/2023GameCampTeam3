using UnityEngine;
using TMPro;
public class HealPlant : MonoBehaviour

{
    [SerializeField]
    private TextMeshProUGUI testText;


    [SerializeField]
    private Timer _timer;
    private int _timerPoint;
    public void SetTimer(Timer timer, int timerPoint)
    { 
        _timer = timer;
        _timerPoint = timerPoint;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sickle"))
        {
            _timer.AddTime(_timerPoint);
            Destroy(gameObject);
        }
    }
}