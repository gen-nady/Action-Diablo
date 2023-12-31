﻿using System;
using System.Collections;
using MainPlayer;
using SceneLoader.Scriptable;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace LoaderSystem
{
    public class SceneLoader : MonoBehaviour
    {
        public static event Action OnSceneChange;
        [SerializeField] private SceneLoaderObject _scenes;
        [SerializeField] private Vector3 _positionPoint;
        [SerializeField] private string _textButton;
        private Transform _currentTransform;
        private WorldInfoUI _worldInfoUI;

        [Inject]
        private void Construct(WorldInfoUI worldInfoUI)
        {
            _worldInfoUI = worldInfoUI;
        }

        #region MONO
        private void OnTriggerEnter(Collider col)
        {
            if (col.GetComponent<PlayerMovement>())
            {
                _currentTransform = col.gameObject.transform;
                _worldInfoUI.OpenButtonActionPanel(OpenNewScene, _textButton);
            }
        }

        private void OnTriggerExit(Collider col)
        {
            if (col.GetComponent<PlayerMovement>())
            {
                _worldInfoUI.CloseButtonActionPanel();
            }
        }
        #endregion
        
        private void OpenNewScene()
        {
            _currentTransform.position = _positionPoint;
            StartCoroutine(LoadLevelAsync());
        }

        private IEnumerator LoadLevelAsync()
        {
            _worldInfoUI.OpenLoading();
            var progress = SceneManager.LoadSceneAsync(_scenes.Scene.name, LoadSceneMode.Single);
            progress.allowSceneActivation = false;
            while (progress.progress < 0.9f)
            {
                yield return null;
            }
            progress.allowSceneActivation = true;
            OnSceneChange?.Invoke();
            _worldInfoUI.CloseButtonActionPanel();
            _worldInfoUI.CloseLoading();
        }
    }
}

