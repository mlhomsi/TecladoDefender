using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionsBehaviour : MonoBehaviour
{
    private char letra;
    private int tilespercorridos;

    // Start is called before the first frame update
    void Start()
    {
        tilespercorridos = 0;
    }

    void Roam()
    {
        //Se move aleatoriamente até atingir um tile;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //desliga o collider;
        //se bater num tile, espere o tempo da animação e mude o transform para aquele tile;
    }

    void SobeNoTile()
    {
        //GetComponent collision.TileBehaviour
        //Sobe no tile;
        //Espera X tempo;
        //se tilespercorridos = y, Escavar
        //else -> MudaDeTile
    }

    void MudaDeTile ()
    {
        //TileBehaviour.randomizar neighbours
        //ir para proximo neighbour
        //vector2d.moveto
    }

    void Escavar ()
    {
        //Escavar
        //Se escavar por tempo t, rouba a tecla
    }

    void Morrer ()
    {
        //ded if input = letra;
    }

}
