using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Personal.Common.GSMachine;
using Personal.Common.UI;
using Personal.Common.Utils;
using UnityEngine.SceneManagement;

public partial class GameFlow : MonoBehaviour
{
    void GameMainMenu(StateEvent stateEvent)
    {
        if (stateEvent == StateEvent.Enter)
        {
            var homeUI = ShowUI<HomeUI>("HomeUI");
            homeUI.OnPlay = () =>
            {
                var async = SceneManager.LoadSceneAsync("SA", LoadSceneMode.Additive);

                UIManager.Instance.SetUIInteractable(false);

                async.allowSceneActivation = true;
                async.completed += (asyncOperation) =>
                {
                    SceneTransition(() =>
                    {
                        _gsMachine.ChangeState(GameState.Play);
                    });

                    UIManager.Instance.ReleaseUI(homeUI, true);
                    UIManager.Instance.SetUIInteractable(true);
                };
            };
        }
        else if (stateEvent == StateEvent.Exit)
        {

        }
    }
}
