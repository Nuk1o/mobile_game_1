using UnityEngine;

public class Animation_play : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void click_anim(string trigger)
    {
        _animator.SetTrigger(trigger);
    }
}
