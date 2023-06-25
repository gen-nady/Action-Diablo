using System.Collections.Generic;
using System.Linq;
using QuestSystem.Giver;
using UnityEngine;

namespace QuestSystem.Player
{
    public class PlayerQuestUI : MonoBehaviour
    {
        [SerializeField] private GameObject _panelQuest;
        [SerializeField] private PlayerQuestPrefab _playerQuestPrefab;
        [SerializeField] private RectTransform _intantiatePosition;
        private List<PlayerQuestPrefab> _playerQuest = new List<PlayerQuestPrefab>();
        
        private void OnEnable()
        {
            QuestGiver.AddQuestToPlayer += SetInfoOrQuest;
            QuestGiver.QuestCompleted += ResetQuest;
        }

        private void OnDestroy()
        {
            QuestGiver.AddQuestToPlayer -= SetInfoOrQuest;
            QuestGiver.QuestCompleted -= ResetQuest;
        }

        public void QuestPanelActiveState()
        {
            _panelQuest.SetActive(!_panelQuest.activeSelf);
        }
        
        public void ChangeProgress(Quest quest)
        {
             _playerQuest.FirstOrDefault(_ => _.IdQuest == quest.Id)!.ChangeProgress(quest);
        }
        public void SetInfoOrQuest(Quest quest)
        {
            var questPrefab = Instantiate(_playerQuestPrefab, _intantiatePosition);
            _playerQuest.Add(questPrefab);
            questPrefab.SetValue(quest);
        }
        private void ResetQuest(Quest quest)
        {
            var curQuest = _playerQuest.FirstOrDefault(_ => _.IdQuest == quest.Id)!;
            curQuest. gameObject.SetActive(false);
            _playerQuest.Remove(curQuest);
        }
    }
}