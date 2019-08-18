using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class WaveData{
    [Tooltip("Quantos minions a wave possui")] public int numMinions = 1;
    [Tooltip("Velocidade dos minions")] public float RoamingSpeed = 1;
    [Tooltip("WaitTime dos minions")] public float WaitTime = 1;
}

public class WaveController : MonoBehaviour
{
    public static WaveController instance;
    int curWave;
    public WaveData[] waves;
    [Tooltip("Prefab dos minions")]public GameObject minionsPrefab;
    [Tooltip("Teclas")]public List<GameObject> AllTiles;
    public Text waveText;
    public AudioSource waveSound;

    void Awake(){
        if(instance == null) instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        curWave = 0;
        StartWave();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount == 0){ //não há mais minions vivos
            NextWave();
        }
    }

    /// <summary>
    /// Muda a wave atual
    /// </summary>
    void NextWave(){
        curWave++; //Vai pra próxima wave
        if(curWave >= waves.Length) Manager.instance.WinScreen();
        else StartWave(); //Configura próxima wave
    }

    /// <summary>
    /// Inicia a wave
    /// </summary>
    void StartWave(){
        //muda texto da wave
        waveText.text = "Wave: " + curWave;

        //instancia minions
        for(int i = 0; i < waves[curWave].numMinions; i++){
            GameObject obj = Instantiate(minionsPrefab, GetRandomStartPos(), Quaternion.identity, transform);
            ConfigureMinion(obj);
        }

        //som
        waveSound.Play();

    }

    /// <summary>
    /// Randomiza a posição inicial do minion
    /// </summary>
    /// <returns>Vector3 contendo a posição inicial do minion</returns>
    Vector3 GetRandomStartPos(){
        //Por enquanto, pega uma posição aleatória na borda da tela
        int xMin = -10, xMax = 10, yMin = -5, yMax = 5;
        
        int rand = Random.Range(0,4);
        Vector3 ret = Vector3.zero;

        switch(rand){
            case 0: //bottom
                ret += new Vector3(Random.Range(xMin, xMax), yMax, 0);
                break;
            case 1: //up
                ret += new Vector3(Random.Range(xMin, xMax), yMin, 0);
                break;
            case 2: //right
                ret += new Vector3(xMax, Random.Range(yMin, yMax), 0);
                break;
            case 3: //left
                ret += new Vector3(xMin, Random.Range(yMin,yMax), 0);
                break;
        }
        return ret;
    }

    /// <summary>
    /// Joga as configurações da wave no minion
    /// </summary>
    /// <param name="obj">GameObject do minion configurado</param>
    void ConfigureMinion(GameObject obj){
        MinionsBehaviour minion = obj.GetComponent<MinionsBehaviour>();
        minion.WaitTime = waves[curWave].WaitTime;
        minion.RoamingSpeed = waves[curWave].RoamingSpeed;
    }
}
