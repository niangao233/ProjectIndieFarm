using UnityEngine;

public class MgrSystem : MonoBehaviour
{
	private static MgrSystem instance;
	public static MgrSystem Instance

	{
		get
		{
			if (instance == null)
			{
				print("MgrSystem实例为空！！！");
			}
			return instance;
		}
	}

	public SoilMgr soilMgr;
	public GizmoMgr gizmoMgr;

	void Awake()
	{
		instance = this;

	}

	void Start()
	{

	}


	void Update()
	{

	}
}