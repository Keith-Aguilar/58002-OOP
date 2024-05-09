// AliyerEdon@mail.com Christmas 2022
// This is the main menu and coins manager component. Manage game saved data, load default game settings at the first run on the target device

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Space(7)]
    [Header("Play the game and press -H- key to delete game's save data")]
    // How many coins do you want to give to the player for the first game running on the device
    public int startingCoins = 1000;

    // Base coins... the minimum amout of the score that user can have
    public int minimumCoins = 1000;

    // Display the tatal coins amount
    public Text totalCoinsText;

    // Display the tatal scores amount
    public Text totalScoresText;

    /// //_____________________________________________________  
    void Start()
    {
        // The game is running at the first time... load default game settings
        if (PlayerPrefs.GetInt("FirstRun") != 1) // 1 = true ... 0 = false
        {

            // Apply the game starting coins at the first run of the game on the player's device
            PlayerPrefs.SetInt("Total Coins", startingCoins); // Assign starting coins for the first run on the target device

            // Base coins... the minimum amout of the score that user can have
            PlayerPrefs.SetInt("Minimum Coins", minimumCoins); // Assign starting coins for the first run on the target device

            // unlock the first level
            PlayerPrefs.SetInt("Level Unlocked0", 1); // Unlock the first level

            // The game now has been run (no anymore the first time's run)
            PlayerPrefs.SetInt("FirstRun", 1);

            // Activate the music by default
            PlayerPrefs.SetInt("Music", 1);
        }

        // If the total coins was less than the minimum coins, reset to the minimum coins
        if (PlayerPrefs.GetInt("Total Coins") < PlayerPrefs.GetInt("Minimum Coins"))
            PlayerPrefs.SetInt("Total Coins", PlayerPrefs.GetInt("Minimum Coins"));

        // Update display of the total coins text in the menu
        totalCoinsText.text = PlayerPrefs.GetInt("Total Coins").ToString();

        // Update display of the total scores text in the menu
        totalScoresText.text = PlayerPrefs.GetInt("Total Scores").ToString();

    }
    /// //_____________________________________________________  
    // Update is called once per frame
    void Update()
    {
        // Delete game saved data / settings
        if (Input.GetKeyDown(KeyCode.H))
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("Game's saved data deleted successfully");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    /// // Use this to enable any game object by clicking on a UI button
    public void Enable_Object(GameObject target)
    {
        target.SetActive(true);
    }
    /// // Use this to disablee any game object by clicking on a UI button
    public void Disable_Object(GameObject target)
    {
        target.SetActive(false);
    }
    /// // Use this to toggle enable / disable any game object by clicking on a UI button
    public void Toggle_Object(GameObject target)
    {
        target.SetActive(!target.activeSelf);
    }
}
