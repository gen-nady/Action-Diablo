using System.Collections.Generic;
using QuestSystem;
using UnityEngine;

namespace Helpers.DeleteProgressQuest
{
    [CreateAssetMenu(fileName = "!Resetter", menuName = "Quest System/Resetter")]
    public class ScriptableObjectList : ScriptableObject
    {
        public List<Quest> Quests;
    }
}
