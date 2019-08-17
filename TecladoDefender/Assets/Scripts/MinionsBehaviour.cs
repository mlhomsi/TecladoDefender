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
    public KeyCode theKey = KeyCode.None;


    public GameObject[] AllTiles;
    private Vector2 Target;


    // Start is called before the first frame update
    void Start()
    {
        IsRoaming = true;
        tilespercorridos = 0;
        int x = Random.Range(0, AllTiles.Length);
        Target = AllTiles[x].GetComponent<Transform>().position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Tile")
        {
            this.GetComponent<CircleCollider2D>().enabled = false;
            CurrentTile = collision.gameObject;
            //Current = CurrentTile.GetComponent<TileBehaviour>().Letra;
            //tilespercorridos += 1;
            SobeNoTile();
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
        //Debug.Log("mudando");
        y = Random.Range(0, CurrentTile.GetComponent<TileBehaviour>().Neighbours.Length);
        Vector2 newtarget = CurrentTile.GetComponent<TileBehaviour>().Neighbours[y].transform.position;

        CurrentTile = CurrentTile.GetComponent<TileBehaviour>().Neighbours[y];

        //Debug.Log(newtarget);
        Target = newtarget;
        IsRoaming = true;
        //ir para proximo neighbour
        //vector2d.moveto
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
        Morrer();
    }

    void Escavar()
    {
        //Escavar
        //Se escavar por tempo t, rouba a tecla
    }

    void Morrer()
    {
        //ded if input = letra;
        if (Input.GetKey(theKey))
        {
            this.gameObject.SetActive(false);
        }
    }
}
