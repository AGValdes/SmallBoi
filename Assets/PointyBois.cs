using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointyBois : MonoBehaviour
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
		Debug.Log("Outside If");
		Debug.Log(collision.gameObject);
		if(collision.gameObject.CompareTag("player 1"))
    {
			Debug.Log("Inside If");
			player1.CurrentHealth -= 2;
			healthbar.SetHealth(player1.CurrentHealth);
		}

		if (collision.gameObject.CompareTag("player 2"))
		{
			player2.CurrentHealth -= 2;
			healthbar.SetHealth(player2.CurrentHealth);
		}

	}
}
