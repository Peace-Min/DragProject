﻿using System.Windows;
using System.Windows.Media;

namespace ConvertLib
{
  public static class FindParentExtension
  {
    public static T FindParent<T>(this DependencyObject child)
     where T : DependencyObject
    {
      return FindParent<T>(child, null);
    }

    public static T FindParent<T>(this DependencyObject child, string parentName)
      where T : DependencyObject
    {
      DependencyObject parent = VisualTreeHelper.GetParent(child);
      if (parent == null)
      {
        return null;
      }

      FrameworkElement frameworkElement = (FrameworkElement)parent;
      if ((parentName == null || frameworkElement.Name == parentName) && frameworkElement is T)
      {
        return (T)parent;
      }
      else
      {
        return FindParent<T>(parent, parentName);
      }
    }
  }
}
