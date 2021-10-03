using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

	public Animator enemyAnim;
	public EnemyBehavior self;
	public bool inPursuit = false;

    // Start is called before the first frame update
    void Start()
    {
		self = gameObject.GetComponentInChildren<EnemyBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
		inPursuit = self.inPursuit;

		if (inPursuit == false)
		{
			switch (gameObject.name)
			{
				case "Static Enemy": break;
				case "Intro Enemy": enemyAnim.Play("Intro"); break;
				case "Hallway Patrol": break;
				case "Hallway Patrol 2": break;
				case "Library Patrol 1": break;
				case "Library Patrol 2": break;
				case "Room 3 Patrol": break;
				case "DoorGuard 1": break;
				case "DoorGuard 2": break;
				case "Lobby Patrol": break;
			}
		}
		else 
		{

			enemyAnim.StopPlayback();
		}
	}
}
