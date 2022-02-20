using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Personal.Common;
using Personal.Common.UI;
using Personal.Common.Utils;

public partial class GameFlow : MonoBehaviour
{
    public enum GameState
    {
        Init,
        Play,
        MainMenu,
    }

    public static GameFlow Instance { get; private set; }

    private GSMachine _gsMachine = new GSMachine();

    protected void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;

#if !UNITY_EDITOR && !BUILD_DEV
        Debug.unityLogger.logEnabled = false;
#endif

        Input.multiTouchEnabled = true;

#if UNITY_STANDALONE && !UNITY_EDITOR
        Screen.SetResolution(720, 1280, false);
#endif
        if (Application.isEditor)
            Application.runInBackground = true;

        Application.targetFrameRate = 60;
    }

    IEnumerator Start()
    {
        _gsMachine.Init(OnStateChanged, GameState.Init);

        while (true)
        {
            _gsMachine.StateUpdate();
            yield return null;
        }
    }

    void OnDestroy()
    {
        Instance = null;
    }


    public T ShowUI<T>(string uiPath, bool overlay = false) where T : UIController
    {
        return UIManager.Instance.ShowUIOnTop<T>(uiPath, overlay);
    }

    public void SceneTransition(System.Action onSceneOutFinished)
    {
        UIManager.Instance.SetUIInteractable(false);
        Color color;
        ColorUtility.TryParseHtmlString("#160A04", out color);

        SceneDirector.Instance.Transition(new TransitionFade()
        {
            duration = 0.667f,
            color = color,
            tweenIn = TweenFunc.TweenType.Sine_EaseInOut,
            tweenOut = TweenFunc.TweenType.Sine_EaseOut,
            onStepOutDidFinish = () =>
            {
                onSceneOutFinished.Invoke();
            },
            onStepInDidFinish = () =>
            {
                UIManager.Instance.SetUIInteractable(true);
            }
        });
    }

    GSMachine.UpdateStateDelegate OnStateChanged(System.Enum state)
    {
        switch (state)
        {
            case GameState.Init:
                return GameInit;

            case GameState.MainMenu:
                return null;

            case GameState.Play:
                return null;

        }

        return null;
    }

    public void FullscreenAdSetAppInputActive(bool enable)
    {
        UIManager.Instance.SetUIInteractable(enabled);
    }
}
