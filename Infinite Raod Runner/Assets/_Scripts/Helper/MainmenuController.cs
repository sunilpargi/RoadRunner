using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainmenuController : MonoBehaviour
{
    public GameObject hero_Menu;
    public Text starScoreText;

    public Image music_Img;
    public Sprite music_Off, music_On;
	public void PlayGame()
	{
		SceneManager.LoadScene("Gameplay");
	}

	public void HeroMenu()
	{
		hero_Menu.SetActive(true);
		// starScoreText.text = "" + GameManager.instance.starScore;
	}

	public void HomeButton()
	{
		hero_Menu.SetActive(false);
	}
}
