using System;

namespace Services.PopUp
{
    public interface IPopUpService
    {
        public void Show(string title, string body, Action onApproveAction = null);
        public void Show(string title, string body, Action onApproveAction = null, Action onCloseAction = null);
    }
}