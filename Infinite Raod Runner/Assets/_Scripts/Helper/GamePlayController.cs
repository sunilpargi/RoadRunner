using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    public Text score_Text;
    public Text star_Score_Text;

    private int star_Score_Count, score_Count;

    public GameObject pause_Panel;
    public Animator pause_Anim;

    public GameObject gameOver_Panel;
    public Animator gameOver_Anim;

    public Text final_Score_Text, best_Score_Text, final_Star_Score_Text;
    void Awake()
    {
        MakeInstance();

        //score_Text = GameObject.Find("ScoreText").GetComponent<Text>();
        //star_Score_Text = GameObject.Find("StarText").GetComponent<Text>();
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

        // COUNT AND SHOW THE SCORE
        score_Count = (int)round; // save the score when the player dies
        score_Text.text = round.ToString();

        if (round > 30 && round < 60)
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

    public void UpdateStarScore()
    {
        star_Score_Count++;
        star_Score_Text.text = star_Score_Count.ToString();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pause_Panel.SetActive(true);
        pause_Anim.Play("SlideIn");
    }

    public void ResumeGame()
    {
        pause_Anim.Play("SlideOut");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Gameplay");
    }

    public void HomeButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOver_Panel.SetActive(true);
        gameOver_Anim.Play("SlideIn");

        final_Score_Text.text = score_Count.ToString();
        final_Star_Score_Text.text = star_Score_Count.ToString();


        //checking the higest score 
        if (GameManager.instance.score_Count < score_Count)
        {
            GameManager.instance.score_Count = score_Count;
        }

        best_Score_Text.text = GameManager.instance.score_Count.ToString();

        GameManager.instance.starScore += star_Score_Count;

        GameManager.instance.SaveGameData();

    }
}
