   M S B A M L   `   `   `  ����B  >wpfLKMT, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:wpfLKMTwpfLKMT  5          wpfLKMT.qlLinhKien   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:wpfLKMT     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5        $
��auto��5	      $	��700��6   .��5
      � .+�5   
   ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -   5           Name$  TrainsitionigContentSlide��5   .   C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 6Q   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *SlideInFromLeft+   Duration$ 0:0:0.8X�.��5      ��  �� Orientation$ Vertical=�6   .+�5      � $	��300��6   .+�5      �� $��Thông tin linh kiện��6   $
��Left=�6<   $��Bottom=�6W   $	��572��6r   $	��205��6~   .  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$
 Dark=�6�   .��5      �� $ 
Horizontal=�6%   .+�5      � $	��250��6#    � ColumnDefinitions 5   "   �� 5   &   $��7* �67   �� 5   &   �� 5   &   $	��10* �67    � RowDefinitions 5   "   �� 5   &   �� 5   &   �� 5   &   .+�5    "   �� $��Mã linh kiện��6,   $��0��6@   $��0��6P   $��Center=�6]   �� 5!   "   $��Tên linh kiện��6,   $��0��6A   $��1��6Q   $��Center=�6^   �� 5"   "   $��
Mã loại��6,   $��0��6;   $��2��6K   $��Center=�6X   �� 5#   "   -   5        $��txtMaLinhKien��5#   *   $��2��6?   $��0��6O   $��Center=�6\    �� 
IsReadOnly . 6w   �� 5$   "   -   5        $��txtTenLinhKien��5$   *   $��2��6@   $��1��6P   $��Center=�6]   �� 5%   "   -   5        $��	cmbMaLoai��5%   +    �� DisplayMemberPath$ MaLoai��6<   	 �� SelectedValuePath$	 MaLoai��6W   
 �� 
IsEditable
 . $��2��6�   $��2��6�   $��Center=�6�   5&      � 5'      $	��250��6#   $
��20 0q�6/    5(   "   �� 5)   &   $��7* �67   �� 5*   &   �� 5+   &   $	��10* �67    5-   "   �� 5.   &   �� 5/   &   �� 50   &   .+�52   "   �� $��	Giá bán��6,   $��0��6;   $��0��6K   $��Center=�6X   �� 53   "   -   5        $��	txtGiaBan��53   *   $��2��6<   $��0��6L   $��Center=�6Y   �� 54   "   $��Hãng sản xuất��6,   $��0��6A   $��3��6Q   $��Center=�6^   �� 55   "   $��Trạng thái��6,   $��0��6>   $��1��6N   $��Center=�6[   �� 56   "   -   5        $��checkActive��56   +   $��Active?��6>   $��2��6P   $��1��6`   $��Center=�6m    d� 	IsChecked$
 TrueY�6�   �� 57   "   -   5        $��cmbHSX��57   +   $ MaNhaSX��6:   $	 MaNhaSX��6V   
 . $��2��6�   $��3��6�   $��Center=�6�   58      59      5:      �� 5;      $	��572��6   $��Tìm kiếm��6+   $
��Left=�6=   $	��Top=�6X   $
 Dark=�6p   $��90��6�   .��5<      �� -	   5        $��txtTimKiemMaLK��5<   #   .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton . )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Mã linh kiện��6o    %  !MaterialDesignFloatingHintTextBox#��[  6�   $��Center=�6�   6�   5=      �� 5>      $ 
Horizontal=�6!   $��Right=�6:   $��Bottom=�6V   $	��152��6q   $��58��6}   .+�5?      �� 5@      �� 5A      $ Vertical=�6!   $��Right=�68   $	��128��6T   $	��200��6`   $��	0,90,0,10q�6m   .+�5B      �� -
   5        $��btnThem��5B   0   $��Thêm��6!   
�������$��0q�6h   $��22,70,17,13q�6|   �� 5C      -   5        $��btnSua��5C   /   $��Sửa��6!   $��
22,0,17,13q�6R   
�������$��0q�6x   �� 5D      -   5        $��	btnLamMoi��5D   3   $��
Làm mới��6!   $��
22,0,17,13q�6\   
�������$��0q�6�   5F      5G      �� 5H      $	��200��6   $
��0 10q�6*   .+�5I      &   System.Windows.Controls.DataGrid  -   5        $��dgDanhSachLK��5I         AutoGenerateColumns .  $	��200��6O   $
	 MaLK��6�      
IsReadOnly . $��	0,0,127,0q�6�    J� Effect 5J      3  -System.Windows.Media.Effects.DropShadowEffect  5K         
BlurRadius$ 20Q�6/      Color$ 	#FFDEDEDE��6?      ShadowDepth$ 1Q�6Q      Columns 5M      0	  *System.Windows.Controls.DataGridTextColumn	  5N      ,
  &System.Windows.Controls.DataGridColumn 
  Header$ Mã linh kiện��61    
  Width5  /System.Windows.Controls.DataGridLengthConverter$	 105 6`   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6G   �� *MaLK+6`   	  5O      $ Tên linh kiện��61   $	 130 6b    6H   �� *TenLK+6b   	  5P      $ 
Mã loại��61   $ 80 6]    6B   �� *MaLoai+6]   	  5Q      $ 	Giá bán��61   $	 120 6�    6B   �� *GiaBan+ �� StringFormat$ {0:C}�� �� ConverterCulture$ vi-VN��6�   4  .System.Windows.Controls.DataGridTemplateColumn  5R         CellTemplate 5S   "   �� 5T   &   .R�5U   *   �� $��btnXoa��6?   -   5        $
��Xóa��5U   1   6M   5V   '   5X      5Z      5[      5\      5]      5^      5_      