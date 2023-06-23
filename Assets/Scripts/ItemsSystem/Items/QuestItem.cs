using QuestSystem;
using QuestSystem.Giver;
using QuestSystem.Player;
using UnityEngine;
using Zenject;

namespace ItemsSystem.Items
{
    public abstract class QuestItem : MonoBehaviour
    {
        [SerializeField] protected string _idName;
        protected PlayerQuest _playerQuest;
        
        [Inject]
        private void Construct(PlayerQuest playerQuest)
        {
            _playerQuest = playerQuest;
        }

        protected virtual void OnEnable()
        {
            QuestGiver.AddQuestToPlayer += EnableItem;
            if(_idName == string.Empty) return;
            gameObject.SetActive(_playerQuest.IsShowQuestObject(_idName));
        }
        
        protected virtual void OnDestroy()
        {
            QuestGiver.AddQuestToPlayer -= EnableItem;
        }
        
        protected void EnableItem(Quest quest)
        {
            if(quest.Id == _idName)
                gameObject.SetActive(true);
        }
        
        public abstract void PickUp();
    }
}