using QuestSystem;
using UnityEngine;
using Zenject;

namespace EnemiesSystem
{
    public abstract class Enemy : MonoBehaviour
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

        private void KillEnemy(Quest.Quest quest)
        {
            if(quest.Id == _idName)
                gameObject.SetActive(true);
        }
    }
}