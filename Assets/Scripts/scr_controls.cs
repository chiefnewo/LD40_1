using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_controls : MonoBehaviour {
	private int controlMode = 0; // different behaviour in different modes
							 // 0 = map movement mode
	private scr_player playerRef;
	public float moveDelay = 0.2f; // movement delay in s
	private float moveTimer = 0;
	private bool moving = false;

	private void Start()
	{
		playerRef = GetComponentInParent<scr_player>();
		moveTimer = 0;
	}

	// Update is called once per frame
	private void Update()
	{
		
	}

	public void GetMovement () {
		//Debug.Log(moveTimer);
		if (controlMode == 0)
		{
			if (moving == false)
				moveTimer = 0;
			else
			{
				if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
				{
					moveTimer = 0;
				}

				if (moveTimer > 0)
					moveTimer -= Time.deltaTime;
				else
				{
					moveTimer = 0;
					moving = false;
				}
			}

			int posx_d = 0, posy_d = 0;
			if (moving == false)
			{
				if (Input.GetAxis("Horizontal") != 0)
				{
					moving = true;
					moveTimer = moveDelay;

					if (Input.GetAxis("Horizontal") < 0)
						posx_d = Mathf.FloorToInt(Input.GetAxis("Horizontal"));
					else if (Input.GetAxis("Horizontal") > 0)
						posx_d = Mathf.CeilToInt(Input.GetAxis("Horizontal"));
				}
				else if (Input.GetAxis("Vertical") != 0)
				{
					moving = true;
					moveTimer = moveDelay;

					if (Input.GetAxis("Vertical") < 0)
						posy_d = Mathf.FloorToInt(Input.GetAxis("Vertical"));
					else if (Input.GetAxis("Vertical") > 0)
						posy_d = Mathf.CeilToInt(Input.GetAxis("Vertical"));
				}

				if (posx_d != 0)
					playerRef.MovePosition(posx_d, 0);
				else if (posy_d != 0)
					playerRef.MovePosition(0, posy_d);
			}
		}

	}
}
