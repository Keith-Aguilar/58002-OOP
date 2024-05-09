// AliyerEdon@mail.com Christmas 2022
// Manage the level's lock system
// *** Use this in the main menu scene t manage the levels locks / unlocks

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    [Space(7)]
    [Header("Level Selection")]
    // Playable level's name
    public string[] levelsName;

    // The each level's price
    public int[] levelsPrice;
    public Text[] levelsPriceText;

    public GameObject[] levelsLock;

    [Space(7)]
    [Header("Display Menu")]
    // Show loading window when the player select the level and load the selected level
    public GameObject loadingWindow;

    // Show the current level purchase window if it was not unlocked yet
    public GameObject buyLevelWindow;

    // Internal variable
    int currenLevelForPurchase;

    private void Start()
    {
        // Check the level's locks and enable or disable the each level locks icon (game object)
        for (int a = 0; a < levelsLock.Length; a++)
        {
            // Level's lock state has been store in the player prefs
            if (PlayerPrefs.GetInt("Level Unlocked" + a.ToString()) == 1) // 1 = true  , 0 = false
                levelsLock[a].SetActive(false);
            else
                levelsLock[a].SetActive(true);

            // Show each level's price to buy
            levelsPriceText[a].text = levelsPrice[a].ToString() + " Coins";
        }
    }

    // Use this on the OnClick() event of the each level button in the menu
    public void Select_Level(int id)
    {
        // The current selected level is unlocked. So player can select it an start the level to play
        if(PlayerPrefs.GetInt("Level Unlocked" + id.ToString()) == 1) // 1 = true  , 0 = false
        { 
            PlayerPrefs.SetInt("Current Level", id);
            loadingWindow.SetActive(true);
            SceneManager.LoadSceneAsync(levelsName[id]);
        }
        else
        {
            // The current selected level is locked... So show the purchase window
            purchaseLevelID = id;
            buyLevelWindow.SetActive(true);
        }
    }

    // Use this in the buy button to buy the current selected level if the player has enough coins
    int purchaseLevelID;
    public void Buy_Level()
    {
        // Check the player has enough coins to buy the current level
        if(PlayerPrefs.GetInt("Total Coins") >= levelsPrice[purchaseLevelID])
        {
            // Reduce the coins
            PlayerPrefs.SetInt("Total Coins", PlayerPrefs.GetInt("Total Coins") - levelsPrice[purchaseLevelID]);
            
            // Disable the current level's lock icon (game object )
            levelsLock[purchaseLevelID].SetActive(false);
           
            // Update the total coins display text
            GameObject.FindObjectOfType<MainMenu>().totalCoinsText.text = PlayerPrefs.GetInt("Total Coins").ToString();
           
            // unlock the level (save the lock state into the player prefs )
            PlayerPrefs.SetInt("Level Unlocked" + purchaseLevelID.ToString(), 1);
           
            // Disable the level's purchase window
            buyLevelWindow.SetActive(false);
        }
    }
}
