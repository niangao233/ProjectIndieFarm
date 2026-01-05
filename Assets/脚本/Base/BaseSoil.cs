using UnityEngine;
using UnityEngine.Tilemaps;

public class BaseSoil
{
    protected SoilMgr soilMgr = MgrSystem.Instance.soilMgr;
    //位置
    public Vector3Int pos;
    //外观
    public TileBase tile;

}