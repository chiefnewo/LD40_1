using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class scr_GameManager : MonoBehaviour {

	public int tileSize = 32; // size of tiles, used to move objects around the grid
	public GameObject player; // reference to player object
	private scr_player playerRef;
	private scr_controls controlsRef;
	public Tilemap tilemap; // ref to tilemap
	private GameObject[] npcs; // npc and enemy objects

	

	// Use this for initialization
	void Start () {
		Debug.Log(tilemap.origin);
		playerRef = player.GetComponent<scr_player>();
		playerRef.SetPosition(tilemap.origin.x, tilemap.origin.y);
		controlsRef = player.GetComponent<scr_controls>();
	}
	
	// Update is called once per frame
	void Update () {
		// Move player
		controlsRef.GetMovement();
		player.transform.position = CellToWorld(playerRef.GetPosition());
	}

	private Vector3 CellToWorld(Vector3Int cellRef)
	{
		return tilemap.GetCellCenterWorld(cellRef);
	}
}
