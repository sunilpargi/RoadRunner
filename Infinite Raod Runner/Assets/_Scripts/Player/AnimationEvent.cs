using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
	private Animator anim;

	private string walk_Animation = "PlayerWalk";

	void Awake()
	{
		anim = GetComponent<Animator>();
	}

	void PlayerWalkAnimation()
	{
		anim.Play(walk_Animation);

		if (PlayerController.instance.player_Jumped)
		{
			PlayerController.instance.player_Jumped = false;

		}
	}

}
