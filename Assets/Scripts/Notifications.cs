using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Notifications : MonoBehaviour
{
    [SerializeField]private List<GameObject> _notifications = new List<GameObject>();

    [SerializeField]private GameObject _killNotification;

    public delegate void AddNotification(Sprite killer, Sprite killed, bool friendly);
    public static AddNotification OnKill;

    void OnEnable()
    {
        OnKill += CreateKillNotification;
        KillNotification.OnRemoveFromList += RemoveFromList;
    }

    void OnDisable()
    {
        OnKill -= CreateKillNotification;
        KillNotification.OnRemoveFromList -= RemoveFromList;
    }

    private void CreateKillNotification(Sprite killer, Sprite killed, bool friendly)
    {
        GameObject notification = Instantiate(_killNotification, _killNotification.transform.position, _killNotification.transform.rotation) as GameObject;
        notification.gameObject.transform.SetParent(this.gameObject.transform, false);
        Image tempImage = notification.GetComponent<Image>();
        KillNotification temp = notification.GetComponent<KillNotification>();
        temp.killer.sprite = killer;
        temp.killed.sprite = killed;

        if (friendly)
            tempImage.color = temp.friendlyColor;
        else
            tempImage.color = temp.enemyColor;

        _notifications.Add(notification);
        UpdateNotificationList();
    }

    private void UpdateNotificationList()
    {
        for (int i = 0; i < _notifications.Count; i++)
        {
            _notifications[i].GetComponent<KillNotification>().SetPosition();
        }
    }

    private void RemoveFromList(GameObject obj)
    {
        _notifications.Remove(obj);
    }
}
