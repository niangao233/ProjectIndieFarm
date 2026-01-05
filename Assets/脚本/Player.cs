using System.Collections;
using System.Collections.Generic;
using QFramework;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{

    public Transform playerT;
    private MgrSystem mgr;

    private void Awake()
    {
        playerT = this.gameObject.transform;
        mgr = MgrSystem.Instance;
    }

    void Start()
    {

    }


    void Update()
    {
        Till();


    }
    //耕地方法
    public void Till()
    {
        if (mgr.soilMgr.IsinSoilTile(Vector3Int.RoundToInt(this.transform.position)))
        {

            int x = (int)playerT.position.x;
            int y = (int)playerT.position.y;

            Vector3Int cellPos = mgr.soilMgr.soilTile.WorldToCell(this.transform.position);
            TileBase curtGrid = mgr.soilMgr.soilTile.GetTile(cellPos);
            //显示当前选中的地块
            if (curtGrid != null)
            {
                mgr.gizmoMgr.Show(mgr.gizmoMgr.selectSoil);
            }
            else
            {
                mgr.gizmoMgr.Hide(mgr.gizmoMgr.selectSoil);
            }
            mgr.gizmoMgr.Position(mgr.gizmoMgr.selectSoil, cellPos);
            //按J键耕地
            if (Input.GetKeyDown(KeyCode.J))
            {
                if (curtGrid != null)
                {
                    mgr.soilMgr.Change(cellPos, new DirtSoil());
                }
            }
        }
        else
        {
            mgr.gizmoMgr.Hide(mgr.gizmoMgr.selectSoil);
        }
    }
}
