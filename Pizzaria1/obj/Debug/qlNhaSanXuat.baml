   M S B A M L   `   `   `  ����B  >wpfLKMT, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:wpfLKMTwpfLKMT  5          wpfLKMT.qlNhaSanXuat   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:wpfLKMT     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      $
��auto��5	      $	��700��6   .��5
      � .+�5   
   ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -   5           Name$  TrainsitionigContentSlide��5   .   C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 6Q   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *SlideInFromLeft+   Duration$ 0:0:0.8X�.��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $ Vertical=�6   $	��309��64   .+�5      �� $��Tìm kiếm��6   $��0 0 0 10q�61   .  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$
 Dark=�6C   .��5      �� -   5        $��txtSearchNSX��5   "   .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton . )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Mã nhà sản xuất��6l    %  !MaterialDesignFloatingHintTextBox#��[  6�   $��Center=�6�   6�   5      �� 5      $"��Thông tin nhà sản xuất��6   $
 Dark=�6?   $	��303��6j   .��5      �� $ Vertical=�6%   $	��264��6<   .+�5      � $
��0 30q�6#    � ColumnDefinitions 5   "   �� 5   &   $	��56* �67   �� 5   &   $	��51* �67   �� 5   &   $	��16* �67   �� 5   &   $
��131* �67   �� 5   &   $	��30* �67    � RowDefinitions 5   "   �� 5   &   $��30 �64   �� 5   &   $��10 �64   �� 5   &   $��30 �64   �� 5   &   $��10 �64   �� 5    &   $��30 �64   .+�5"   "   �� $��0��6,   $��0��6<   $��Mã nhà sản xuất��6I   $��Center=�6a   $��Center=�6|   $��2��6�   �� 5#   "   $��0��6,   $��2��6<   $��Tên nhà sản xuất��6I   $��Center=�6a   $��Center=�6|   $��2��6�   �� 5$   "   $��0��6,   $��4��6<   $��Trạng thái��6I   $��Center=�6[   $��Center=�6v   $��2��6�   �� 5'   "   -   5        $��txtMaNSX��5'   G   $��3��6*   $��0��6:   6G   �� 5(   "   -   5        $��	txtTenNSX��5(   G   $��3��6*   $��2��6:   6G   �� 5)   "   -   5        $��checkActive��5)   Z   $��Active?��6+   $��3��6=   $��4��6M   6Z   5+      �� 5,      $ 
Horizontal=�6)   $
��0 30q�6B   $	��250��6P   .+�5-   "   �� -   5        $��
btnThemNSX��5-   P   $��75��6*   $��30��65   $��Thêm��6A   
�������$��0q�6t   6�   �� 5.   "   -   5        $��	btnSuaNSX��5.   [   $��75��6*   $��30��65   $��10q�6A   $��Sửa��6M   
�������$��0q�6   6�   �� 5/   "   -   5        $��	btnLamMoi��5/   b   $��80��6*   $��30��65   $��
Làm mới��6A   $��12(�6T   
�������$��0q�6�   6�   50      52      53      54      &   System.Windows.Controls.DataGrid  55      -	   5        $��dgNhaSanXuat��55      	   AutoGenerateColumns	 .  
 �� SelectedValuePath$
 MaNhaSX��6K   $	��405��6g   $
��10 0q�6u   $	��381��6�      
IsReadOnly .  J� Effect 56      3  -System.Windows.Media.Effects.DropShadowEffect  57         
BlurRadius$ 20Q�6+      Color$ 	#FFDEDEDE��6;      ShadowDepth$ 1Q�6M      Columns 59      0	  *System.Windows.Controls.DataGridTextColumn	  5:      ,
  &System.Windows.Controls.DataGridColumn 
  Header$ Mã Nhà sản xuất��6-    
  Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6b   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6F   �� *	MaNhaSX+6b   	  5;      $ Tên nhà sản xuất��6-   $	 170 6e    6G   �� *
TenNhaSX+6e   4  .System.Windows.Controls.DataGridTemplateColumn  5<         CellTemplate 5=      �� 5>   "   .R�5?   &   �� $��btnXoa��6;   -
   5        $
��Xóa��5?   -   6I   5@   #   5B      5D      5E      5F      5G      5H      