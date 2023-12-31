﻿using InventorySystem.UI;
using QuestSystem.Giver;
using QuestSystem.Player;
using QuestSystem.Talk;
using UnityEngine;
using Zenject;

namespace Infastructure
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private PlayerQuestUI _playerQuestUI;
        [SerializeField] private QuestGiverUI _questGiverUI;
        [SerializeField] private TalkQuestUI _talkQuestUI;
        [SerializeField] private WorldInfoUI _worldInfoUI;
        [SerializeField] private UIInventory _inventoryUI;
        
        public override void InstallBindings()
        {
            Container.Bind<PlayerQuestUI>().FromInstance(_playerQuestUI).AsSingle();
            Container.Bind<QuestGiverUI>().FromInstance(_questGiverUI).AsSingle();  
            Container.Bind<TalkQuestUI>().FromInstance(_talkQuestUI).AsSingle(); 
            Container.Bind<WorldInfoUI>().FromInstance(_worldInfoUI).AsSingle();
            Container.Bind<UIInventory>().FromInstance(_inventoryUI).AsSingle();
        }
    }
}