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
	public Tilemap specialMap; // for special squares
	private GameObject[] npcs; // npc and enemy objects

	

	// Use this for initialization
	void Start () {
		Debug.Log(tilemap.origin);
		//Debug.Log(tilemap.CellToWorld(tilemap.origin));
		playerRef = player.GetComponent<scr_player>();
		tilemap.size = new Vector3Int(32, 24, 0);
		specialMap.size = new Vector3Int(32, 24, 0);
		placePlayer();
		//playerRef.SetPosition(tilemap.origin.x, tilemap.origin.y);
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

	void placePlayer()
	{
		ArrayList allTiles = new ArrayList(specialMap.FindTiles("map_start"));
		int x = 0, y = 0;
		Vector3Int place = new Vector3Int(x, y, 0);

		foreach (ArrayList al in allTiles)
		{
			TileBase tb = (TileBase)al[0];
			Debug.Log("name: " + tb.name + " x: " + (int)al[1] + " y: " + (int)al[2]);
			x = (int)al[1];
			y = (int)al[2];
			place = new Vector3Int(x, y, 0);
		}

		playerRef.transform.position = specialMap.GetCellCenterWorld(place);
		playerRef.SetPosition(x, y);
		

	}
}

public static class TilemapExtensions
{
	public static T[] GetTiles<T>(this Tilemap tilemap) where T : TileBase
	{
		List<T> tiles = new List<T>();

		for (int y = tilemap.origin.y; y < (tilemap.origin.y + tilemap.size.y); y++)
		{
			for (int x = tilemap.origin.x; x < (tilemap.origin.x + tilemap.size.x); x++)
			{
				T tile = tilemap.GetTile<T>(new Vector3Int(x, y, 0));
				if (tile != null)
				{
					tiles.Add(tile);
				}
			}
		}
		return tiles.ToArray();
	}

	public static TileBase[] GetTiles(this Tilemap tilemap, string tileName)
	{
		List<TileBase> tiles = new List<TileBase>();

		for (int y = tilemap.origin.y; y < (tilemap.origin.y + tilemap.size.y); y++)
		{
			for (int x = tilemap.origin.x; x < (tilemap.origin.x + tilemap.size.x); x++)
			{
				TileBase tile = tilemap.GetTile<TileBase>(new Vector3Int(x, y, 0));
				if (tile != null && tile.name == tileName)
				{
					tiles.Add(tile);
				}
			}
		}
		return tiles.ToArray();
	}

	public static ArrayList FindTiles(this Tilemap tilemap, string tileName)
	{
		ArrayList tiles = new ArrayList();

		for (int y = tilemap.origin.y; y < (tilemap.origin.y + tilemap.size.y); y++)
		{
			for (int x = tilemap.origin.x; x < (tilemap.origin.x + tilemap.size.x); x++)
			{
				TileBase tile = tilemap.GetTile<TileBase>(new Vector3Int(x, y, 0));
				if (tile != null && tile.name == tileName)
				{
					ArrayList tl = new ArrayList();
					//tiles.Add(tile);
					tl.Add(tile);
					tl.Add(x);
					tl.Add(y);
					tiles.Add(tl);
				}
			}
		}
		return tiles;
	}
}
