using System.Collections;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Animator _playerAnimator;

    private readonly int _idleAnimationHash = Animator.StringToHash("PlayerIdle");
    private readonly int _runAnimationHash = Animator.StringToHash("PlayerRun");
    private readonly int _fadeAnimationHash = Animator.StringToHash("PlayerFade");

    private bool _isFading;
    
    private void OnEnable()
    {
        _player.OnDamageTake += OnDamageTake;
    }

    private void Update()
    {
        if (_isFading) return;
        
        if (_playerInput.VerticalInput != 0f)
        {
            _playerAnimator.CrossFade(_runAnimationHash, 0f);
        }
        else
        {
            _playerAnimator.CrossFade(_idleAnimationHash, 0f);
        }
    }

    private void OnDisable()
    {
        _player.OnDamageTake -= OnDamageTake;
    }

    private void OnDamageTake()
    {
        _isFading = true;
        _playerAnimator.CrossFade(_fadeAnimationHash, 0f);
        StartCoroutine(ResetFadeState());
    }

    private IEnumerator ResetFadeState()
    {
        yield return new WaitForSeconds(_playerAnimator.GetCurrentAnimatorStateInfo(0).length);
        _isFading = false;
    }
}