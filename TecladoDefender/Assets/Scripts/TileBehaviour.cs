using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehaviour : MonoBehaviour
{
    public string Letra;
    public GameObject[] Neighbours;
    public string pressedbutton;

    public GameObject Explosion;
    //public KeyCode vkey;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(vKey))
            {
                //your code here
                Debug.Log(vKey);
                pressedbutton = vKey.ToString();

            }
        }
        if(Input.anyKey == false)
        {
            pressedbutton = null;
        }

        if(pressedbutton == Letra)
        {
            Explosion.SetActive(true);
        } else { Explosion.SetActive(false); }

    }
}
