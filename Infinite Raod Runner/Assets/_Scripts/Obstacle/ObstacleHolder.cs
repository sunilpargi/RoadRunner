using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHolder : MonoBehaviour
{
	public GameObject[] childs;

	public float limitAxisX;

	public Vector3
		firstPos,
		secondPos;

	// Update is called once per frame
	void Update()
	{

		transform.position += new Vector3(-GamePlayController.instance.moveSpeed * Time.deltaTime, 0f, 0f);

		if (transform.localPosition.x <= limitAxisX)
		{

			GamePlayController.instance.obstacles_Is_Active = false;
			gameObject.SetActive(false);

		}

	}

	void OnEnable()
	{
		for (int i = 0; i < childs.Length; i++)
		{
			childs[i].SetActive(true);
		}

		if (Random.value <= 0.5f)
		{
			transform.localPosition = firstPos;

		}
		else
		{
			transform.localPosition = secondPos;
		}

	}
}
