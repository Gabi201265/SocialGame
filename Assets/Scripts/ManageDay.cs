using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageDay : MonoBehaviour
{
    float time;
    public float timerInterval = 5f;
    float tick;
    int nbDay;
    public int MaxNbDay=20;

    public int getNbDay()
    {
        return this.nbDay;
    }

    public void setNbDay(int pNbDay)
    {
        this.nbDay = pNbDay;
    }
    // Start is called before the first frame update
    void Awake()
    {
        time = (int)Time.time;
        tick = timerInterval;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = nbDay.ToString();
        time = (int)Time.time;
        if (time == tick)
        {
            tick = time + timerInterval;
            nbDay++;
        }
        if (nbDay == MaxNbDay)
        {
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
    }
}
