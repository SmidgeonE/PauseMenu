using System;
using BepInEx;
using UnityEngine;
using HarmonyLib;
using UnityEngine.EventSystems;

namespace PauseMenu
{
    [BepInPlugin("PauseMenuMod", "PauseMenuMod", "1.0.0")]
    public class PauseMenuMod : BaseUnityPlugin
    {
        private static bool _gameIsPaused;
        
        private void Update()
        {
            CheckForButtonPress();
        }

        private void CheckForButtonPress()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Debug.Log("Player pressing escape");
                if(_gameIsPaused) TurnOnGame();
                else TurnOffGame();
            }
        }

        private void TurnOffGame()
        {
            Debug.Log("Pausing");
            _gameIsPaused = !_gameIsPaused;

            Time.timeScale = 0f;
        }

        private void TurnOnGame()
        {
            Debug.Log("Entering Game again");
            _gameIsPaused = !_gameIsPaused;

            Time.timeScale = 1f;
        }
    }
}
