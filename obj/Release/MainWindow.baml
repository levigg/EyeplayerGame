   M S B A M L   `   `   `  ���� H  DEyePlayerGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:EyePlayerGameEyePlayerGame      EyePlayerGame.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -localclr-namespace:EyePlayerGame     -     � Title$  
MainWindow��$
��1080��$
��1920�� � WindowState$ 	Maximized=� � WindowStyle$
 None=� � AllowsTransparency . 
������  � Topmost .  � 	Resources    expandStoryboard �� TargetProperty	 W� To g� Duration  shrinkStoryboard��%  &	        &	 |     �� .��W� $ RenderTransform.ScaleX�$	 0.9X�$ 0:0:0.2D�W� $ RenderTransform.ScaleY�$	 0.9X�$ 0:0:0.2D��� .��W� $ RenderTransform.ScaleX�$ 1X�$ 0:0:0.2D�W� $ RenderTransform.ScaleY�$ 1X�$ 0:0:0.2D�.��� 	 � RowDefinitions	 �� $��0.48* ��� $��4* ��� $
��0.4* �.+��� $��0��
����� �._��� $��EyePlayer Games��$��Center=�$��Center=�
�������$��35(�$��Segoe UI Emoji)��� $��2��
����� �._��� $�� ��$��Center=�$��Center=�
�������$��20(��� -   $��
avoidClick��$��1��
������ � -   $��GameList��$��1��
������
 � ColumnDefinitions
 �� $��1* ��� $��1* ��� $��1* ��� $��1* �	 �� $��1* ��� $��1* ��� $��1* ��� $��1* �.+��� -   $��media/01.png��$��0��$��0��$
��Fill=� � Cursor$
 Hand�� J� RenderTransformOrigin$ 0.5,0.5&� � Triggers :�  :� RoutedEvent$ Image.MouseEnter��.[��� #��[  :� $ Image.MouseLeave��.[��� #��[ z���  �� ScaleX$ 1Q� �� ScaleY$ 1Q��� -   $��media/02.png��$��1��$��0��$
��Fill=�$
 Hand��$ 0.5,0.5&� :� $ Image.MouseEnter��.[��� #��[  :� $ Image.MouseLeave��.[��� #��[ z��� $ 1Q�$ 1Q��� -   $��media/03.png��$��2��$��0��$
��Fill=�$
 Hand��$ 0.5,0.5&� :� $ Image.MouseEnter��.[��� #��[  :� $ Image.MouseLeave��.[��� #��[ z��� $ 1Q�$ 1Q��� -   $��media/04.png��$��3��$��0��$
��Fill=�$
 Hand��$ 0.5,0.5&� :� $ Image.MouseEnter��.[��� #��[  :� $ Image.MouseLeave��.[��� #��[ z��� $ 1Q�$ 1Q��� -   $��media/05.png��$��0��$��1��$
��Fill=�$
 Hand��$ 0.5,0.5&� :� $ Image.MouseEnter��.[��� #��[  :� $ Image.MouseLeave��.[��� #��[ z��� $ 1Q�$ 1Q��� -	   $��media/14.jpg��$��1��$��1��$
��Fill=�$
 Hand��$ 0.5,0.5&� :� $ Image.MouseEnter��.[��� #��[  :� $ Image.MouseLeave��.[��� #��[ z��� $ 1Q�$ 1Q��� -
   $��media/07.png��$��2��$��1��$
��Fill=�$
 Hand��$ 0.5,0.5&� :� $ Image.MouseEnter��.[��� #��[  :� $ Image.MouseLeave��.[��� #��[ z��� $ 1Q�$ 1Q��� -   $��media/08.png��$��3��$��1��$
��Fill=�$
 Hand��$ 0.5,0.5&� :� $ Image.MouseEnter��.[��� #��[  :� $ Image.MouseLeave��.[��� #��[ z��� $ 1Q�$ 1Q��� -   $��media/09.png��$��0��$��2��$
��Fill=�$
 Hand��$ 0.5,0.5&� :� $ Image.MouseEnter��.[��� #��[  :� $ Image.MouseLeave��.[��� #��[ z��� $ 1Q�$ 1Q��� -   $��media/10.png��$��1��$��2��$
��Fill=�$
 Hand��$ 0.5,0.5&� :� $ Image.MouseEnter��.[��� #��[  :� $ Image.MouseLeave��.[��� #��[ z��� $ 1Q�$ 1Q��� -   $��media/11.png��$��2��$��2��$
��Fill=�$
 Hand��$ 0.5,0.5&� :� $ Image.MouseEnter��.[��� #��[  :� $ Image.MouseLeave��.[��� #��[ z��� $ 1Q�$ 1Q��� -   $��media/12.png��$��3��$��2��$
��Fill=�$
 Hand��$ 0.5,0.5&� :� $ Image.MouseEnter��.[��� #��[  :� $ Image.MouseLeave��.[��� #��[ z��� $ 1Q�$ 1Q��� -   $��media/13.png��$��0��$��3��$
��Fill=�$
 Hand��$ 0.5,0.5&� :� $ Image.MouseEnter��.[��� #��[  :� $ Image.MouseLeave��.[��� #��[ z��� $ 1Q�$ 1Q��� -   $��media/06.png��$��1��$��3��$
��Fill=�$
 Hand��$ 0.5,0.5&� :� $ Image.MouseEnter��.[��� #��[  :� $ Image.MouseLeave��.[��� #��[ z��� $ 1Q�$ 1Q��� -   $��media/15.png��$��2��$��3��$
��Fill=�$
 Hand��$ 0.5,0.5&� :� $ Image.MouseEnter��.[��� #��[  :� $ Image.MouseLeave��.[��� #��[ z��� $ 1Q�$ 1Q��� -   $��media/16.png��$��3��$��3��$
��Fill=�$
 Hand��$ 0.5,0.5&� :� $ Image.MouseEnter��.[��� #��[  :� $ Image.MouseLeave��.[��� #��[ z��� $ 1Q�$ 1Q�