using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
public GameObject player;
 private float speed = 20.0f;
 private float turnSpeed = 45.0f;
 private float horizontalInput;
 private float forwardInput;

	public Text countText;
	public Text winText;

	// Create private references to the rigidbody component on the player, and the count of pick up objects picked up so far
	private int count;

// At the start of the game..
	void Start ()
	{
		
		// Set the count to zero 
		count = 0;

		// Run the SetCountText function to update the UI (see below)
		SetCountText ();

		// Set the text property of our Win Text UI to an empty string, making the 'You Win' (game over message) blank
		winText.text = "";
	}
void OnTriggerEnter(Collider other) 
	{
		// ..and if the game object we intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			// Make the other game object (the pick up) inactive, to make it disappear
			other.gameObject.SetActive (false);

			// Add one to the score variable 'count'
			count = count + 1;

			// Run the 'SetCountText()' function (see below)
			SetCountText ();
		}
	}

void Update() {
 horizontalInput = Input.GetAxis("Horizontal");
 forwardInput = Input.GetAxis("Vertical");
 // Moves the car forward based on vertical input
transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
 // Rotates the car based on horizontal input
 transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
}
void SetCountText()
	{
		// Update the text field of our 'countText' variable
		countText.text = "Count: " + count.ToString ();

		// Check if our 'count' is equal to or exceeded 12
		if (count >= 12) 
		{
			// Set the text value of our 'winText'
			winText.text = "You Win!";
		}
	}
}
