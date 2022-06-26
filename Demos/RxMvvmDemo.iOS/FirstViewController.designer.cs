// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace RxMvvmDemo.iOS
{
	[Register ("FirstViewController")]
	partial class FirstViewController
	{
		[Outlet]
		UIKit.UIActivityIndicatorView ActivityIndicator { get; set; }

		[Outlet]
		UIKit.UISwitch IsHiddenSwitch { get; set; }

		[Outlet]
		UIKit.UISwitch IsVisibleSwitch { get; set; }

		[Outlet]
		UIKit.UILabel LabelForTapInfo { get; set; }

		[Outlet]
		UIKit.UILabel MaxDateLabel { get; set; }

		[Outlet]
		UIKit.UIDatePicker MaxDatePicker { get; set; }

		[Outlet]
		UIKit.UILabel MinDateLabel { get; set; }

		[Outlet]
		UIKit.UIDatePicker MniDatePicker { get; set; }

		[Outlet]
		UIKit.UILabel SelectedDateLabel { get; set; }

		[Outlet]
		UIKit.UIDatePicker SelectedDatePicker { get; set; }

		[Outlet]
		UIKit.UILabel SelectedTimeLabel { get; set; }

		[Outlet]
		UIKit.UISlider Slider { get; set; }

		[Outlet]
		UIKit.UILabel SliderValLbl { get; set; }

		[Outlet]
		UIKit.UIStepper Stepper { get; set; }

		[Outlet]
		UIKit.UILabel StepperValLbl { get; set; }

		[Outlet]
		UIKit.UITextField TxtField { get; set; }

		[Outlet]
		UIKit.UILabel TxtLbl { get; set; }

		[Outlet]
		UIKit.UITextView TxtView { get; set; }

		[Outlet]
		UIKit.UIView ViewTo2FingerTap { get; set; }

		[Outlet]
		UIKit.UIView ViewToDoubleTap { get; set; }

		[Outlet]
		UIKit.UIView ViewToIsHiddenSet { get; set; }

		[Outlet]
		UIKit.UIView ViewToIsVisibleSet { get; set; }

		[Outlet]
		UIKit.UIView ViewToTap { get; set; }

		[Outlet]
		UIKit.UIView ViewToVisibilitySet { get; set; }

		[Outlet]
		UIKit.NSLayoutConstraint ViewToVisibilitySetHeight { get; set; }

		[Outlet]
		UIKit.NSLayoutConstraint ViewToVisibilitySetWidth { get; set; }

		[Outlet]
		UIKit.UISegmentedControl VisibilitySelectionControl { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ActivityIndicator != null) {
				ActivityIndicator.Dispose ();
				ActivityIndicator = null;
			}

			if (IsHiddenSwitch != null) {
				IsHiddenSwitch.Dispose ();
				IsHiddenSwitch = null;
			}

			if (IsVisibleSwitch != null) {
				IsVisibleSwitch.Dispose ();
				IsVisibleSwitch = null;
			}

			if (LabelForTapInfo != null) {
				LabelForTapInfo.Dispose ();
				LabelForTapInfo = null;
			}

			if (MaxDateLabel != null) {
				MaxDateLabel.Dispose ();
				MaxDateLabel = null;
			}

			if (MaxDatePicker != null) {
				MaxDatePicker.Dispose ();
				MaxDatePicker = null;
			}

			if (MinDateLabel != null) {
				MinDateLabel.Dispose ();
				MinDateLabel = null;
			}

			if (MniDatePicker != null) {
				MniDatePicker.Dispose ();
				MniDatePicker = null;
			}

			if (SelectedDateLabel != null) {
				SelectedDateLabel.Dispose ();
				SelectedDateLabel = null;
			}

			if (SelectedDatePicker != null) {
				SelectedDatePicker.Dispose ();
				SelectedDatePicker = null;
			}

			if (SelectedTimeLabel != null) {
				SelectedTimeLabel.Dispose ();
				SelectedTimeLabel = null;
			}

			if (ViewTo2FingerTap != null) {
				ViewTo2FingerTap.Dispose ();
				ViewTo2FingerTap = null;
			}

			if (ViewToDoubleTap != null) {
				ViewToDoubleTap.Dispose ();
				ViewToDoubleTap = null;
			}

			if (ViewToIsHiddenSet != null) {
				ViewToIsHiddenSet.Dispose ();
				ViewToIsHiddenSet = null;
			}

			if (ViewToIsVisibleSet != null) {
				ViewToIsVisibleSet.Dispose ();
				ViewToIsVisibleSet = null;
			}

			if (ViewToTap != null) {
				ViewToTap.Dispose ();
				ViewToTap = null;
			}

			if (ViewToVisibilitySet != null) {
				ViewToVisibilitySet.Dispose ();
				ViewToVisibilitySet = null;
			}

			if (ViewToVisibilitySetHeight != null) {
				ViewToVisibilitySetHeight.Dispose ();
				ViewToVisibilitySetHeight = null;
			}

			if (ViewToVisibilitySetWidth != null) {
				ViewToVisibilitySetWidth.Dispose ();
				ViewToVisibilitySetWidth = null;
			}

			if (VisibilitySelectionControl != null) {
				VisibilitySelectionControl.Dispose ();
				VisibilitySelectionControl = null;
			}

			if (TxtField != null) {
				TxtField.Dispose ();
				TxtField = null;
			}

			if (TxtView != null) {
				TxtView.Dispose ();
				TxtView = null;
			}

			if (TxtLbl != null) {
				TxtLbl.Dispose ();
				TxtLbl = null;
			}

			if (Stepper != null) {
				Stepper.Dispose ();
				Stepper = null;
			}

			if (Slider != null) {
				Slider.Dispose ();
				Slider = null;
			}

			if (StepperValLbl != null) {
				StepperValLbl.Dispose ();
				StepperValLbl = null;
			}

			if (SliderValLbl != null) {
				SliderValLbl.Dispose ();
				SliderValLbl = null;
			}
		}
	}
}
