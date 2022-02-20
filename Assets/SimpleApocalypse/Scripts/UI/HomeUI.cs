using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Personal.UI;
using Personal.Common.UI;

public class HomeUI : UIController
{
    public System.Action OnPlay;

    public void Play()
    {
        OnPlay?.Invoke();
    }
}
