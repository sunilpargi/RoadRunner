using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaterSelect : MonoBehaviour
{
    public GameObject[] available_Heroes;

    private int currentIndex;

    public Text selectedText;
    public GameObject starIcon;
    public Image selectBtn_Image;
    public Sprite button_Green, button_Blue;

    private bool[] heroes;

    public Text starScoreText;
	void Start()
	{
		InitializeCharacters();
	}

	void InitializeCharacters()
	{

	//	currentIndex = GameManager.instance.selected_Index;

		for (int i = 0; i < available_Heroes.Length; i++)
		{
			available_Heroes[i].SetActive(false);
		}
		available_Heroes[currentIndex].SetActive(true);

	//	heroes = GameManager.instance.heroes;
	}

	public void NextHero()
	{
		available_Heroes[currentIndex].SetActive(false);

		if (currentIndex + 1 == available_Heroes.Length)
		{
			currentIndex = 0;

		}
		else
		{
			currentIndex++;
		}

		available_Heroes[currentIndex].SetActive(true);

	//	CheckIfCharacterIsUnlocked();

	}

	public void PreviousHero()
	{
		available_Heroes[currentIndex].SetActive(false);

		if (currentIndex - 1 == -1)
		{
			currentIndex = available_Heroes.Length - 1;

		}
		else
		{
			currentIndex--;
		}

		available_Heroes[currentIndex].SetActive(true);

		//CheckIfCharacterIsUnlocked();

	}
}
