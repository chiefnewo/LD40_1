using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class scr_GameManager : MonoBehaviour {

	public int tileSize = 32; // size of tiles, used to move objects around the grid
	public GameObject player; // reference to player object
	private scr_player player_script;
	public Tilemap tilemap; // ref to tilemap
	private GameObject[] npcs; // npc and enemy objects

	

	// Use this for initialization
	void Start () {
		Debug.Log(tilemap.origin);
		player_script = player.GetComponent<scr_player>();
		player_script.SetPosition(tilemap.origin.x, tilemap.origin.y);
	}
	
	// Update is called once per frame
	void Update () {
		// Move player
		player.transform.position = CellToWorld(tilemap.origin);
	}

	private void FixedUpdate()
	{
		
	}

	private Vector3 CellToWorld(Vector3Int cellRef)
	{
		return tilemap.GetCellCenterWorld(cellRef);
	}
}
