   M S B A M L   `   `   `  ����B  >wpfLKMT, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:wpfLKMTwpfLKMT  5   	       wpfLKMT.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:wpfLKMT     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $	��700��5      $
��1024��6'     � WindowStartupLocation$  CenterScreen=�64    � 
ResizeMode$ NoResize=�6Y    � WindowStyle$
 None=�6o   .��5	      � -   5        ���	#FFEEEEEE.+�5
   
   �� $	��Top=�6   .+�5      � ���	#FF0069C0$��10��6*   � 5      $��5q�6    � ColumnDefinitions 5      �� 5      $
��950* �6'   �� 5      $
��130* �6'   .+�5      �� $��0��6   $��Right=�6-    �� Orientation$ 
Horizontal=�6I   .+�5      �� $��
Xin chào ��6    $��20(�61   6B   �� 5      -   5        $��textNameUser��5       $��20(�64   ���	#FF0069C06[   �� 5      -   5        $��btnDangXuat��5   1   $��Đăng xuất��6   $��0q�6Z   
����d�$��5 0 0 0q�6�   ��6D   Z� 6�   5      �� 5      $ 
Horizontal=�6   $��Right=�66   $��0,0,10,0q�6R   $��1��6d   .+�5      �� $��30��6   $��30��6(   $��0q�6a   
���������64   Z� ��6J   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ BellOutline=�62   5      �� 5      $��30��6   $��30��6(   $��0q�6a   
�������$��0 0 10 0q�6   ��64   Z� ��6J   Z� .��5        $ Settings=�62   5      �� 5      -   5         ��Name$ ButtonFechar��5      $��30��63   $��30��6>   $��0q�6w   
���������6J   Z� ��6`   Z� .��5        $ Power=�62   5      5       5!      5"      � 5#   
   $��
250 55 0 0q�6   .+�5$      � -   5         �Name$ GridPrincipal��5$      $��Center=�6*   $��Center=�6G   5%      � 5&   
   $	��250��6   $
��Left=�6   ���	#FF222222.+�5'      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -   5          Name$ TrainsitionigContentSlide��5'   2   C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase	   OpeningEffect	 6U   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *SlideInFromLeft+
   Duration$
 0:0:0.2X�.��5(      � -   5        $ 
GridCursor��5(      $��	0 100 0 0q�6+   ���	#FF0069C0$��10��6U   $
��Left=�6`   $��60��6{   $	��Top=�6�   5)      �� 5*      $ Vertical=�6   .+�5+      �� -   5         ��Name$ ListViewMenu��5+      $��0 100q�61   
�������$��Champagne & Limousines)�6W   $��18(�6    �� SelectedIndex$ 0��6�   .@�5,      �� $��60��6#   .��5-      �� $ 
Horizontal=�6%   .+�5.        $
 Chip=�66   $��30��6B   $��30��6M   $��Center=�6Y   $��5q�6t   �� 5/      $��Loại linh kiện��6(   $��17(�6>   $��Center=�6L   $
��20 0q�6g   50      51      �� 52      $��60��6#   .��53      �� $ 
Horizontal=�6%   .+�54        $ Information=�66   $��30��6I   $��30��6T   $��Center=�6`   $��5q�6{   �� 55      $��Thông tin linh kiện��6(   $��17(�6C   $��Center=�6Q   $
��20 0q�6l   56      57      �� 58      $��60��6#   .��59      �� $ 
Horizontal=�6%   .+�5:        $ Factory=�66   $��30��6E   $��30��6P   $��Center=�6\   $��5q�6w   �� 5;      $��Nhà sản xuất��6(   $��17(�6<   $��Center=�6J   $
��20 0q�6e   5<      5=      �� 5>      $��60��6#   .��5?      �� $ 
Horizontal=�6%   .+�5@        $ AccountGroup=�66   $��30��6J   $��30��6U   $��Center=�6a   $��5q�6|   �� 5A      $��Nhân viên��6(   $��17(�69   $��Center=�6G   $
��20 0q�6b   5B      5C      �� 5D      $��60��6#   .��5E      �� $ 
Horizontal=�6%   .+�5F        $ ClipboardMultipleOutline=�66   $��30��6V   $��30��6a   $��Center=�6m   $��5q�6�   �� 5G      $��
Hóa đơn��6(   $��17(�67   $��Center=�6E   $
��20 0q�6`   5H      5I      �� 5J      $��60��6#   .��5K      �� $ 
Horizontal=�6%   .+�5L        $ Receipt=�66   $��30��6E   $��30��6P   $��Center=�6\   $��5q�6w   �� 5M      $��Phiếu xuất hàng hóa��6(   $��17(�6C   $��Center=�6Q   $
��20 0q�6l   5N      5O      5P      5Q      5R      5S      5T      