using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace MovementPlayground.Card
{
    public class PlayerAbilityTargettingManager : MonoBehaviour
    {
        public float RangeModifier = 1f;

        [SerializeField] LayerMask _groundMask;
        [SerializeField] Canvas _indicatorCanvas;
        [SerializeField] Image _skillshotImage, _rangeIndicatorImage;
        [SerializeField] Transform _aoeIndicatorTransform;

        Camera _cam;
        PlayerInput _playerInput;
        bool _isAiming = false;

        private void Awake()
        {
            _cam = Camera.main;
            _playerInput = new PlayerInput();
        }

        private void OnEnable()
        {
            CardPlayer.OnCardPlayed += CardPlayer_OnCardPlayed;
        }

        private void CardPlayer_OnCardPlayed(CardBase card)
        {
            switch (card.IndicatorType)
            {
                case CardBase.CardIndicatorType.Skillshot:
                    ShowSkillshot(true);
                    break;
                case CardBase.CardIndicatorType.AOE:
                    ShowAOE(true);
                    ShowRange(true);
                    break;
            }
        }

        private void Start()
        {
            ScaleRange(RangeModifier);

            _skillshotImage.gameObject.SetActive(false);
            _aoeIndicatorTransform.gameObject.SetActive(false);
            _rangeIndicatorImage.gameObject.SetActive(false);

            // subscribe to card play started event

        }

        private void Update()
        {
            Ray ray = _cam.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, _groundMask))
            {
                #region Skillshot
                Vector3 mousePosition = new Vector3(hitInfo.point.x, hitInfo.point.y, hitInfo.point.z);
                Quaternion rotation = Quaternion.LookRotation(mousePosition - transform.position); // the target rotation to face the mouse position
                rotation.eulerAngles = new Vector3(0, rotation.eulerAngles.y, rotation.eulerAngles.z); // 0 out the x rotation so the indicator will not point "up" or "down"
                transform.rotation = Quaternion.Lerp(rotation, transform.rotation, 0f); // rotate the canvas to face the mouse position
                #endregion

                #region AOE
                Vector3[] rangeBoundaries = new Vector3[4];
                _rangeIndicatorImage.rectTransform.GetWorldCorners(rangeBoundaries);
                float radiusOfRange = Vector3.Distance(rangeBoundaries[0], rangeBoundaries[1]) / 2; // gets distance from center to outer edge of range image

                Vector3 direction = (hitInfo.point - transform.position).normalized;
                float distance = Mathf.Clamp(Vector3.Distance(hitInfo.point, transform.position), 0, radiusOfRange);
                Vector3 targetPosition = transform.position + direction * distance;

                _aoeIndicatorTransform.position = targetPosition;
                #endregion
            }
        }

        private void ScaleRange(float rangeModifier)
        {
            var currentScale = _indicatorCanvas.transform.localScale;
            _indicatorCanvas.transform.localScale = new Vector3(currentScale.x * rangeModifier, currentScale.y, currentScale.z * rangeModifier);
        }

        private void ShowSkillshot(bool show)
        {
            _skillshotImage.gameObject.SetActive(show);
        }
        private void ShowAOE(bool show)
        {
            _aoeIndicatorTransform.gameObject.SetActive(show);
        }

        private void ShowRange(bool show)
        {
            _rangeIndicatorImage.gameObject.SetActive(show);
        }

    }
}
