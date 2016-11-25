using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreateNotifications : MonoBehaviour
{
    [SerializeField]private Dropdown[] _dropdowns;
    [SerializeField]private Toggle _friendlyToggle;
    [SerializeField]private Sprite[] _champions;

    public void CreateNotification()
    {
        if (Notifications.OnKill != null)
            Notifications.OnKill(_champions[_dropdowns[0].value], _champions[_dropdowns[1].value], _friendlyToggle.isOn);
    }
}
