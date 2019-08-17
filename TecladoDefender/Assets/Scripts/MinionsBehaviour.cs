using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionsBehaviour : MonoBehaviour
{
    public int tilespercorridos;
    private int numberoftiles;
    public Rigidbody2D rb;
    public bool IsRoaming;
    public float RoamingSpeed;
    private GameObject CurrentTile;
    public string Current;
    public float WaitTime;
    private int y;

    public GameObject[] AllTiles;
    private Vector2 Target;
   // public GameObject Environment;


    // Start is called before the first frame update
    void Start()
    {
        IsRoaming = true;
        tilespercorridos = 0;
        int x = Random.Range(0, AllTiles.Length);
        Target = AllTiles[x].GetComponent<Transform>().position;


       // Environment = GameObject.Find("-----Environment-----");
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Tile" && this.tag == "Starting")
        {
            this.tag = "Explodable";
            //this.GetComponent<CircleCollider2D>().enabled = false;
            CurrentTile = collision.gameObject;
            //Current = CurrentTile.GetComponent<TileBehaviour>().Letra;
            //tilespercorridos += 1;
            SobeNoTile();
        }

        if(collision.tag == "Explodable")
        {

        }
    }

    void SobeNoTile()
    {
        Current = CurrentTile.GetComponent<TileBehaviour>().Letra;
        tilespercorridos += 1;
        StartCoroutine("InBetween");
    }

    void MudaDeTile()
    { 
        y = Random.Range(0, CurrentTile.GetComponent<TileBehaviour>().Neighbours.Length);
        Vector2 newtarget = CurrentTile.GetComponent<TileBehaviour>().Neighbours[y].transform.position;

        CurrentTile = CurrentTile.GetComponent<TileBehaviour>().Neighbours[y];

        Target = newtarget;
        IsRoaming = true;
        //ir para proximo neighbour
    }

    IEnumerator InBetween()
    {
        yield return new WaitForSeconds(WaitTime);
       // if (tilespercorridos < 3)
        {
            MudaDeTile();
        }
       // else Escavar();
    }


    private void Update()
    {
        if (IsRoaming)
            if (Vector3.Distance(transform.position, Target) > 0.001f)
             {
                transform.position = Vector2.MoveTowards(transform.position, Target, RoamingSpeed * Time.deltaTime);
              }
            else
             {
                SobeNoTile();
                IsRoaming = false;
             }
    }

    void Escavar()
    {
        //Escavar
        //Se escavar por tempo t, rouba a tecla
    }

}
