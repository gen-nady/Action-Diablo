using QuestSystem.Player;
using UnityEngine;
using Zenject;

namespace NPCSystem
{
    public abstract class QuestNPC : MonoBehaviour
    {
        [SerializeField] protected string _idName;
        protected PlayerQuest _playerQuest;

        [Inject]
        private void Construct(PlayerQuest playerQuest)
        {
            _playerQuest = playerQuest;
        }
        
        public abstract void Talk();
    }
}