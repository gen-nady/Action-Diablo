using MainPlayer;
using QuestSystem;
using QuestSystem.Giver;
using QuestSystem.Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Zenject;

namespace SaveSystem
{
    public class GameProgressStateService : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        private PlayerQuest _playerQuest;
        private Vector3 _positionPlayer;
        private int _currentScene;

        [Inject]
        private void Construct(PlayerQuest playerQuest)
        {
            _playerQuest = playerQuest;
        }
        
        private void Awake()
        {
            QuestGiver.QuestCompleted += SaveAfterQuest;
            QuestGiver.AddQuestToPlayer += SaveAfterQuest;
            LoaderSystem.SceneLoader.OnSceneChange += Save;
            
            if (ES3.KeyExists("PlayerPosition"))
            {
                _positionPlayer = ES3.Load<Vector3>("PlayerPosition");
                _playerMovement.transform.position = _positionPlayer;
            }
            
            if (ES3.KeyExists("CurrentScene"))
            {
                _currentScene = ES3.Load<int>("CurrentScene");
                //SceneManager.LoadSceneAsync(_currentScene);
            }
            
            _playerQuest.LoadProgressQuest();
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
            ES3.Save("PlayerPosition", _playerMovement.transform.position);
            ES3.Save("CurrentScene", SceneManager.GetActiveScene().buildIndex);
            _playerQuest.SaveProgressQuest();
        }
        
        private void OnApplicationQuit()
        {
            Save();
        }
    }
}