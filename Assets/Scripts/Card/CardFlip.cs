using System.Collections;

using UnityEngine;
using UnityEngine.InputSystem;

namespace MovementPlayground.Card
{
    public class CardFlip : MonoBehaviour
    {
        [SerializeField]
        private GameObject _cardFront, _cardBack;

        PlayerInput _playerInput;

        bool _coroutineAllowed, _isFaceUp;

        private void Awake()
        {
            _playerInput = new PlayerInput();
            _playerInput.CharacterControls.FlipCards.performed += StartCardFlip;
        }

        private void StartCardFlip(InputAction.CallbackContext obj)
        {
            if (_coroutineAllowed)
                StartCoroutine(RotateCard());
        }

        private void OnEnable()
        {
            _playerInput.CharacterControls.Enable();
        }

        private void OnDisable()
        {
            _playerInput.CharacterControls.Disable();
        }

        private void Start()
        {
            _coroutineAllowed = true;
            _isFaceUp = true;
        }

        private IEnumerator RotateCard()
        {
            _coroutineAllowed = false;

            if (!_isFaceUp)
            {
                for (float i = 180f; i >= 0f; i -= 10f)
                {
                    transform.rotation = Quaternion.Euler(0f, i, 0f);
                    if (i == 90f)
                    {
                        _cardFront.SetActive(true);
                        _cardBack.SetActive(false);
                    }

                    yield return new WaitForSeconds(0.01f);
                }
            }
            else
            {
                for (float i = 180f; i >= 0f; i -= 10f)
                {
                    transform.rotation = Quaternion.Euler(0f, i, 0f);
                    if (i == 90f)
                    {
                        _cardFront.SetActive(false);
                        _cardBack.SetActive(true);
                    }

                    yield return new WaitForSeconds(0.01f);
                }
            }

            _coroutineAllowed = true;
            _isFaceUp = !_isFaceUp;
        }
    }
}