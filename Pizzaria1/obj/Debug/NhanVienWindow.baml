   M S B A M L   `   `   `  ����B  >wpfLKMT, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:wpfLKMTwpfLKMT  5   	       wpfLKMT.NhanVienWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:wpfLKMT     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      $	��700��5      $
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
���������6J   Z� ��6`   Z� .��5        $ Power=�62   5      5       5!      5"      � 5$   
   $��
250 55 0 0q�6   .+�5%      � -   5         �Name$ GridPrincipal��5%      $��Center=�6*   $��Center=�6G   5&      � 5(   
   $	��250��6   $
��Left=�6   ���	#FF222222.+�5)      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -   5          Name$ TrainsitionigContentSlide��5)   2   C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase	   OpeningEffect	 6U   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *SlideInFromLeft+
   Duration$
 0:0:0.2X�.��5*      � -   5        $ 
GridCursor��5*      $��	0 100 0 0q�6+   ���	#FF0069C0$��10��6U   $
��Left=�6`   $��60��6{   $	��Top=�6�   5+      �� 5,      $ Vertical=�6   .+�5/      �� -   5         ��Name$ ListViewMenu��5/      $��0 100q�61   
�������$��Champagne & Limousines)�6W   $��18(�6    �� SelectedIndex$ 0��6�   .@�50      �� $��60��6#   .��51      �� $ 
Horizontal=�6%   .+�52        $ Information=�66   $��30��6I   $��30��6T   $��Center=�6`   $��5q�6{   �� 53      $��Thông tin linh kiện��6(   $��17(�6C   $��Center=�6Q   $
��20 0q�6l   54      55      �� 56      $��60��6#   .��57      �� $ 
Horizontal=�6%   .+�58        $ 	UserGroup=�66   $��30��6G   $��30��6R   $��Center=�6^   $��5q�6y   �� 59      $��Thông tin khách hàng��6(   $��17(�6D   $��Center=�6R   $
��20 0q�6m   5:      5;      �� 5<      $��60��6#   .��5=      �� $ 
Horizontal=�6%   .+�5>        $ Receipt=�66   $��30��6E   $��30��6P   $��Center=�6\   $��5q�6w   �� 5?      $!��Phiếu xuất - Hóa đơn��6(   $��17(�6D   $��Center=�6R   $
��20 0q�6m   5@      5A      �� 5B      $��60��6#   .��5C      �� $ 
Horizontal=�6%   .+�5D        $ Account=�66   $��30��6E   $��30��6P   $��Center=�6\   $��5q�6w   �� 5E      $��Cập nhật tài khoản��6(   $��17(�6B   $��Center=�6P   $
��20 0q�6k   5F      5G      5H      5J      5K      5L      5M      