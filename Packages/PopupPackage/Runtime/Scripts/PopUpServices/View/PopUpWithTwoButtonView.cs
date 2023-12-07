using System;
using UnityEngine;
using UnityEngine.UI;

namespace Services.PopUp.View
{
    public sealed class PopUpWithTwoButtonView : MonoBehaviour, IPopUpWithTwoButtonView
    {
        [SerializeField] private Button approveButton;
        [SerializeField] private Button cancelButton;

        public Action ApproveButton { get; set; }
        public Action CancelButton { get; set; }

        public void OnEnable()
        {
            approveButton.onClick.AddListener(() => ApproveButton?.Invoke());
            cancelButton.onClick.AddListener(() => CancelButton?.Invoke());
        }

        public void OnDisable()
        {
            approveButton.onClick.RemoveAllListeners();
            cancelButton.onClick.RemoveAllListeners();
        }
    }
}