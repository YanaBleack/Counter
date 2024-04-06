using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private TMP_Text _timerText;

    private float _elapsedTime;
    private bool isCounting;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {           
            if (!isCounting)
            {
                isCounting = true;
                StartCoroutine(RunCounter());
                Debug.Log("Start");
            }
            else
            {
                isCounting = false;
                StopAllCoroutines();
                Debug.Log("Stop");
            }
        }
    }

    private IEnumerator RunCounter()
    {
        var waitForOneSeconds = new WaitForSeconds(_delay);

        while (enabled)
        {
            _elapsedTime++;
            int minutes = Mathf.FloorToInt(_elapsedTime / 60);
            int seconds = Mathf.FloorToInt(_elapsedTime % 60);
            _timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
                                                                    
            yield return waitForOneSeconds;
        }       
    }
}