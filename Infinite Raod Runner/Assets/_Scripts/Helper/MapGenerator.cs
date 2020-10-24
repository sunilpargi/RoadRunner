using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public static MapGenerator instance;

    public GameObject
            roadPrefab,
            grass_Prefab,
            groundPrefab_1,
            groundPrefab_2,
            groundPrefab_3,
            groundPrefab_4,
            grass_Bottom_Prefab,
            land_Prefab_1,
            land_Prefab_2,
            land_Prefab_3,
            land_Prefab_4,
            land_Prefab_5,
            big_Grass_Prefab,
            big_Grass_Bottom_Prefab,
            treePrefab_1,
            treePrefab_2,
            treePrefab_3,
            big_Tree_Prefab;

    public GameObject
            road_Holder,
            top_Near_Side_Walk_Holder,
            top_Far_Side_Walk_Holder,
            bottom_Near_Side_Walk__Holder,
            bottom_Far_Side_Walk__Holder;

    public int
            start_Road_Tile,  // initizlization number of  'road' tiles
            start_Grass_Tile,   // initizlization number of  'grass' tiles
            start_Ground3_Tile,   // initizlization number of  'ground3' tiles
            start_Land_Tile;   // initizlization number of  'land' tiles


    public List<GameObject>
        road_Tiles,
        top_Near_Grass_Tiles,
        top_Far_Grass_Tiles,
        bottom_Near_Grass_Tiles,
        bottom_Far_Land_F1_Tiles,
        bottom_Far_Land_F2_Tiles,
        bottom_Far_Land_F3_Tiles,
        bottom_Far_Land_F4_Tiles,
        bottom_Far_Land_F5_Tiles;


    public int[] pos_For_Top_Ground_1; // position for ground1  on top from 0 to startGround3Tile

    public int[] pos_For_Top_Ground_2; // position for ground2  on top from 0 to startGround3Tile

    public int[] pos_For_Top_Ground_4; // position for ground4  on top from 0 to startGround3Tile

    public int[] pos_For_Top_Big_Grass; // position for bigGrass  with tree on top near grass from 0 to startGrassTile

    public int[] pos_For_Top_Tree_1;  // position for tree1 on top near grass from 0 to startgrassTile

    public int[] pos_For_Top_Tree_2; // position for tree2 on top near grass from 0 to startgrassTile

    public int[] pos_For_Top_Tree_3;  // position for tree3 on top near grass from 0 to startgrassTile

    public int pos_For__Raod_Tile_1; // position for  road tile on road from 0 to startRoadTile

    public int pos_For__Raod_Tile_2; // position for  road tile on road from 0 to startRoadTile

    public int pos_For__Raod_Tile_3; // position for  road tile on road from 0 to startRoadTile

    public int[] pos_For_Bottom_Big_Grass; // position for  big grass with tree from 0 to startgrassTile

    public int[] pos_For_Bottom_Tree1; // position for  tree1 on bottom near grass from 0 to startgrassTile

    public int[] pos_For_Bottom_Tree2; // position for  tree2 on bottom near grass from 0 to startgrassTile

    public int[] pos_For_Bottom_Tree3; // position for  tree3 on bottom near grass from 0 to startgrassTile

    [HideInInspector]
    public Vector3
            last_Pos_Of_Road_Tile,
            last_Pos_Of_Top_Near_Grass,
            last_Pos_Of_Top_Far_Grass,
            last_Pos_Of_Bottom_Near_Grass,
            last_Pos_Of_Bottom_Far_land_F1,
            last_Pos_Of_Bottom_Far_land_F2,
            last_Pos_Of_Bottom_Far_land_F3,
            last_Pos_Of_Bottom_Far_land_F4,
            last_Pos_Of_Bottom_Far_land_F5;


    [HideInInspector]
    public int
        last_Order_Of_Road,
        last_Order_Of_Top_Near_Grass,
        last_Order_Of_Top_Far_Grass,
        last_Order_Of_Bottom_Near_Grass,
        last_Order_Of_Bottom_Far_Land_F1,
        last_Order_Of_Bottom_Far_Land_F2,
        last_Order_Of_Bottom_Far_Land_F3,
        last_Order_Of_Bottom_Far_Land_F4,
        last_Order_Of_Bottom_Far_Land_F5;


    
    void Awake()
    {
        MakeInstance();
    }

    private void MakeInstance()
    {
       if(instance == null)
        {
            instance = this;
        }

       else if(instance != null)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        InitializePlatform(roadPrefab, ref last_Pos_Of_Road_Tile, roadPrefab.transform.position, start_Road_Tile, road_Holder, ref road_Tiles, ref last_Order_Of_Road, new Vector3(1.5f, 0, 0));
    }



    void InitializePlatform(GameObject prefab, ref Vector3 last_Pos, Vector3 last_Pos_of_Tile, int amountTile, GameObject holder, ref List<GameObject> list_Tile, ref int last_Order, Vector3 offSet)
    {
        int orderInlayer = 0;
        last_Pos = last_Pos_of_Tile;

        for (int i = 0; i < amountTile; i++)
        {
            GameObject clone = Instantiate(prefab, last_Pos, prefab.transform.rotation) as GameObject;
            clone.GetComponent<SpriteRenderer>().sortingOrder = orderInlayer;

            if (clone.tag == Mytag.TOP_NEAR_GRASS)
            {

            }
            else if (clone.tag == Mytag.BOTTOM_NEAR_GRASS)
            {

            }

            else if (clone.tag == Mytag.BOTTOM_FAR_LAND_2)
            {

            }
            else if (clone.tag == Mytag.TOP_NEAR_GRASS)
            {

            }

            clone.transform.SetParent(holder.transform);
            list_Tile.Add(clone);

            orderInlayer += 1;
            last_Order = orderInlayer;

            last_Pos += offSet;
        }

    }
}
