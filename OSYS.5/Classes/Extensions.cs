﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;
using System.Reflection;
using System.Windows.Threading;
using System.Windows.Controls.Theming;
using Microsoft.Expression.Shapes;
using OSYS.Classes;
using System.Diagnostics;

using System.Xml.Linq;
using System.Windows.Browser;

namespace OSYS.Classes
{
    public static class Extensions
    {
        public static IList<T> GetEnumValues<T>(this Type enumType)
        {
            if (enumType == null)
            {
                throw new ArgumentNullException("enumType");
            }
            if (!enumType.IsEnum)
            {
                throw new InvalidOperationException(string.Format("{0} should be a an EnumType", enumType.Name));
            }
            List<T> list = new List<T>();
            foreach (FieldInfo info in enumType.GetFields())
            {
                if (!info.IsSpecialName)
                {
                    T item = (T)info.GetValue(enumType);
                    if (!list.Contains(item))
                    {
                        list.Add(item);
                    }
                }
            }
            return list;
        }
    }

    public enum AvailableThemes
    {
        BureauBlack,
        BureauBlue,
        ExpressionDark,
        ExpressionLight,
        RainierOrange,
        RainierPurple,
        ShinyBlue,
        ShinyRed,
        WhistlerBlue,
        TwilightBlue,
        BubbleCreme,
        SystemColors
    }

    public static class ThemeFactory
    {

        static Theme _BureauBlack;
        // static Theme _BureauBlue;
        // static Theme _ExpressionDark;
        // static Theme _ExpressionLight;
        // static Theme _RainierOrange;
        // static Theme _RainierPurple;
        // static Theme _ShinyBlue;
        // static Theme _ShinyRed;
        // static Theme _WhistlerBlue;
        // static Theme _TwilightBlue;
        // static Theme _BubbleCreme;
        // static Theme _SystemColors;



        public static Theme GetTheme(AvailableThemes pickedTheme)
        {
            Theme theme = null;

            switch (pickedTheme)
            {
                case AvailableThemes.BureauBlack:
                    if (_BureauBlack == null) _BureauBlack = new BureauBlackTheme();
                    theme = _BureauBlack;
                    break;
                //case AvailableThemes.BureauBlue:
                //    if (_BureauBlue == null) _BureauBlue = new BureauBlueTheme();
                //    theme = _BureauBlue;
                //    break;
                //case AvailableThemes.ExpressionDark:
                //    if (_ExpressionDark == null) _ExpressionDark = new ExpressionDarkTheme();
                //    theme = _ExpressionDark;
                //    break;
                //case AvailableThemes.ExpressionLight:
                //    if (_ExpressionLight == null) _ExpressionLight = new ExpressionLightTheme();
                //    theme = _ExpressionLight;
                //    break;
                //case AvailableThemes.ShinyBlue:
                //    if (_ShinyBlue == null) _ShinyBlue = new ShinyBlueTheme();
                //    theme = _ShinyBlue;
                //    break;
                //case AvailableThemes.ShinyRed:
                //    if (_ShinyRed == null) _ShinyRed = new ShinyRedTheme();
                //    theme = _ShinyRed;
                //    break;
                //case AvailableThemes.WhistlerBlue:
                //    if (_WhistlerBlue == null) _WhistlerBlue = new WhistlerBlueTheme();
                //    theme = _WhistlerBlue;
                //    break;
                //case AvailableThemes.TwilightBlue:
                //    if (_TwilightBlue == null) _TwilightBlue = new TwilightBlueTheme();
                //    theme = _TwilightBlue;
                //    break;
                //case AvailableThemes.BubbleCreme:
                //    if (_BubbleCreme == null) _BubbleCreme = new BubbleCremeTheme();
                //    theme = _BubbleCreme;
                //    break;
                //case AvailableThemes.RainierOrange:
                //    if (_RainierOrange == null) _RainierOrange = new RainierOrangeTheme();
                //    theme = _RainierOrange;
                //    break;
                //case AvailableThemes.RainierPurple:
                //    if (_RainierPurple == null) _RainierPurple = new RainierPurpleTheme();
                //    theme = _RainierPurple;
                //    break;
                //case AvailableThemes.SystemColors:
                //    if (_SystemColors == null) _SystemColors = new SystemColorsTheme();
                //    theme = _SystemColors;
                //    break;
                default:
                    break;
            }
            return theme;
        }

        public static void ApplyTheme(FrameworkElement element, ResourceDictionary value)
        {
            element.Resources.MergedDictionaries.Clear();
            element.Resources.MergedDictionaries.Add(value);
        }
        public static void ApplyTheme(FrameworkElement element, Theme theme)
        {
            ApplyTheme(element, GetCurrentThemeResources(theme));
        }

        public static ResourceDictionary GetCurrentThemeResources(FrameworkElement element)
        {
            ResourceDictionary dictionary = element.Resources.MergedDictionaries.FirstOrDefault<ResourceDictionary>();
            ResourceDictionary dictionary2 = new ResourceDictionary();
            foreach (object obj2 in dictionary.Keys)
            {
                dictionary2.Add(obj2, dictionary[obj2]);
            }
            return dictionary2;
        }



    }
}
