   M S B A M L   `   `   `  ����B  >wpfLKMT, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:wpfLKMTwpfLKMT  5   	       wpfLKMT.LoginForm   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:wpfLKMT     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Login��5	      $	��400��6   $	��600��6#    � 
ResizeMode$ NoResize=�6/    � WindowStyle$
 None=�6E    � AllowsTransparency . 
������  � WindowStartupLocation$ CenterScreen=�6�   .��5
      � -   5         �Name$ 	gridLogin��5
      .+�5   
   ��  �� RadiusY$ 8��6    �� RadiusX$ 8��6    
�������6,   �� 5   
   $��Assets\pc.jpg��6   $��	310,0,0,0q�6'   $��UniformToFill=�6:   �� 5   
   $��	310,0,0,0q�6   ��5      �� 5       �� EndPoint$ 0.5,1&�6&   	 �� 
StartPoint$	 0.5,0&�67   .��5      � 
 � Color$
 	#FF0069C0��6#    � Offset$ 1Q�65   � 5      $
 	#CCEA4646��6#   � 5      $
 	#CCB89128��6#   $ 0.566Q�65   5      5      �� 5   
   $��Right=�6   .+�5      �� -   5         ��Name$ btnClose��5      $��30��6'   $��30��62   $��0q�6k   
���������6>   Z� ��6T   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Power=�6*   
���   �67   5      5      �� 5   
   $��20,10,290,10q�6   .+�5      �� $��Đăng nhập��6   $��Segoe UI Black)�6(   $��24(�6D   $
��0,10q�6R   $	��Top=�6`   $
��Left=�6x     5      $ 
AccountBox=�6&   $��Center=�68   $	��100��6S   $	��100��6_   $��Center=�6l   $
��75 0q�6�   �� 5      $
��0,15q�6    �� Orientation$ 
Horizontal=�6'   .+�5        $ Account=�6*   $��Center=�69   ���#7070706T   �� 5       -   5        $��txtTaiKhoan��5    [   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ username��6   $	��250��6D   $��5q�6P   6[   5!      �� 5"      $ 
Horizontal=�6   .+�5#        $	 Key=�6*   $��Center=�65   ���#7070706P   G� 5$      -   5        $��
txtMatKhau��5$   a   $ 
**********��6   $	��250��6J   $��5q�6V   6a   5%      �� 5&      -   5        $��Center=�5&      $��LOGIN��62   $��Impact)�6B   $��18(�6V   $	��100��6d   $
��0 10q�6p   ���	#FF307CD6$��0q�6�   5'      �� 5(   
   $��310,50,0,50q�6   .+�5)      �� $��TechShop��6   
�������$��Center=�6;   $��48(�6X   $��Champagne & Limousines)�6f   $
��Bold"�6�   �� 5*      $��Work, eat, repeat��6   $��Italic$�61   
�������$��Center=�6W   $	��280��6t   $��24(�6�   $��Champagne & Limousines)�6�   $
��Wrap=�6�    �� TextAlignment$ Center=�6�   $��0,50,0,0q�6�   5+      5,      5-      