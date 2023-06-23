using UnityEngine;

namespace QuestSystem
{
    [CreateAssetMenu(fileName = "New Kill Quest", menuName = "Quest System/Kill Quest")]
    public class KillQuest : Quest
    {
        [SerializeField] private int _currentCount;
        
        public void EnemyKilled(string killId)
        {
            if (!_isComplete && killId == Id)
            {
                _currentCount++;
                if (_currentCount == _targetCount)
                {
                    _isComplete = true;
                }
            }
        }

        public override string CurrentTextProgress()
        {
            return $"Убито {_currentCount} из {_targetCount}";
        }
        
        public override void ResetValue()
        {
            _currentCount = 0;
            _isComplete = false;
        }
    }
}