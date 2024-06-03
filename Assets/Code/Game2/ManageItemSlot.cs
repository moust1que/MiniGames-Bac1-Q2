using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageItemSlot : MonoBehaviour {
	[SerializeField] private GM_Game2 m_GM;
	[SerializeField] private LivesDisplay m_LivesDisplay;

	[SerializeField] private GameObject[] m_House;

	[SerializeField] private GameObject[] m_RecipeBackground;

	private GameObject m_ObjectToAddOnSlot;

	[SerializeField] private List<Recipe> m_Recipes;
	[SerializeField] private List<CheckRecipe> m_CheckRecipes;
	[SerializeField] private GameObject[] m_UserItems;
	private int m_RecipeCount = 0;
	private bool m_BadRecipe = false;

	private void Start() {
		ShowRecipe();
	}

	private void ShowRecipe() {
		if(m_RecipeCount <= m_Recipes.Count) {
			for(int i = 0; i < 4; i++) {
				m_RecipeBackground[i].GetComponent<Image>().sprite = m_Recipes[m_RecipeCount].m_Recipe[i];
			}
		}
	}

	public void OnClick(int slotID) {
		if(m_GM.m_OnMouse && m_RecipeBackground[slotID].transform.childCount == 0) {
			m_GM.m_OnMouse = false;
			m_ObjectToAddOnSlot = Instantiate(m_GM.m_ObjectToAddOnMouse, m_RecipeBackground[slotID].transform.position, Quaternion.identity);
			
			m_ObjectToAddOnSlot.GetComponent<RectTransform>().localScale = Vector3.one;

			m_ObjectToAddOnSlot.transform.SetParent(m_RecipeBackground[slotID].transform);
			m_GM.RemoveItemOnMouse();
		}

	}

	public void CheckRecipe() {
		bool canContinue = GetUserItems();

		if(canContinue) {
			for(int i = 0; i < 4; i++) {
				if(!m_UserItems[i].name.Contains(m_CheckRecipes[m_RecipeCount].m_CheckRecipe[i].name))
					m_BadRecipe = true;
			}

			if(m_BadRecipe) {
				m_GM.m_Lives--;
				m_LivesDisplay.SetNewLives();
				m_BadRecipe = false;
			}else if(m_RecipeCount == m_Recipes.Count - 1) {
				m_House[m_RecipeCount].SetActive(true);
				m_GM.m_GameManager.EndGame();
			}else {
				m_House[m_RecipeCount].SetActive(true);
				m_RecipeCount++;
				ShowRecipe();
			}

			RemoveItems();
		}
	}

	private bool GetUserItems() {
		for(int i = 0; i < 4; i++) {
			if(m_RecipeBackground[i].transform.childCount == 0)
				return false;

			m_UserItems[i] = m_RecipeBackground[i].transform.GetChild(0).gameObject;
		}

		return true;
	}

	private void RemoveItems() {
		for(int i = 0; i < 4; i++) {
			Destroy(m_RecipeBackground[i].transform.GetChild(0).gameObject);
		}
	}
}

[Serializable]
public class Recipe {
	public List<Sprite> m_Recipe;
}

[Serializable]
public class CheckRecipe {
	public List<GameObject> m_CheckRecipe;
}