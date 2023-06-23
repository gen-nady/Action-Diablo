using System;
using ItemsSystem.Items;
using NPCSystem.NPC;
using UnityEngine;

namespace MainPlayer
{
    public class PlayerTarget : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<QuestItem>(out var pickUp))
            {
                pickUp.PickUp();
                return;
            }
            
            // if (other.TryGetComponent<QuestEnemy>(out var enemy))
            // {
            //     enemy.TakeDamage();
            //     return;
            // }
            
            if (other.TryGetComponent<QuestNPC>(out var talk))
            {
                talk.Talk();
                return;
            }
        }
    }
}