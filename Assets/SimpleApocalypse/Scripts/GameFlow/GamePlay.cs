using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Personal.Common.GSMachine;
using Personal.Common.UI;
using Personal.Common.Utils;
using UnityEngine.SceneManagement;

public partial class GameFlow : MonoBehaviour
{
    GamePlayController _gameplayController;

    void GamePlay(StateEvent stateEvent)
    {
        if (stateEvent == StateEvent.Enter)
        {
            _gameplayController = new GamePlayController(() =>
            {
                var async = SceneManager.LoadSceneAsync("bootstrap", LoadSceneMode.Additive);
            });
        }
        else if (stateEvent == StateEvent.Exit)
        {
            _gameplayController = null;
        }
    }
}
