using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KillNotification : MonoBehaviour
{
    public delegate void RemoveFromListAction(GameObject obj);
    public static RemoveFromListAction OnRemoveFromList;


    [SerializeField]private float _timeToDelete;
    private float _timeLeft;

    private int _currentPosition = 0;

    private Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        StartCoroutine(Timer());
    }

    [SerializeField]private Image _killer;
    public Image killer
    {
        get { return _killer; }
        set { _killer = value; }
    }
    [SerializeField]private Image _killed;
    public Image killed
    {
        get { return _killed; }
        set { _killed = value; }
    }

    private bool _friendly;
    public bool friendly
    {
        get { return _friendly; }
        set { _friendly = value; }
    }

    [SerializeField]private Color _friendlyColor;
    public Color friendlyColor
    {
        get { return _friendlyColor; }
    }
    [SerializeField]private Color _enemyColor;
    public Color enemyColor
    {
        get { return _enemyColor; }
    }

    public void SetPosition()
    {
        _currentPosition++;
        SetAnimationInt(_currentPosition);
        //ResetTimer();
    }

    private void SetAnimationInt(int value)
    {
        _animator.SetInteger("position", value);
    }

    private IEnumerator Timer()
    {
        ResetTimer();
        while(_timeLeft > 0)
        {
            yield return new WaitForSeconds(1f);
            _timeLeft--;
        }
        SetAnimationInt(5);
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
        if(OnRemoveFromList != null)
            OnRemoveFromList(this.gameObject);
    }

    private void ResetTimer()
    {
        _timeLeft = _timeToDelete;
    }
}
