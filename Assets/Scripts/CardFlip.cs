using System.Collections;

using UnityEngine;
using UnityEngine.InputSystem;

public class CardFlip : MonoBehaviour
{
    [SerializeField]
    private GameObject CardFront, CardBack;

    PlayerInput playerInput;

    bool coroutineAllowed, isFaceUp;

    private void Awake()
    {
        playerInput = new PlayerInput();
        playerInput.CharacterControls.FlipCards.performed += StartCardFlip;
    }

    private void StartCardFlip(InputAction.CallbackContext obj)
    {
        if (coroutineAllowed)
            StartCoroutine(RotateCard());
    }

    private void OnEnable()
    {
        playerInput.CharacterControls.Enable();
    }

    private void OnDisable()
    {
        playerInput.CharacterControls.Disable();
    }

    private void Start()
    {
        coroutineAllowed = true;
        isFaceUp = true;
    }

    private IEnumerator RotateCard()
    {
        coroutineAllowed = false;

        if (!isFaceUp)
        {
            for (float i = 180f; i >= 0f; i -= 10f)
            {
                transform.rotation = Quaternion.Euler(0f, i, 0f);
                if (i == 90f)
                {
                    CardFront.SetActive(true);
                    CardBack.SetActive(false);
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
                    CardFront.SetActive(false);
                    CardBack.SetActive(true);
                }
                yield return new WaitForSeconds(0.01f);
            }
        }

        coroutineAllowed = true;
        isFaceUp = !isFaceUp;
    }
}
