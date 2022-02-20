using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Personal.Common.GSMachine;
using Personal.Common.UI;
using Personal.Common.Utils;

public partial class GameFlow : MonoBehaviour
{
    void GameInit(StateEvent stateEvent)
    {
        if (stateEvent == StateEvent.Enter)
        {
            var playUI = ShowUI<PlayUI>("PlayUI");
        }
        else if (stateEvent == StateEvent.Exit)
        {

        }
    }
}
