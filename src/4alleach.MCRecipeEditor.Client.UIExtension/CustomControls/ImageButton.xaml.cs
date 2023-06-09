﻿using System.Windows;
using System.Windows.Media;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.CustomControls;

public partial class ImageButton : System.Windows.Controls.UserControl
{
    public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register(
                                                                                      nameof(ImageSource),
                                                                                      typeof(ImageSource),
                                                                                      typeof(ImageButton),
                                                                                      new FrameworkPropertyMetadata(
                                                                                          default(ImageSource),
                                                                                          FrameworkPropertyMetadataOptions.AffectsRender));

    public static readonly DependencyProperty ImageHeightProperty = DependencyProperty.Register(
                                                                                      nameof(ImageHeight),
                                                                                      typeof(double),
                                                                                      typeof(ImageButton),
                                                                                      new FrameworkPropertyMetadata(
                                                                                          0.0d,
                                                                                          FrameworkPropertyMetadataOptions.AffectsRender |
                                                                                          FrameworkPropertyMetadataOptions.AffectsMeasure));

    public static readonly DependencyProperty ImageWidthProperty = DependencyProperty.Register(
                                                                                      nameof(ImageWidth),
                                                                                      typeof(double),
                                                                                      typeof(ImageButton),
                                                                                      new FrameworkPropertyMetadata(
                                                                                          0.0d,
                                                                                          FrameworkPropertyMetadataOptions.AffectsRender |
                                                                                          FrameworkPropertyMetadataOptions.AffectsMeasure));

    public ImageSource ImageSource
    {
        get { return (ImageSource)GetValue(ImageSourceProperty); }
        set
        {
            SetValue(ImageSourceProperty, value);
        }
    }

    public double ImageHeight
    {
        get { return (double)GetValue(ImageHeightProperty); }
        set 
        { 
            SetValue(ImageHeightProperty, value);
        }
    }

    public double ImageWidth
    {
        get { return (double)GetValue(ImageWidthProperty); }
        set 
        { 
            SetValue(ImageWidthProperty, value);
        }
    }

    public ImageButton()
    {
        InitializeComponent();

        DataContext = this;
    }
}
