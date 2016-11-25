using UnityEngine;
using System.Collections;

public class test : MonoBehaviour
{
    [SerializeField]
    private Sprite _player1;

    [SerializeField]
    private Sprite _player2;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (Notifications.OnKill != null)
                Notifications.OnKill(_player1, _player2, true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (Notifications.OnKill != null)
                Notifications.OnKill(_player2, _player1, true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (Notifications.OnKill != null)
                Notifications.OnKill(_player1, _player2, false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (Notifications.OnKill != null)
                Notifications.OnKill(_player2, _player1, false);
        }
    }
}
