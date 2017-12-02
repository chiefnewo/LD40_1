using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_player : MonoBehaviour {

	private int pos_x = 0, pos_y = 0; // player grid position
	


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Vector3Int GetPosition()
	{
		return new Vector3Int(pos_x, pos_y, 0);
	}

	public void SetPosition(int x, int y)
	{
		pos_x = x;
		pos_y = y;
	}

	public void MovePosition(int x, int y)
	{
			pos_x += x;
			pos_y += y;
	}


}
