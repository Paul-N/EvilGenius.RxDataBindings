using EvilGenius.RxDataBindings.Converters;
using EvilGenius.RxDataBindings.Tests.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace EvilGenius.RxDataBindings.Tests.ValueConverters
{
    internal class EnumModelToStringConverter : ValueConverter<EnumModel, string>
    {
        //public static Dictionary<EnumModel, string> _modelToStringPairs => new Dictionary<EnumModel, string>
        //{
        //    { EnumModel.Zero, "val is 0" },
        //    { EnumModel.One, "val is 1" },
        //    { EnumModel.Two, "val is 2" },
        //    { EnumModel.Three, "val is 3" },
        //    { EnumModel.Four, "val is 4" },
        //};

        //public static KeyValuePair<EnumModel, string> GetDataKVP(int at) => _modelToStringPairs.ElementAt(at);

        //public static string EnumModelToString(EnumModel model) => _modelToStringPairs[model];

        //protected override string Convert(EnumModel value, Type targetType, object parameter, CultureInfo culture) => EnumModelToString(value);

        //protected override EnumModel ConvertBack(string value, Type targetType, object parameter, CultureInfo culture) 
        //    => _modelToStringPairs.SingleOrDefault(x => x.Value == value).Key;

        private static IEnumerable<(EnumModel enumModel, string str)> _modelToStringPairs => new (EnumModel enumModel, string str)[]
        {
            ( EnumModel.Zero, "val is 0" ),
            ( EnumModel.One, "val is 1" ),
            ( EnumModel.Two, "val is 2" ),
            ( EnumModel.Three, "val is 3" ),
            ( EnumModel.Four, "val is 4" ),
        };

        public static (EnumModel enumModel, string str) GetDataPair(int at) => _modelToStringPairs.ElementAt(at);

        public static string EnumModelToString(EnumModel model) => _modelToStringPairs.FirstOrDefault(x => x.enumModel == model).str;

        protected override string Convert(EnumModel value, Type targetType, object parameter, CultureInfo culture) => EnumModelToString(value);

        protected override EnumModel ConvertBack(string value, Type targetType, object parameter, CultureInfo culture)
            => _modelToStringPairs.SingleOrDefault(x => x.str == value).enumModel;
    }
}
