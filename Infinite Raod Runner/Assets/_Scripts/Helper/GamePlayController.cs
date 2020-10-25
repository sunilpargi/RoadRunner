using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;

    public float moveSpeed, distance_Factor = 1f;

    private float distance_Move;
    private bool gameJustStarted;
    void Awake()
    {
        MakeInstance();
    }

    private void Start()
    {
        gameJustStarted = true;
    }
    private void MakeInstance()
    {
       if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        if (gameJustStarted)
        {
            if(moveSpeed < 12.0f)
            {
                moveSpeed += Time.deltaTime * 5.0f;
            }
            else
            {
                moveSpeed = 12;
                gameJustStarted = false;
            }
        }

        Camera.main.transform.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);

        UpdateScore();
    }

    private void UpdateScore()
    {
        distance_Move += Time.deltaTime * distance_Factor;
        int round = (int)Math.Round(distance_Move);

        if(round > 30 && round < 60)
        {
            moveSpeed = 14f;
        }
        else if(round > 60)
        {
            moveSpeed = 16f;
        }


    }
}
