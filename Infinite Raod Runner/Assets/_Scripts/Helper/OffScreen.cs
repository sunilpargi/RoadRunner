using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffScreen : MonoBehaviour
{
    private SpriteRenderer spriteRendered;

    void Awake()
    {
        spriteRendered = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);

        if(!GeometryUtility.TestPlanesAABB(planes, spriteRendered.bounds))
        {
            if(transform.position.x - Camera.main.transform.position.x < 0.0f)
            {
                CheckTile();
            }
        }
    }

    private void CheckTile()
    {
       if(this.tag == Mytag.ROAD)
        {
            Change(ref MapGenerator.instance.last_Pos_Of_Road_Tile, new Vector3(1.5f, 0, 0), ref MapGenerator.instance.last_Order_Of_Road);
        }

       else if (this.tag == Mytag.TOP_NEAR_GRASS)
        {
            Change(ref MapGenerator.instance.last_Pos_Of_Top_Near_Grass, new Vector3(1.2f, 0, 0), ref MapGenerator.instance.last_Order_Of_Top_Near_Grass);
        }

        else if (this.tag == Mytag.TOP_FAR_GRASS)
        {
            Change(ref MapGenerator.instance.last_Pos_Of_Top_Far_Grass, new Vector3(4.8f, 0, 0), ref MapGenerator.instance.last_Order_Of_Top_Far_Grass);
        }

        else if (this.tag == Mytag.BOTTOM_NEAR_GRASS)
        {
            Change(ref MapGenerator.instance.last_Pos_Of_Bottom_Near_Grass, new Vector3(1.2f, 0, 0), ref MapGenerator.instance.last_Order_Of_Bottom_Near_Grass);
        }

        else if (this.tag == Mytag.BOTTOM_FAR_LAND_1)
        {
            Change(ref MapGenerator.instance.last_Pos_Of_Bottom_Far_land_F1, new Vector3(1.6f, 0, 0), ref MapGenerator.instance.last_Order_Of_Bottom_Far_Land_F1);
        }

        else if (this.tag == Mytag.BOTTOM_FAR_LAND_2)
        {
            Change(ref MapGenerator.instance.last_Pos_Of_Bottom_Far_land_F2, new Vector3(1.6f, 0, 0), ref MapGenerator.instance.last_Order_Of_Bottom_Far_Land_F2);
        }

        else if (this.tag == Mytag.BOTTOM_FAR_LAND_3)
        {
            Change(ref MapGenerator.instance.last_Pos_Of_Bottom_Far_land_F3, new Vector3(1.6f, 0, 0), ref MapGenerator.instance.last_Order_Of_Bottom_Far_Land_F3);
        }


        else if (this.tag == Mytag.BOTTOM_FAR_LAND_4)
        {
            Change(ref MapGenerator.instance.last_Pos_Of_Bottom_Far_land_F4, new Vector3(1.6f, 0, 0), ref MapGenerator.instance.last_Order_Of_Bottom_Far_Land_F4);
        }

        else if (this.tag == Mytag.BOTTOM_FAR_LAND_5)
        {
            Change(ref MapGenerator.instance.last_Pos_Of_Bottom_Far_land_F5, new Vector3(1.6f, 0, 0), ref MapGenerator.instance.last_Order_Of_Bottom_Far_Land_F5);
        }
    }

    void Change(ref Vector3 pos, Vector3 offset, ref int orderLayer)

    {

        transform.position = pos;
        pos += offset;

        spriteRendered.sortingOrder = orderLayer;

        orderLayer++;
    }
}
