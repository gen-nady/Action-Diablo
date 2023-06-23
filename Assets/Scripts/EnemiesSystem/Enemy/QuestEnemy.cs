using QuestSystem;
using QuestSystem.Giver;
using QuestSystem.Player;
using UnityEngine;
using Zenject;

namespace EnemiesSystem.Enemy
{
    public abstract class QuestEnemy : MonoBehaviour
    {
        [SerializeField] protected string _idName;
        protected PlayerQuest _playerQuest;

        [Inject]
        private void Construct(PlayerQuest playerQuest)
        {
            _playerQuest = playerQuest;
        }

        #region MONO
        private void OnEnable()
        {
            QuestGiver.AddQuestToPlayer += ActiveEnemy;
            gameObject.SetActive(_playerQuest.IsShowQuestObject(_idName));
        }
   
        private void OnDisable()
        {  
            if(_idName != string.Empty)
                _playerQuest.EnemyKilled(_idName);
            QuestGiver.AddQuestToPlayer -= ActiveEnemy;
        }
        #endregion

        private void ActiveEnemy(Quest quest)
        {
            if(quest.Id == _idName)
                gameObject.SetActive(true);
        }
    }
}