using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_player : MonoBehaviour {

	private int pos_x = 0, pos_y = 0; // player grid position
	private int controlMode = 0; // different behaviour in different modes
								 // 0 = map movement mode
	public float moveDelay = 0.2f; // movement delay in s
	private float moveTimer = 0;
	private bool moving = false;
	public float moveSpeed = .5f;
	private Vector2 moveTarget;
	private Rigidbody2D rb2D;


	// Use this for initialization
	void Start () {
		moveTimer = 0;
		Cursor.visible = true;
		rb2D = GetComponentInParent<Rigidbody2D>();
		moving = false;
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

	//public void MovePosition(int x, int y)
	//{
	//	pos_x += x;
	//	pos_y += y;
	//}

	public void GetMovement()
	{
		Debug.Log(moving + " " + moveTarget);
		if (controlMode == 0)
		{
			//if (moving == false)
			//	moveTimer = 0;
			//else
			//{

			//	if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
			//	{
			//		moveTimer = 0;
			//	}

			//	//if (moveTimer > 0)
			//	//	moveTimer -= Time.deltaTime;
			//	//else
			//	//{
			//	//	moveTimer = 0;
			//	//	moving = false;
			//	//}
			//}

			int posx_d = 0, posy_d = 0;
			if (moving == false)
			{
				if (Input.GetAxis("Horizontal") != 0)
				{
					if (Input.GetAxis("Horizontal") < 0)
						posx_d = -1;
					else if (Input.GetAxis("Horizontal") > 0)
						posx_d = 1;
				}
				else if (Input.GetAxis("Vertical") != 0)
				{
					if (Input.GetAxis("Vertical") < 0)
						posy_d = -1;
					else if (Input.GetAxis("Vertical") > 0)
						posy_d = 1;
				}

				if (posx_d != 0)
				{
					//MovePosition(posx_d, 0);
					moving = true;
					moveTarget = (rb2D.position + new Vector2(posx_d, 0));
					rb2D.MovePosition(rb2D.position + ((moveTarget - rb2D.position) * moveSpeed));
					SetPosition(pos_x + posx_d, pos_y + posy_d);
				}
				else if (posy_d != 0)
				{
					moving = true;
					moveTarget = (rb2D.position + new Vector2(0, posy_d));
					rb2D.MovePosition(rb2D.position + ((moveTarget - rb2D.position) * moveSpeed));
					SetPosition(pos_x + posx_d, pos_y + posy_d);
				}
				
			}
			else
			{
				if (moveTarget == rb2D.position)
				{
					moving = false;
					return;
				} else
					rb2D.MovePosition(rb2D.position + ((moveTarget - rb2D.position) * moveSpeed));
			}


		}

	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		moving = false;
		moveTarget = rb2D.position;
	}
}
