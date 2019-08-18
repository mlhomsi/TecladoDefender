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
    private TileBehaviour CurrentTile;
    public string Current;
    public float WaitTime;
    private int y;

    private Vector2 Target;
 


    // Start is called before the first frame update
    void Start()
    {
        if(rb == null) rb = GetComponent<Rigidbody2D>(); //pega automaticamente rigidbody do minion se o mesmo não estiver setado

        IsRoaming = true;
        tilespercorridos = 0;
        int x = Random.Range(0, WaveController.instance.AllTiles.Length);
        Target = WaveController.instance.AllTiles[x].GetComponent<Transform>().position;

       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Tile" && this.tag == "Starting")
        {
            this.tag = "Explodable";
            //this.GetComponent<CircleCollider2D>().enabled = false;
            CurrentTile = collision.gameObject.GetComponent<TileBehaviour>();
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
        StartCoroutine(InBetween());
    }

    void MudaDeTile()
    { 
        y = Random.Range(0, CurrentTile.Neighbours.Length);
        Vector2 newtarget = CurrentTile.Neighbours[y].transform.position;

        CurrentTile = CurrentTile.Neighbours[y].GetComponent<TileBehaviour>();

        Target = newtarget;
        IsRoaming = true;
        //ir para proximo neighbour
    }

    IEnumerator InBetween()
    {
        yield return new WaitForSeconds(WaitTime);
        if (tilespercorridos < 3 || CurrentTile.gameObject.activeSelf == false)
        {
            MudaDeTile();
        }
        else{
            Escavar();
            StartCoroutine(InBetween()); //reinicia a ação
        }
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
        CurrentTile.tempoAtacado += WaitTime;
        Debug.Log(gameObject + " escavando " + CurrentTile.gameObject + " (" + CurrentTile.tempoAtacado + "/" + CurrentTile.tempoDeVida + ")");
    }

}
