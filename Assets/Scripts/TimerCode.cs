using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerCode : MonoBehaviour
{
    float CurrentTime=0f;
    float StartingTime=10f;
    [SerializeField] Text TimerText;
    // Start is called before the first frame update
    void Start()
    {
        CurrentTime = StartingTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime -= 1*Time.deltaTime;
        TimerText.text = CurrentTime.ToString("0");
        if (CurrentTime <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }

    }
}
