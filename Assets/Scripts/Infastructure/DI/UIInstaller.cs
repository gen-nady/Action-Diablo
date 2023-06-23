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
        
        public override void InstallBindings()
        {
            Container.Bind<PlayerQuestUI>().FromInstance(_playerQuestUI).AsSingle();
            Container.Bind<QuestGiverUI>().FromInstance(_questGiverUI).AsSingle();  
            Container.Bind<TalkQuestUI>().FromInstance(_talkQuestUI).AsSingle();
        }
    }
}