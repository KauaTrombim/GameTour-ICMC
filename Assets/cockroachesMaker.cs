using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cockroachesMaker : MonoBehaviour
{
    [SerializeField]
    GameObject ckrtPrefab;

    //ckrtMovimentAndColision

    [SerializeField]
    public float[] columns = new float[4] {-2.5f, -0.75f, 0.75f, 2.50f};
    float row = 6.2f;
    public float spawnDelay = 20.5f;
    public float lastSpawn;

    void Start()
    {
         
    }

    void Update()
    {
        if(Time.time > (lastSpawn + spawnDelay))
        {
            createCkrt();
        }

    }

    void createCkrt()
    {
        
        for (int i = 0; i < (columns.Length); i++)
        {
            Vector2 pos = new Vector2(columns[i], row);
            Instantiate(ckrtPrefab, pos, Quaternion.identity);
            Debug.Log(columns.Length);
        }

        lastSpawn = Time.time;
    }
}
