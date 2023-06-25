using System;
using System.Collections.Generic;
using MainPlayer;
using QuestSystem.Player;
using UnityEngine;
using Zenject;

namespace QuestSystem.Giver
{
    public class QuestGiver : MonoBehaviour
    {
        public static event Action<Quest> AddQuestToPlayer;
        public static event Action<Quest> QuestCompleted;
        [SerializeField] private List<Quest> _quests;
        [SerializeField] private GameObject _activeQuestPanel;
        [SerializeField] private Material _activeQuestMaterial;
        private bool _isActiveQuest;
        private bool _isAllQuest;
        private QuestGiverUI _questGiverUI;
        private PlayerQuest _playerQuest;
        private WorldInfoUI _worldInfoUI;

        [Inject]
        private void Construct(QuestGiverUI questGiverUI, PlayerQuest playerQuest, WorldInfoUI worldInfoUI)
        {
            _questGiverUI = questGiverUI;
            _playerQuest = playerQuest;
            _worldInfoUI = worldInfoUI;
        }
        
        private void OnEnable()
        {
            if (_quests.Count > 0)
            {
                for (int i = 0; i < _quests.Count; i++)
                {
                    if (_playerQuest.IsCompletedQuest(_quests[i].Id))
                    {
                        _quests.RemoveAt(i);
                    }
                    else
                    {
                        var isActiveQuest = _playerQuest.IsQuestExist(_quests[0].Id);
                        if (isActiveQuest)
                        {
                            _activeQuestPanel.SetActive(true);
                            _activeQuestMaterial.color = Color.grey;
                        }

                        _isActiveQuest = isActiveQuest;
                        break;
                    }
                }
            }
            else
            {
                _isAllQuest = true;
            }
        }

        private void AddQusetToPlayer()
        {
            AddQuestToPlayer?.Invoke(_quests[0]);
            _activeQuestPanel.SetActive(true);
            _activeQuestMaterial.color = Color.grey;
            _isActiveQuest = true;
        }
        
        private void GetBonusesForQuest()
        {
            QuestCompleted?.Invoke(_quests[0]);
            _activeQuestPanel.SetActive(false);
            CheckForActiveQuest(_quests[0]);
        }

        private void CheckForActiveQuest(Quest quest)
        {
            _quests.Remove(quest);
            if (_quests.Count > 0)
            {
                if(quest is TalkQuest) return;
                if (_playerQuest.IsCompletedQuest(_quests[0].PrevIdQuest))
                {
                    _questGiverUI.SetQuestText(_quests[0], AddQusetToPlayer);
                    _activeQuestPanel.SetActive(true);
                    _activeQuestMaterial.color = Color.yellow;
                    _isActiveQuest = false;
                    return;
                }
                return;
            }
            _isAllQuest = true;
        }

        public void CompletedTalkQuest()
        {
            if (_isActiveQuest && _playerQuest.IsQuestExist(_quests[0].Id) && _quests[0].IsCompleted)
            {
                _questGiverUI.CompletedQuest(_quests[0],GetBonusesForQuest);
            }
        }

        private void CompletedQuest()
        {
            _questGiverUI.CompletedQuest(_quests[0], GetBonusesForQuest);
        }
        
        private void GetQuest()
        {
            _questGiverUI.SetQuestText(_quests[0], AddQusetToPlayer);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if(_isAllQuest) return;
            if (other.GetComponent<PlayerMovement>())
            {
                if (_isActiveQuest)
                {
                    if (_playerQuest.IsQuestExist(_quests[0].Id) && _quests[0].IsCompleted)
                    {
                        _worldInfoUI.OpenButtonActionPanel(CompletedQuest, "Talk");

                    }
                }
                else if (_quests.Count > 0 && _playerQuest.IsCompletedQuest(_quests[0].PrevIdQuest))
                {
                    (_quests[0] as TalkQuest)?.SetQuestGiver(this);
                    _worldInfoUI.OpenButtonActionPanel(GetQuest, "Talk");
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<PlayerMovement>())
            {
                _questGiverUI.CloseQuestPanel();
                _questGiverUI.CloseBonusesPanel();
            }
        }
    }
}