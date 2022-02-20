using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController
{
    PlayerController _player;
    System.Action _onEnd;

    public GamePlayController(System.Action onEnd)
    {
        _onEnd = onEnd;

        BasicSetup();
    }

    void BasicSetup()
    {
        var playUI = GameFlow.Instance.ShowUI<PlayUI>("PlayUI");

        _player = Object.Instantiate(Resources.Load<GameObject>("PlayerPrefab")).GetComponent<PlayerController>();
        _player.SetPlayerJoystick(playUI.GetJoystick());
        playUI.OnJump = () =>
        {
            _player.GetComponent<Jump>().StartJump();
        };

        playUI.SubscribeRotate((mousePos) =>
        {
            _player.RotateH(mousePos);
            _player.RotateV(mousePos);
        });
    }
}
