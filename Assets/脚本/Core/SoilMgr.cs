using System.Collections;
using System.Collections.Generic;
using QFramework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SoilMgr : MonoBehaviour
{

    public int width;
    public int length;
    [Header("Grid")]
    public Grid soilGrid;
    [Header("Tile")]
    public Tilemap soilTile;
    [Header("Soil资源")]
    public TileBase soil_1;
    public TileBase soil_2;

    [HideInInspector]
    public EasyGrid<int> gd;

    private void Awake()
    {
        InitSoil(width, length);
    }

    //初始化SoilTile
    public void InitSoil(int w, int h)

    {
        gd = new EasyGrid<int>(w, h);
        gd[0, 0] = 1;
        gd[0, 1] = 1;
        gd[0, 2] = 1;
        gd[1, 0] = 1;
        gd[1, 1] = 1;
        gd[1, 2] = 1;
        gd.ForEach((x, y, i) =>
        {
            switch (i)
            {
                case 0:
                    soilTile.SetTile(new Vector3Int(x, y), null);
                    break;
                case 1:
                    soilTile.SetTile(new Vector3Int(x, y), soil_1);
                    break;
                case 2:
                    soilTile.SetTile(new Vector3Int(x, y), soil_2);
                    break;
            }
        });

    }

    //更改土地类型
    public void Change(Vector3Int pos, BaseSoil soil)
    {
        soilTile.SetTile(pos, soil.tile);
    }
    //判断是否在区域内
    public bool IsinSoilTile(Vector3Int pos)
    {
        if (pos.x <= width && pos.y <= length && pos.x >= -width && pos.y >= -length)
        {
            return true;
        }
        return false;
    }

    //物体坐标转网格物体坐标
    public Vector3 ItemToSoilItem(Vector3 pos)
    {
        float x;
        float y;

        x = pos.x + soilGrid.cellSize.x * 0.5f;
        y = pos.y + soilGrid.cellSize.y * 0.5f;


        return new Vector3(x, y);
    }
}
