using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitDamage : MonoBehaviour
{
	[SerializeField]
	public PlayerOne player1;
	[SerializeField]
	public PlayerTwo player2;
	private HealthBarScript healthbar;

	private void Start()
	{

	}
	// Update is called once per frame
	void Update()
	{

	}

	private void OnCollisionEnter2D(Collision2D collision)
	{

		if (collision.gameObject.CompareTag("player 1"))
		{
			Debug.Log("Oops you fell");
			player1.CurrentHealth = 0;
			player1.healthbar.SetHealth(player1.CurrentHealth);
		}

		if (collision.gameObject.CompareTag("player 2"))
		{
			player2.CurrentHealth = 0;
			player2.healthbar.SetHealth(player2.CurrentHealth);
		}

	}
}
