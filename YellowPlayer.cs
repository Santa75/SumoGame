using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class YellowPlayer : MonoBehaviour

{
	public Text winText;
	public GameObject reset;
	private bool gameWon;
	private Rigidbody Banana;
	public Rigidbody Grape;
	public float speed;
	public int Points;
	private Vector3 respawn;
	public Vector3 oppRespawn;
	public Text countText;
	public GameObject opponent;

	void Start()
	{
		respawn = transform.position;
		oppRespawn = opponent.transform.position;
		winText.text = "";  //initialize the winText value
		gameWon = false;
		Banana = GetComponent<Rigidbody>();
		reset.gameObject.SetActive(false);
		countText.text = "Score: 0/3";
		Points = Points - 3;
	}

	

	private void Update()
	{
		float moveHorizontal = Input.GetAxis("YellowHoriz");     //Access the right and left arrow keys
		float moveVertical = Input.GetAxis("YellowVert");         //Access the up and down arrow keys
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); //Vector3s deal with movement in 3D space.  X, Y, and Z aspects.  In this case the Y is zero.  Vector3s take floats.
		GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime); //This accesses the rigidbody component and adds force ot get it moving
		Banana.AddForce(movement * speed * Time.deltaTime);

	}



	public void Iwin()
	{
		reset.gameObject.SetActive(true);
		winText.text = "WINNER: PURPLE!";
		Destroy(gameObject);
		Destroy(opponent);

	}

	public void ILose()
	{
		transform.position = respawn;
		opponent.transform.position = oppRespawn;
		Banana.angularVelocity = new Vector3(0, 0, 0);
		Banana.velocity = new Vector3(0, 0, 0);
		Grape.angularVelocity = new Vector3(0, 0, 0);
		Grape.velocity = new Vector3(0, 0, 0);
	}


	void OnCollisionEnter(Collision target)
	{
		if (target.gameObject.tag == "Deadly")
		{
			ILose();
		    Points += 1;
		    countText.text = Points.ToString() + "/3";

		}


		
		
			if (Points == 3)
			{
				Iwin();
			}
		

	}
}