using EvilGenius.RxDataBindings.Core;
using System;
using System.Linq;
using UIKit;

namespace EvilGenius.RxDataBindings.iOS.TargetProxies
{
    public class UIViewVisibilityTargetProxy : BaseUIViewVisibilityTargetProxy<Visibility>
    {
        private NSLayoutConstraint _widthConstraint;
        private NSLayoutConstraint _heightConstraint;
        private nfloat _heightOriginalConstant;
        private nfloat _widthOriginalConstant;
        private Visibility? _lastAcceptedVisibility;
        private readonly bool _isCollapsedModeSupported = false;

        public UIViewVisibilityTargetProxy(UIView target, NSLayoutConstraint widthConstraint = null, NSLayoutConstraint heightConstraint = null) : base(target) 
        {
            if (widthConstraint != null)
                _widthConstraint = widthConstraint;
            else
            {
                _widthConstraint = target.Constraints?
                    .SingleOrDefault(c => c.FirstAttribute == NSLayoutAttribute.Width && c.SecondAttribute == NSLayoutAttribute.NoAttribute);

                if(_widthConstraint != null)
                    _widthOriginalConstant = _widthConstraint.Constant;
            }

            if (heightConstraint != null)
                _heightConstraint = heightConstraint;
            else
            {
                _heightConstraint = target.Constraints?
                    .SingleOrDefault(c => c.FirstAttribute == NSLayoutAttribute.Height && c.SecondAttribute == NSLayoutAttribute.NoAttribute);

                if (_heightConstraint != null)
                    _heightOriginalConstant = _heightConstraint.Constant;
            }

            _isCollapsedModeSupported = _widthConstraint != null && _heightConstraint != null;
        }

        protected override bool IsHidden(Visibility value) => value != Visibility.Visible;

        protected override void AcceptValue(Visibility value)
        {
            if (value == Visibility.Collapsed)
            {
                if (_isCollapsedModeSupported)
                    SetConstraints(0, 0);
                else base.AcceptValue(value);
            }
            else
            {
                if (_isCollapsedModeSupported)
                {
                    if (_lastAcceptedVisibility == Visibility.Collapsed)
                    SetConstraints(_widthOriginalConstant, _heightOriginalConstant);
                }

                base.AcceptValue(value);
            }

            _lastAcceptedVisibility = value;
        }

        private void SetConstraints(nfloat widthConstant, nfloat heightConstant)
        {
            _widthConstraint.Constant = widthConstant;
            _heightConstraint.Constant = heightConstant;
        }

        protected override void Dispose(bool disposing)
        {
            _widthConstraint = null;
            _heightConstraint = null;
            _lastAcceptedVisibility = null;

            base.Dispose(disposing);
        }
    }
}