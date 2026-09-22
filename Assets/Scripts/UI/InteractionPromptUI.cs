using UnityEngine;
using UnityEngine.UI;
using TMPro;
using StrikeZone.Player;

namespace StrikeZone.UI
{
    public class InteractionPromptUI : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GamePlayerInteractor interactor;
        [SerializeField] private GameObject promptPanel;
        [SerializeField] private TMP_Text promptText;
        [SerializeField] private Button interactButton;

        private void Awake()
        {
            if (interactor == null)
            {
                interactor =
                    FindFirstObjectByType<GamePlayerInteractor>();
            }

            if (interactButton != null)
            {
                interactButton.onClick.AddListener(
                    OnInteractPressed
                );
            }

            HidePrompt();
        }

        private void Update()
        {
            UpdatePrompt();
        }

        private void UpdatePrompt()
        {
            if (interactor == null ||
                interactor.CurrentInteractable == null)
            {
                HidePrompt();
                return;
            }

            string interactionText =
                interactor.GetInteractionText();

            if (string.IsNullOrEmpty(interactionText))
            {
                HidePrompt();
                return;
            }

            if (promptText != null)
            {
                promptText.text = interactionText;
            }

            if (promptPanel != null)
            {
                promptPanel.SetActive(true);
            }
        }

        private void OnInteractPressed()
        {
            if (interactor != null)
            {
                interactor.Interact();
            }
        }

        private void HidePrompt()
        {
            if (promptPanel != null)
            {
                promptPanel.SetActive(false);
            }
        }

        private void OnDestroy()
        {
            if (interactButton != null)
            {
                interactButton.onClick.RemoveListener(
                    OnInteractPressed
                );
            }
        }
    }
}
