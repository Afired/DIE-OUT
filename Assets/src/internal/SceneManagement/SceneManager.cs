﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DieOut.Helper;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DieOut.SceneManagement {

    public delegate void StartAsyncLevelLoading();
    public delegate void EndAsyncLevelLoading();

    public class SceneManager : MonoBehaviour {
        
        public static event StartAsyncLevelLoading StartAsyncLevelLoading;
        public static event EndAsyncLevelLoading EndAsyncLevelLoading;
        public static float LoadingProgress { get; private set; }
        [SerializeField] private SceneField _loadingScreenScene;
        private List<AsyncOperation> _scenesLoading = new List<AsyncOperation>();
        private static SingletonInstance<SceneManager> _instance;

        private void Awake() {
            _instance.Init(this);
        }
        
        public static void LoadScenesAsync(params string[] scenes) {
            StartAsyncLevelLoading?.Invoke();

            _instance.Get()._scenesLoading.Add(UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(_instance.Get()._loadingScreenScene.SceneName, LoadSceneMode.Single));
            for(int i = 0; i < scenes.Length; i++) {
                _instance.Get()._scenesLoading.Add(UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(scenes[i], LoadSceneMode.Additive));
            }

            _instance.Get().StartCoroutine(_instance.Get().GetSceneLoadProgress());
        }
        
        private IEnumerator GetSceneLoadProgress() {
            for(int i = 0; i < _scenesLoading.Count; i++) {
                while(!_scenesLoading[i].isDone) {
                    LoadingProgress = _scenesLoading.Sum(operation => operation.progress) / _scenesLoading.Count;
                    yield return null;
                }
            }
            EndAsyncLevelLoading?.Invoke();
            UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(_loadingScreenScene.SceneName, UnloadSceneOptions.None);
        }
        
        public static int sceneCount => UnityEngine.SceneManagement.SceneManager.sceneCount;
        public static int sceneCountInBuildSettings => UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;
        public static Scene GetSceneByName(string name) => UnityEngine.SceneManagement.SceneManager.GetSceneByName(name);
        public static Scene GetSceneAt(int index) => UnityEngine.SceneManagement.SceneManager.GetSceneAt(index);
        public static Scene GetActiveScene() => UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        public static Scene GetSceneByBuildIndex(int index) => UnityEngine.SceneManagement.SceneManager.GetSceneByBuildIndex(index);
        public static Scene GetSceneByPath(string scenePath) => UnityEngine.SceneManagement.SceneManager.GetSceneByPath(scenePath);

    }

}