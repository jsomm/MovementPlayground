using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace MovementPlayground.Card
{
    public class PlayerAbilityTargetingManager : MonoBehaviour
    {
        public float RangeModifier = 1f;

        [SerializeField] LayerMask _groundMask;
        [SerializeField] Canvas _indicatorCanvas;
        [SerializeField] Image _skillshotImage, _rangeIndicatorImage;
        [SerializeField] Transform _aoeIndicatorTransform;

        Camera _cam;
        Vector3[] _rangeBoundaries = new Vector3[4];
        float _radiusOfRange;

        private void Awake() => _cam = Camera.main;

        private void Start()
        {
            ScaleRange(RangeModifier);

            _skillshotImage.gameObject.SetActive(false);
            _aoeIndicatorTransform.gameObject.SetActive(false);
            _rangeIndicatorImage.gameObject.SetActive(false);

            // do these calculations in start, as they only need to be done one time
            _rangeIndicatorImage.rectTransform.GetWorldCorners(_rangeBoundaries);
            _radiusOfRange = Vector3.Distance(_rangeBoundaries[0], _rangeBoundaries[1]) / 2; // gets distance from center to outer edge of range image

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
                Vector3 direction = (hitInfo.point - transform.position).normalized;
                float distance = Mathf.Clamp(Vector3.Distance(hitInfo.point, transform.position), 0, _radiusOfRange);
                Vector3 targetPosition = transform.position + direction * distance;

                _aoeIndicatorTransform.position = targetPosition;
                #endregion
            }
        }

        public void ShowIndicatorForCard(CardBase card)
        {
            ScaleRange(card.RangeModifier);
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

        public void HideIndicators()
        {
            ShowSkillshot(false);
            ShowAOE(false);
            ShowRange(false);
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
