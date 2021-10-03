using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
	[Header("Player Movement")]
	public float moveSpeed;

	public bool isAlive = true;
	public int keys = 0;
	public GameObject[] doors; //doors are blocks that are disabled when keys are collected

	public float deathWaitTime;

	private Rigidbody pRB;

    // Start is called before the first frame update
    void Start()
    {
		pRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
		if (isAlive == false) //This is called when the enemies touch the player
		{
			if(deathWaitTime > 0)
			{
				deathWaitTime -= Time.deltaTime;
			}
			else
			{
				SceneManager.LoadScene(2);
			}
		}

		switch (keys)
		{
			case 0: break;
			case 1: doors[0].gameObject.SetActive(false); break;
			case 2: doors[1].gameObject.SetActive(false); break;
			case 3: doors[2].gameObject.SetActive(false); break;
		}
    }

	// FixedUpate is called once per physics update
	private void FixedUpdate()
	{
		//This effects the move direction of the object but I don't know if it actually rotates the player
		if(isAlive == true)
		{
			Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

			pRB.MovePosition(transform.position + moveDir * Time.fixedDeltaTime * moveSpeed);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		switch (other.gameObject.tag)
		{
			case "Key": keys += 1; Destroy(other.gameObject);  break;
			case "Finish": SceneManager.LoadScene(3); break;
			case null: break;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Enemy"))
		{
			isAlive = false; // disables the players movement when the get touched by a enemy
		}
	}
}
