using QFramework;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GizmoMgr : MonoBehaviour
{
	private MgrSystem mgr;
	public GameObject selectSoil;

	private void Awake()
	{
		mgr = MgrSystem.Instance;
		//初始化后隐藏对象
		Hide(selectSoil);
	}

	public void Position(GameObject obj, Vector3 playerPos)
	{
		Vector3 pos = mgr.soilMgr.ItemToSoilItem(playerPos);
		obj.transform.position = pos;
	}

	public void Show(GameObject obj)
	{
		obj.SetActive(true);
	}
	public void Hide(GameObject obj)
	{
		obj.SetActive(false);
	}


}