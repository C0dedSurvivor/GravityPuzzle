﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualMapGenerator : MonoBehaviour {

    GameObject[,] visualMap = new GameObject[20, 20];
    List<Map> mapList = new List<Map>();
    int currentMap = 0;
    public int moving = 0;
    Vector3 rotation = new Vector3(0, 0, 3);
    public Player player;
    //d = down = default, l = left, u = up, = right
    public char gravity = 'd';
    public bool falling = false;

    public GameObject goalPrefab;
    public GameObject wallPrefab;
    public GameObject teleporterPrefab;
    //rotated for left, right and down only walls. Default is up
    public GameObject oneWayWallPrefab;
    public GameObject spikePrefab;
    public GameObject lockBoxPrefab;
    public GameObject switchPrefab;
    public GameObject playerPrefab;


	// Use this for initialization
	void Start () {
        MakeMaps();
	}

    public void StartGame(int l)
    {
        currentMap = l;
        GenerateMap();
    }
	
	// Update is called once per frame
	void Update () {
		if(moving > 0)
        {
            transform.Rotate(rotation);
            moving--;
            if (moving == 0)
                FinishRotation();
        }
        else if(moving < 0)
        {
            transform.Rotate(-rotation);
            moving++;
            if (moving == 0)
                FinishRotation();
        }
	}

    public void FinishRotation()
    {
        player.CanMove();
        player.transform.position = new Vector3(Mathf.RoundToInt(player.transform.position.x), Mathf.RoundToInt(player.transform.position.y));
        foreach(Vector2Int p in mapList[currentMap].TPLinkList.Values)
        {
            visualMap[p.x, p.y].GetComponent<Teleporter>().enabled = true;
        }
    }

    public void MakeMaps()
    {
        mapList.Add(new Map(new int[20, 20] {   { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0 },
                                                { 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 0 },
                                                { 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0 },
                                                { 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0 },
                                                { 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0 },
                                                { 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0 },
                                                { 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0 },
                                                { 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0 },
                                                { 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0 },
                                                { 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0 },
                                                { 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0 },
                                                { 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0 },
                                                { 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0 },
                                                { 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0 },
                                                { 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0 },
                                                { 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0 },
                                                { 0, 2, 11, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0 },
                                                { 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } }));

        mapList.Add(new Map(new int[20, 20] {   { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 2, 11, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } }));

        mapList.Add(new Map(new int[20, 20] {   { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 2, 11, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0 },
                                                { 0, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } }));

        mapList.Add(new Map(new int[20, 20] {   { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 2, 11, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } }));

        mapList.Add(new Map(new int[20, 20] {   { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 1, 0, 2, 2, 0, 0, 2, 2, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 2, 2, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 6, 11, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } }));
        
        mapList.Add(new Map(new int[20, 20] {   { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 2, 3, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 2, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 2, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 2, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 2, 0, 2, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0 },
                                                { 0, 0, 0, 2, 0, 2, 0, 0, 2, 3, 0, 0, 0, 0, 0, 1, 2, 0, 0, 0 },
                                                { 0, 0, 0, 2, 0, 2, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0 },
                                                { 0, 0, 0, 2, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 2, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 2, 11, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } }));
        mapList[mapList.Count - 1].AddTP(new Vector2Int(5, 4), new Vector2Int(10, 9));

        mapList.Add(new Map(new int[20, 20] {   { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 2, 2, 2, 2, 2, 2, 0, 0, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0 },
                                                { 0, 0, 2, 1, 0, 0, 3, 2, 0, 0, 2, 0, 4, 3, 4, 0, 2, 0, 0, 0 },
                                                { 0, 0, 2, 2, 2, 2, 0, 2, 0, 0, 2, 0, 0, 0, 0, 0, 2, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 2, 0, 2, 0, 0, 2, 0, 0, 0, 0, 0, 2, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 2, 0, 2, 0, 0, 2, 0, 0, 0, 0, 0, 2, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 2, 0, 2, 0, 0, 2, 0, 0, 0, 0, 0, 2, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 2, 11, 2, 0, 0, 2, 0, 0, 0, 0, 0, 2, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 2, 2, 2, 0, 0, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } }));
        mapList[mapList.Count - 1].AddTP(new Vector2Int(7, 6), new Vector2Int(7, 13));
        
        mapList.Add(new Map(new int[20, 20] {   { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 2, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 2, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 2, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 2, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 2, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 2, 9, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 2, 0, 9, 0, 0, 0, 10, 2, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 2, 10, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 2, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 2, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 2, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 2, 11, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } }));
        mapList[mapList.Count - 1].AddSwitch(new Vector2Int(11, 8), new Vector2Int(10, 9));
        mapList[mapList.Count - 1].AddSwitch(new Vector2Int(10, 13), new Vector2Int(9, 8));
        
        mapList.Add(new Map(new int[20, 20] {   { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 2, 0, 0, 3, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 2, 0, 0, 0, 0, 0, 2, 0, 2, 2, 2, 2, 2, 2, 2, 0, 0 },
                                                { 0, 0, 0, 2, 0, 0, 0, 0, 0, 2, 0, 8, 3, 0, 0, 0, 1, 2, 0, 0 },
                                                { 0, 0, 0, 2, 0, 0, 0, 0, 0, 2, 0, 2, 2, 2, 2, 2, 2, 2, 0, 0 },
                                                { 0, 0, 0, 2, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 2, 0, 0, 11, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } }));
        mapList[mapList.Count - 1].AddTP(new Vector2Int(7, 6), new Vector2Int(9, 12));
    }

    public void GenerateMap()
    {
        Debug.Log("generating stuff");
        //clears the map
        for(int x = 0; x < 20; x++)
        {
            for(int y = 0; y < 20; y++)
            {
                Destroy(visualMap[x, y]);
                visualMap[x, y] = null;
            }
        }

        if(player != null)
            Destroy(player.gameObject);
        player = null;

        transform.rotation = Quaternion.Euler(0, 0, 0);
        gravity = 'd';

        //draws the map
        for (int x = 0; x < 20; x++)
        {
            for (int y = 0; y < 20; y++)
            {
                if(mapList[currentMap].map[x,y] == 1)
                {
                    visualMap[x, y] = Instantiate(goalPrefab, new Vector3(y - 10, 10 - x), Quaternion.Euler(0, 0, 0), transform);
                }
                else if (mapList[currentMap].map[x, y] == 2)
                {
                    visualMap[x, y] = Instantiate(wallPrefab, new Vector3(y - 10, 10 - x), Quaternion.Euler(0, 0, 0), transform);
                }
                else if (mapList[currentMap].map[x, y] == 3)
                {
                    visualMap[x, y] = Instantiate(teleporterPrefab, new Vector3(y - 10, 10 - x), Quaternion.Euler(0, 0, 0), transform);
                }
                else if (mapList[currentMap].map[x, y] == 4)
                {
                    visualMap[x, y] = Instantiate(oneWayWallPrefab, new Vector3(y - 10 - 0.25f, 10 - x), Quaternion.Euler(0, 0, 90), transform);
                    visualMap[x, y].layer = 8;
                }
                else if (mapList[currentMap].map[x, y] == 5)
                {
                    visualMap[x, y] = Instantiate(oneWayWallPrefab, new Vector3(y - 10, 10 - x + 0.25f), Quaternion.Euler(0, 0, 0), transform);
                    visualMap[x, y].layer = 9;
                }
                else if (mapList[currentMap].map[x, y] == 6)
                {
                    visualMap[x, y] = Instantiate(oneWayWallPrefab, new Vector3(y - 10 + 0.25f, 10 - x), Quaternion.Euler(0, 0, -90), transform);
                    visualMap[x, y].layer = 10;
                }
                else if (mapList[currentMap].map[x, y] == 7)
                {
                    visualMap[x, y] = Instantiate(oneWayWallPrefab, new Vector3(y - 10, 10 - x - 0.25f), Quaternion.Euler(0, 0, 180), transform);
                    visualMap[x, y].layer = 11;
                }
                else if (mapList[currentMap].map[x, y] == 8)
                {
                    visualMap[x, y] = Instantiate(spikePrefab, new Vector3(y - 10, 10 - x), Quaternion.Euler(0, 0, 0), transform);
                }
                else if (mapList[currentMap].map[x, y] == 9)
                {
                    visualMap[x, y] = Instantiate(lockBoxPrefab, new Vector3(y - 10, 10 - x), Quaternion.Euler(0, 0, 0), transform);
                }
                else if (mapList[currentMap].map[x, y] == 10)
                {
                    visualMap[x, y] = Instantiate(switchPrefab, new Vector3(y - 10, 10 - x), Quaternion.Euler(0, 0, 0), transform);
                }
                else if (mapList[currentMap].map[x, y] == 11)
                {
                    player = Instantiate(playerPrefab, new Vector3(y - 10, 10 - x), Quaternion.Euler(0, 0, 0), transform).GetComponent<Player>();
                }
                if (visualMap[x, y] != null)
                    visualMap[x, y].GetComponent<BlockInfo>().arrayPosition = new Vector2Int(x, y);
            }
        }
        falling = false;
    }

    public void CheckTriggerer(int x, int y)
    {
        if (mapList[currentMap].map[x, y] == 1)
        {
            currentMap++;
            if (currentMap >= mapList.Count)
                currentMap = 0;
            GenerateMap();
        }
        else if (mapList[currentMap].map[x, y] == 3)
        {
            if (visualMap[mapList[currentMap].TPLinkList[new Vector2Int(x, y)].x, mapList[currentMap].TPLinkList[new Vector2Int(x, y)].y].GetComponent<Teleporter>().enabled)
            {
                player.transform.position = visualMap[mapList[currentMap].TPLinkList[new Vector2Int(x, y)].x, mapList[currentMap].TPLinkList[new Vector2Int(x, y)].y].transform.position;
                visualMap[x, y].GetComponent<Teleporter>().enabled = false;
            }
        }
        else if (mapList[currentMap].map[x, y] == 8)
        {
            GenerateMap();
        }
        else if (mapList[currentMap].map[x, y] == 10)
        {
            visualMap[mapList[currentMap].SwitchLinkList[new Vector2Int(x, y)].x, mapList[currentMap].SwitchLinkList[new Vector2Int(x, y)].y].GetComponent<SwitchBox>().ToggleState();
        }
    }

    //sets up the map to start rotating and changes the gravity identifier
    public void rotate(int r)
    {
        if (moving == 0 && !falling && player.MyRigidbody.velocity == Vector3.zero)
        {
            player.Stop();
            moving = r;
            if((gravity.Equals('u') && moving > 0) || (gravity.Equals('d') && moving < 0))
            {
                gravity = 'r';
                player.gameObject.layer = 10;
            }
            else if ((gravity.Equals('d') && moving > 0) || (gravity.Equals('u') && moving < 0))
            {
                gravity = 'l';
                player.gameObject.layer = 8;
            }
            else if ((gravity.Equals('l') && moving > 0) || (gravity.Equals('r') && moving < 0))
            {
                gravity = 'u';
                player.gameObject.layer = 9;
            }
            else if ((gravity.Equals('r') && moving > 0) || (gravity.Equals('l') && moving < 0))
            {
                gravity = 'd';
                player.gameObject.layer = 11;
            }
        }
    }
}
