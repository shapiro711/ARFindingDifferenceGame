﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject[] tilePrefabs;
    public float zSpawn { get; set; } = 0;
    public float titleLength { get; set;} = 30;
    public int numberOfTiles { get; set;} = 5;
    private List<GameObject> activeTiles = new List<GameObject>();

    [SerializeField]
    private Transform playerTransform;


    void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
                SpawnTile(0);
            else
            {
                SpawnTile(Random.Range(0, tilePrefabs.Length));
            }
        }
         
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z - 35 > zSpawn-(numberOfTiles*titleLength))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
        
    }

    public void SpawnTile(int tileIndex)
    {
        GameObject go =Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go);
        zSpawn += titleLength;
    }

    public void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
