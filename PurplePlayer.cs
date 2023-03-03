using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PurplePlayer : MonoBehaviour

{
	public Text winText;
	public GameObject reset;
	private bool gameWon;
	private Rigidbody Grape;
	public Rigidbody Banana;
	public float speed;
	public int Points;
	public Text countText;
	private Vector3 respawn;
	public Vector3 oppRespawn;
	public GameObject opponent;



	void Start()
	{
		respawn = transform.position;
		winText.text = "";  //initialize the winText value
		gameWon = false;
		Grape = GetComponent<Rigidbody>();
		reset.gameObject.SetActive(false);
		countText.text = "Score: 0/3";
		Points = Points - 3;
	}


	private void Update()
	{
		float moveHorizontal = Input.GetAxis("PurpleHoriz");     //Access the right and left arrow keys
		float moveVertical = Input.GetAxis("PurpleVert");         //Access the up and down arrow keys
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); //Vector3s deal with movement in 3D space.  X, Y, and Z aspects.  In this case the Y is zero.  Vector3s take floats.
		GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime); //This accesses the rigidbody component and adds force ot get it moving
		Grape.AddForce(movement * speed * Time.deltaTime);

	}



	public void Iwin()
	{
		reset.gameObject.SetActive(true);
		winText.text = "WINNER: YELLOW!";
		Destroy(gameObject);
		Destroy(opponent);
	}

	public void ILose()
	{
		transform.position = respawn;
		opponent.transform.position = oppRespawn;
		Grape.angularVelocity = new Vector3(0, 0, 0);
		Grape.velocity = new Vector3(0, 0, 0);
		Banana.angularVelocity = new Vector3(0, 0, 0);
		Banana.velocity = new Vector3(0, 0, 0);
	}


	void OnCollisionEnter(Collision target)
	{
		if (target.gameObject.tag == "Deadly")
		{
			ILose();
			Points++;
			countText.text = Points.ToString() + "/3";


		}

		
			if (Points == 3)
			{
				Iwin();
			}
		

	}
}