using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController
{
    PlayerController _player;
    System.Action _onEnd;
    PlayUI _playUI;

    public GamePlayController(System.Action onEnd)
    {
        _onEnd = onEnd;

        BasicSetup();
    }

    void BasicSetup()
    {
        _playUI = GameFlow.Instance.ShowUI<PlayUI>("PlayUI");

        _player = Object.Instantiate(Resources.Load<GameObject>("PlayerPrefab")).GetComponent<PlayerController>();
        _player.SetPlayerJoystick(_playUI.GetJoystick());

        MatchPlayerControl();
    }

    void MatchPlayerControl()
    {
        _playUI.OnJump = _player.GetComponent<Jump>().StartJump;
        _playUI.OnChangeGun = _player.ChangeGun;
        _playUI.OnFire = _player.Fire;

        _playUI.SubscribeRotate((mousePos) =>
        {
            _player.RotateH(mousePos);
            _player.RotateV(mousePos);
        });
    }
}
