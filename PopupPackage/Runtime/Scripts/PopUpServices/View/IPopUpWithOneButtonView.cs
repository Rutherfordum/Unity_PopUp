using System;

namespace Services.PopUp.View
{
    public interface IPopUpWithOneButtonView
    {
        public Action ApproveButton { get; set; }
    }
}