using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody2D rb2d;
	private int count;

	void Start()
	{
		count = 0;
		SetCountText ();
		winText.text = "";
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb2d.AddForce (movement * speed);

	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.CompareTag("PickUp"))
		{
			count += 1;
			SetCountText ();
			other.gameObject.SetActive (false);
			if (count == 12) 
			{
				winText.text = "You win!!";
			}
		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();
	}
}
