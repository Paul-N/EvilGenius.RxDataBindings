using Android.Content;
using Android.Graphics.Drawables;
using Android.Preferences;
using Android.Text;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using EvilGenius.RxDataBindings.Android.TargetProxies;
using EvilGenius.RxDataBindings.Core;
using EvilGenius.RxDataBindings.Proxies;
using Java.Lang;
using OneOf;
using System.Collections.Generic;

namespace EvilGenius.RxDataBindings.Android
{
    public static class AndroidPropertyProxyExtensions
    {
        public static CommandTargetProxy BindClick(this View view) 
            => new ViewClickTargetProxy(view);

        public static ValueAcceptorProviderTargetProxy<string> BindText(this TextView textview) 
            => new TextViewTextTargetProxy(textview);

#nullable enable

        public static ValueAcceptorProviderTargetProxy<OneOf<ICharSequence?, ISpanned>> BindTextFormatted(this TextView textview) 
            => new TextViewTextFormattedTargetProxy(textview);

#nullable disable

        //public static string BindPartialText(this MvxAutoCompleteTextView mvxAutoCompleteTextView)
        //    => MvxAndroidPropertyBinding.MvxAutoCompleteTextView_PartialText;

        //public static string BindSelectedObject(this MvxAutoCompleteTextView mvxAutoCompleteTextView)
        //    => MvxAndroidPropertyBinding.MvxAutoCompleteTextView_SelectedObject;

        public static ValueAcceptorProviderTargetProxy<bool> BindChecked(this CompoundButton compoundButton) 
            => new CompoundButtonCheckedTargetProxy(compoundButton);

        public static ValueAcceptorProviderTargetProxy<int> BindProgress(this SeekBar seekBar)
            => new SeekBarProgressTargetProxy(seekBar);

        public static ValueAcceptorTargetProxy<bool> BindVisible(this View view) 
            => new ViewVisibleTargetProxy(view);

        public static ValueAcceptorTargetProxy<bool> BindHidden(this View view) 
            => new ViewHiddenTargetProxy(view);

        public static ValueAcceptorTargetProxy<Visibility> BindVisibility(this View view) 
            => new ViewVisibilityTargetProxy(view);

        public static ImageViewBitmapTargetProxy BindBitmap(this ImageView imageView) 
            => new ImageViewBitmapTargetProxy(imageView);

        public static ValueAcceptorTargetProxy<Drawable> BindDrawable(this ImageView imageView) 
            => new ImageViewImageDrawableTargetProxy(imageView);

        public static ValueAcceptorTargetProxy<int> BindDrawableId(this ImageView imageView) 
            => new ImageViewDrawableTargetProxy(imageView);

        public static ValueAcceptorTargetProxy<string> BindDrawableName(this ImageView imageView, Context context)
            => new ImageViewDrawableNameTargetProxy(imageView, context);

        public static ValueAcceptorTargetProxy<int> BindResourceName(this ImageView imageView) 
            => new ImageViewResourceNameTargetProxy(imageView);

        public static ValueAcceptorTargetProxy<string> BindAssetImagePath(this ImageView imageView, Context context)
            => new ImageViewImageTargetProxy(imageView, context);

        //public static string BindSelectedItem(this MvxSpinner mvxSpinner)
        //    => MvxAndroidPropertyBinding.MvxSpinner_SelectedItem;

        public static ValueAcceptorProviderTargetProxy<int> BindSelectedItemPosition(this AdapterView adapterView) 
            => new AdapterViewSelectedItemPositionTargetProxy(adapterView);

        //public static string BindSelectedItem(this MvxListView mvxListView)
        //    => MvxAndroidPropertyBinding.MvxListView_SelectedItem;

        //public static string BindSelectedItem(this MvxExpandableListView mvxExpandableListView)
        //    => MvxAndroidPropertyBinding.MvxExpandableListView_SelectedItem;

        public static ValueAcceptorProviderTargetProxy<float> BindRating(this RatingBar ratingBar) 
            => new RatingBarRatingTargetProxy(ratingBar);

        public static CommandTargetProxy BindLongClick(this View view) 
            => new ViewLongClickTargetProxy(view);

        //public static string BindSelectedItem(this MvxRadioGroup mvxRadioGroup)
        //    => MvxAndroidPropertyBinding.MvxRadioGroup_SelectedItem;

        public static ValueAcceptorProviderTargetProxy<string> BindTextFocus(this EditText editText) 
            => new TextViewFocusTargetProxy(editText);

        public static ValueAcceptorProviderTargetProxy<string> BindQuery(this SearchView searchView) 
            => new SearchViewQueryTextTargetProxy(searchView);

        public static PreferenceValueBaseTargetProxy<object> BindValue(this Preference preference) 
            => new PreferenceValueTargetProxy(preference);

        public static PreferenceValueBaseTargetProxy<string> BindText(this EditTextPreference editTextPreference) 
            => new EditTextPreferenceTextTargetProxy(editTextPreference);

        public static PreferenceValueBaseTargetProxy<string> BindValue(this ListPreference listPreference) 
            => new ListPreferenceTargetProxy(listPreference);

        public static PreferenceValueBaseTargetProxy<bool> BindChecked(this TwoStatePreference twoStatePreference) 
            => new TwoStatePreferenceCheckedTargetProxy(twoStatePreference);

        public static ValueAcceptorTargetProxy<IEnumerable<string>> BindDisplayedValues(this NumberPicker numberPicker) 
            => new NumberPickerDisplayedValuesTargetProxy(numberPicker);

        public static ValueAcceptorProviderTargetProxy<int> BindValue(this NumberPicker numberPicker)
            => new NumberPickerValueTargetProxy(numberPicker);

        public static ValueAcceptorTargetProxy<int> BindMargin(this View view)
            => new ViewMarginTargetProxy(view, Edges.All);

        public static ValueAcceptorTargetProxy<int> BindMarginLeft(this View view)
            => new ViewMarginTargetProxy(view, Edges.Left);

        public static ValueAcceptorTargetProxy<int> BindMarginRight(this View view)
            => new ViewMarginTargetProxy(view, Edges.Right);

        public static ValueAcceptorTargetProxy<int> BindMarginTop(this View view)
            => new ViewMarginTargetProxy(view, Edges.Top);

        public static ValueAcceptorTargetProxy<int> BindMarginBottom(this View view)
            => new ViewMarginTargetProxy(view, Edges.Bottom);

        public static ValueAcceptorTargetProxy<int> BindMarginStart(this View view)
            => new ViewMarginTargetProxy(view, Edges.Start);

        public static ValueAcceptorTargetProxy<int> BindMarginEnd(this View view)
            => new ViewMarginTargetProxy(view, Edges.End);

        public static ValueAcceptorTargetProxy<int> BindPadding(this View view) 
            => new ViewPaddingTargetProxy(view, Edges.All);

        public static ValueAcceptorTargetProxy<int> BindPaddingLeft(this View view)
            => new ViewPaddingTargetProxy(view, Edges.Left);

        public static ValueAcceptorTargetProxy<int> BindPaddingRight(this View view)
            => new ViewPaddingTargetProxy(view, Edges.Right);

        public static ValueAcceptorTargetProxy<int> BindPaddingTop(this View view)
            => new ViewPaddingTargetProxy(view, Edges.Top);

        public static ValueAcceptorTargetProxy<int> BindPaddingBottom(this View view)
            => new ViewPaddingTargetProxy(view, Edges.Bottom);

        public static ValueAcceptorTargetProxy<int> BindPaddingStart(this View view)
            => new ViewPaddingTargetProxy(view, Edges.Start);

        public static ValueAcceptorTargetProxy<int> BindPaddingEnd(this View view)
            => new ViewPaddingTargetProxy(view, Edges.End);

        public static CommandTargetProxy BindFocus(this View view) => new ViewFocusChangedTargetProxy(view);

        public static ValueAcceptorTargetProxy<string> BindVideoUri(this VideoView view) 
            => new VideoViewUriTargetProxy(view);

        public static ValueAcceptorTargetProxy<string> BindWebViewUri(this WebView view) 
            => new WebViewUriTargetProxy(view);

        public static ValueAcceptorTargetProxy<string> BindWebViewHtml(this WebView view) 
            => new WebViewHtmlTargetProxy(view);

        public static ValueAcceptorTargetProxy<string> BindToolbarSubtitle(Toolbar toolbar)
            => new ToolbarSubtitleProxy(toolbar);
    }
}
