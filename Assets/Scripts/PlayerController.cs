using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public float speed;
	private Rigidbody rb;
	private int score;
	public int health = 5;
	public Text scoreText;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		SetScoreText();
	}

	void Update()
	{
		if (health == 0)
		{
			Debug.Log("Game over!");
			SceneManager.LoadScene("maze");
		}
	}

	void FixedUpdate()
	{
		float movementHorizontal = Input.GetAxis("Horizontal");
		float movementVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(movementHorizontal, 0, movementVertical);

		rb.velocity = new Vector3(movement.x * speed, rb.velocity.y, movementVertical * speed);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Pickup"))
		{
			score += 1;
			SetScoreText();
			Destroy(other.gameObject);

		}

		if (other.CompareTag("Trap"))
		{
			health -= 1;
			Debug.Log("Health: " + health);
			
		}

		if (other.CompareTag("Goal"))
		{
			Debug.Log("You win!");
		}
	}

	void SetScoreText()
	{
		scoreText.text = "Score: " + score;
	}
}
