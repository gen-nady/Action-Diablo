﻿using UnityEngine;

namespace Infastructure
{
    public class GameSettings : MonoBehaviour
    {
        private void Awake()
        {
            Application.targetFrameRate = 60;
        }
    }
}