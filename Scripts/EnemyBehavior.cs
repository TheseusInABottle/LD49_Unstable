using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
	[Header("Player Detection")]
	public LayerMask playerLayer;
	public LayerMask walls;
	public GameObject detector;
	public Transform firePoint;
	public float sightLength;
	public bool inPursuit = true;

	[Header("Enemy Movement")]
	public float runSpeed;
	public Animator enemyAnim;

    // Start is called before the first frame update
    void Start()
    {
		enemyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		Collider[] hitColliders = Physics.OverlapBox(detector.transform.position, detector.transform.localScale / 2, detector.transform.rotation, playerLayer);
		if (hitColliders.Length >= 1)
		{
			RaycastHit hit;
			firePoint.LookAt(hitColliders[0].gameObject.transform.position);
			if (Physics.Raycast(firePoint.position, firePoint.TransformDirection(Vector3.forward), out hit, sightLength))
			{
				if(hit.collider.gameObject.CompareTag("Player"))
				{
					inPursuit = true;
					enemyAnim.StopPlayback();
					gameObject.transform.LookAt(hit.collider.gameObject.transform.position);
					gameObject.transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);

				}
			}
		}

		if (inPursuit == false)
		{
			switch (gameObject.name)
			{
				case "Static Enemy":  break;
				case "Intro Enemy": enemyAnim.Play("Intro"); break;
				case "Hallway Patrol": enemyAnim.Play("Hallway Patrol 1"); break;
				case "Hallway Patrol 2": enemyAnim.Play("Hallway Patrol 2"); break;
				case "Library Patrol 1": enemyAnim.Play("Library Patrol 1"); break;
				case "Library Patrol 2": enemyAnim.Play("Library Patrol 2"); break;
				case "Room 3 Patrol": enemyAnim.Play("Room 3 Patrol"); break;
				case "DoorGuard 1": enemyAnim.Play("Door Guard 1"); break;
				case "DoorGuard 2": enemyAnim.Play("Door Guard 2"); break;
				case "Lobby Patrol": enemyAnim.Play("Lobby Patrol"); break;
				case null: break;
			}
		}
    }

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			enemyAnim.Play("Empty");
		}
	}


}
