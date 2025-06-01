using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.SceneManagement;
using System;

public class SceneLoaderManager : MonoBehaviour
{
    public SceneLoaderView sceneLoaderView;

    public BgmManager bgmManager;

    private ReactiveProperty<SceneLoadingState> sceneLoadingState = new ReactiveProperty<SceneLoadingState>(SceneLoadingState.WAIT);

    private ReactiveProperty<AddressableLoadingState> addressableLoadingState = new ReactiveProperty<AddressableLoadingState>(AddressableLoadingState.WAIT);

    private Action completeAction;

    private SceneName sceneName;

    private Coroutine delayCompleteCoroutine;

    void Start()
    {
        SubscribeSceneLoadingState();
        SubscribeAddressableState();
        sceneLoaderView.CloseSceneLoading();
    }

    public void PlayBgm(SceneName sceneName)
    {
        bgmManager.PlayBgm(sceneName);
    }

    private void SubscribeSceneLoadingState()
    {
        sceneLoadingState.Subscribe(_sceneLoadingState =>
        {
            LoadingComplete();
        });
    }

    private void SubscribeAddressableState()
    {
        addressableLoadingState.Subscribe(_addressLoadingState =>
        {
            LoadingComplete();
        });
    }

    public void SetSceneLoadingState(SceneLoadingState _sceneLoadingState)
    {
        sceneLoadingState.SetValueAndForceNotify(_sceneLoadingState);
    }

    public void SetAddressableLoadingState(AddressableLoadingState _addressAbleLoadingState)
    {
        addressableLoadingState.SetValueAndForceNotify(_addressAbleLoadingState);
    }

    public void LoadingCompleteAction(Action _action)
    {
        completeAction = _action;
    }

    public void CloseSceneLoading()
    {
        StartCoroutine(WaitCoroutine(() => { sceneLoaderView.CloseSceneLoading(); }, 2.0f));
    }

    IEnumerator WaitCoroutine(Action _action, float _time)
    {
        yield return new WaitForSeconds(_time);
        _action.Invoke();
    }

    public void LoadingComplete()
    {
        if (sceneLoadingState.Value == SceneLoadingState.END && addressableLoadingState.Value == AddressableLoadingState.END)
        {
            // bgmManager.PlayBgm(sceneName);
            completeAction?.Invoke();
            sceneLoadingState.Value = SceneLoadingState.WAIT;
            addressableLoadingState.Value = AddressableLoadingState.WAIT;
        }
    }

    public void LoadScene(SceneName _sceneName)
    {
        if (_sceneName != SceneName.InGame)
        {
            sceneLoadingState.SetValueAndForceNotify(SceneLoadingState.END);
            SceneManager.LoadScene(_sceneName.ToString());
            sceneLoadingState.Value = SceneLoadingState.START;
            return;
        }

        sceneLoaderView.OpenSceneLoading();
        sceneName = _sceneName;
        StartCoroutine(MoveToSceneCoroutine(_sceneName, sceneLoaderView.SetProgress));
    }

    private IEnumerator MoveToSceneCoroutine(SceneName _name, Action<float> _action)
    {
        if (delayCompleteCoroutine != null)
            StopCoroutine(delayCompleteCoroutine);

        AsyncOperation async = SceneManager.LoadSceneAsync(_name.ToString());
        sceneLoadingState.Value = SceneLoadingState.START;

        while (!async.isDone)
        {
            // _action?.Invoke(async.progress);
            sceneLoadingState.SetValueAndForceNotify(SceneLoadingState.ING);
            yield return new WaitForSeconds(ConstSceneLoader.LOADING_WAIT);

            if (async.progress >= 1.0f)
            {
                yield return new WaitForSeconds(2.0f); // 2초
                _action?.Invoke(0.0f);
                yield return new WaitForSeconds(2.0f); // 4초
                _action?.Invoke(0.1f);
                yield return new WaitForSeconds(2.0f); // 6초
                _action?.Invoke(0.2f);
                yield return new WaitForSeconds(2.0f); // 8초
                _action?.Invoke(0.3f);
                yield return new WaitForSeconds(2.0f); // 10초
                _action?.Invoke(0.4f);
                yield return new WaitForSeconds(2.0f); // 12초
                _action?.Invoke(0.5f);
                yield return new WaitForSeconds(2.0f); // 14초
                _action?.Invoke(0.6f);
                yield return new WaitForSeconds(2.0f); // 16초
                _action?.Invoke(0.7f);
                yield return new WaitForSeconds(2.0f); // 18초
                _action?.Invoke(0.8f);
                yield return new WaitForSeconds(2.0f); // 20초
                _action?.Invoke(0.85f);
                yield return new WaitForSeconds(2.0f); // 22초
                _action?.Invoke(0.9f);
                yield return new WaitForSeconds(2.0f); // 24초
                _action?.Invoke(0.95f);
                yield return new WaitForSeconds(2.0f); // 26초
                _action?.Invoke(1.0f);

                sceneLoadingState.SetValueAndForceNotify(SceneLoadingState.END);

                yield return new WaitForSeconds(2.0f);
                bgmManager.StopAllAudios();
                yield break;
            }
        }
        yield return null;
    }
}

public enum SceneLoadingState
{
    WAIT,
    START,
    ING,
    END
}

public enum AddressableLoadingState
{
    WAIT,
    START,
    ING,
    END
}

public class ConstSceneLoader
{
    public const float LOADING_WAIT = 0.1f;
}

public enum SceneName
{
    FirstScene,
    GameStart,
    InGame,
    GameScore
}