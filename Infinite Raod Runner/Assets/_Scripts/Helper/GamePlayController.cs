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

    public GameObject obstacles_Obj;
    public GameObject[] obstacle_List;

    [HideInInspector]
    public bool obstacles_Is_Active;

    private string Coroutine_Name = "SpawnObstacles";
    void Awake()
    {
        MakeInstance();
    }

    private void Start()
    {
        gameJustStarted = true;

        GetObstacles();
        StartCoroutine(Coroutine_Name);
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

            if (!PlayerController.instance.player_Died)
            {

                if (moveSpeed < 12.0f)
                {
                    moveSpeed += Time.deltaTime * 5.0f;
                }
                else
                {
                    moveSpeed = 12;
                    gameJustStarted = false;
                }
            }
        }

        if (!PlayerController.instance.player_Died)
        {
            Camera.main.transform.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);

            UpdateScore();
        }
       
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

    void GetObstacles()
    {
        obstacle_List = new GameObject[obstacles_Obj.transform.childCount];

        for (int i = 0; i < obstacle_List.Length; i++)
        {
            obstacle_List[i] =
                obstacles_Obj.GetComponentsInChildren<ObstacleHolder>(true)[i].gameObject;
        }
    }

    IEnumerator SpawnObstacles()
    {

        while (true)
        {

            if (!PlayerController.instance.player_Died)
            {

                if (!obstacles_Is_Active)
                {

                    if (UnityEngine.Random.value <= 0.85f)
                    {

                        int randomIndex = 0;

                        do
                        {

                            randomIndex = UnityEngine.Random.Range(0, obstacle_List.Length);

                        } while (obstacle_List[randomIndex].activeInHierarchy);

                        obstacle_List[randomIndex].SetActive(true);
                        obstacles_Is_Active = true;

                    }

                }

            }

            yield return new WaitForSeconds(0.6f);
        }
    }
}
