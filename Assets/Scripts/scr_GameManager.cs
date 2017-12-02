using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using System.Linq;

public class scr_GameManager : MonoBehaviour {

	public int tileSize = 32; // size of tiles, used to move objects around the grid
	public GameObject player; // reference to player object
	public GameObject uiCanvas;
	private scr_player playerRef;
	public Tilemap tilemap; // ref to tilemap
	private GameObject[] npcs; // npc and enemy objects

	

	// Use this for initialization
	void Start () {
		Debug.Log(tilemap.origin);
		playerRef = player.GetComponent<scr_player>();
		playerRef.SetPosition(tilemap.origin.x, tilemap.origin.y);
	}
	
	// Update is called once per frame
	void Update () {
		// Move player
		playerRef.GetMovement();
		//player.transform.position = CellToWorld(playerRef.GetPosition());
		//player.transform.position = tilemap.GetCellCenterWorld(playerRef.GetPosition());

		if (Input.GetMouseButtonDown(0))
		{
			mouseClick();
		}
	}

	void mouseClick()
	{
		//Debug.Log("Mouse: " + Input.mousePosition + "; Cell: " + tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition)));
		Text posText = uiCanvas.GetComponentsInChildren<Text>().FirstOrDefault(c => c.name == "TilePosition");
		if (posText != null)
			posText.text = "Position: " + tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));

	}
}
