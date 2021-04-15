using Deli.Patcher;
using Deli.Setup;
using FistVR;
using HarmonyLib;
using Mono.Cecil;
using UnityEngine;

namespace PauseMenuDeli
{
    public class MenuMod : DeliBehaviour
    {
        private static bool _gameIsPaused;
        
        public MenuMod()
        {
            Debug.Log("Deli mod worked");

            StartPatches();
        }

        private void Awake()
        {
            Debug.Log("Deli mod is awake");
        }
        
        
        private static void StartPatches()
        {
            Harmony.CreateAndPatchAll(typeof(MenuMod));
            Debug.Log("Patching...");
        }
        
        // Input stuff

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("Player pressing escape");
                if(_gameIsPaused) TurnOnGame();
                else TurnOffGame();
            }
        }

        private static void TurnOffGame()
        {
            Debug.Log("Pausing");
            _gameIsPaused = !_gameIsPaused;

            Time.timeScale = 0f;
        }
        
        private static void TurnOnGame()
        {
            Debug.Log("Entering Game again");
            _gameIsPaused = !_gameIsPaused;

            Time.timeScale = 1f;
        }
        

        // Patches

        [HarmonyPatch(typeof(FVRInteractiveObject), "BeginInteraction")]
        [HarmonyPostfix]
        private static void MenuPatch()
        {
            Debug.Log("you tocuhed soemthing");
        }
        
        // Stops hand input
        [HarmonyPatch(typeof(FVRViveHand), "PollInput")]
        [HarmonyPrefix]
        private static bool PollInputPatch()
        {
            return !_gameIsPaused;
        }
    }
}