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
        
        private void Awake()
        {
            QuestGiver.AddQuestToPlayer += KillEnemy;
            gameObject.SetActive(_playerQuest.IsShowQuestObject(_idName));
        }
   
        private void OnDestroy()
        {
            QuestGiver.AddQuestToPlayer -= KillEnemy;
        }

        private void KillEnemy(Quest quest)
        {
            if(quest.Id == _idName)
                gameObject.SetActive(true);
        }
    }
}