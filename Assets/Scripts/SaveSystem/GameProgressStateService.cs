using MainPlayer;
using QuestSystem;
using QuestSystem.Giver;
using QuestSystem.Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace SaveSystem
{
    public class GameProgressStateService : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _mainPlayerMovement;
        private PlayerQuest _playerQuest;
        private PlayerQuestUI _playerQuestUI;
        private Vector3 _positionPlayer;
        private int _currentScene;

        
        [Inject]
        private void Construct(PlayerQuest playerQuest, PlayerQuestUI playerQuestUI)
        {
            _playerQuest = playerQuest;
            _playerQuestUI = playerQuestUI;
        }
        
        private void Awake()
        {
            QuestGiver.QuestCompleted += SaveAfterQuest;
            QuestGiver.AddQuestToPlayer += SaveAfterQuest;
            LoaderSystem.SceneLoader.OnSceneChange += Save;
            
            // if (ES3.KeyExists("PlayerPosition"))
            // {
            //     _positionPlayer = ES3.Load<Vector3>("PlayerPosition");
            //     _mainPlayerMovement.transform.position = _positionPlayer;
            // }
            //
            // if (ES3.KeyExists("CurrentScene"))
            // {
            //     _currentScene = ES3.Load<int>("CurrentScene");
            //     SceneManager.LoadScene(_currentScene);
            // }
            
           // _playerQuest.LoadProgressQuest();
        }

        private void OnDisable()
        {
            QuestGiver.QuestCompleted -= SaveAfterQuest;
            QuestGiver.AddQuestToPlayer -= SaveAfterQuest;
            LoaderSystem.SceneLoader.OnSceneChange -= Save;
        }

        private void SaveAfterQuest(Quest quest)
        {
            Save();
        }

        private void Save()
        {
            // ES3.Save("PlayerPosition", _mainPlayerMovement.transform.position);
            // ES3.Save("CurrentScene", SceneManager.GetActiveScene().buildIndex);
            // _playerQuest.SaveProgressQuest();
        }
        
        private void OnApplicationQuit()
        {
            Save();
        }
    }
}