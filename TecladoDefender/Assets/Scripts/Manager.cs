using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Manager : MonoBehaviour
{
    public int NumberOfWaves;
    public int CurrentWave;
    public GameObject Minion;

    public GameObject[] Spawners;

    // Start is called before the first frame update
    void Start()
    {
        CurrentWave = 0;
        StartCoroutine("SendWave");
            //(PlayCountDownAnimation);
        NextWave();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NextWave()
    {
        CurrentWave++;
        if (CurrentWave <= NumberOfWaves)
        {
            //SendWave
        }
        else
        {
            //EndGame
        }
    }

    IEnumerator SendWave ()
    {
        yield return new WaitForSeconds(3f);
        //Instantiate(Minion, Spawners[2].transform);
    }
}
