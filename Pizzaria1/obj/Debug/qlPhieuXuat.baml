   M S B A M L   `   `   `  ����B  >wpfLKMT, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:wpfLKMTwpfLKMT  5          wpfLKMT.qlPhieuXuat   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:wpfLKMT     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      $	��600��5	   "   .��5      � .+�5   
   ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -   5           Name$  TrainsitionigContentSlide��5   .   C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 6Q   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *SlideInFromLeft+   Duration$ 0:0:0.8X�.��5      ��  �� Orientation$ Vertical=�6   .+�5      �� $ 
Horizontal=�6   $	��294��66   .+�5      �� $ Vertical=�6!   .+�5      �� $��Thông tin phiếu xuất��6#   .  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$
 Dark=�6A   $	��246��6l   $	��256��6x   .��5      �  � ColumnDefinitions 5   "   �� 5   &   $
��104* �67   �� 5   &   $��21 �67   �� 5   &   $
��103* �67    � RowDefinitions 5   "   �� 5   &   �� 5   &   �� 5   &   �� 5   &   .+�5   "   �� $��0��6,   $��0��6<   $��Mã phiếu xuất��6I   $��Center=�6^   �� 5   "   $��0��6,   $��1��6<   $��Ngày xuất��6I   $��Center=�6Z   �� 5   "   $��0��6,   $��2��6<   $��Mã khách hàng��6I   $��Center=�6^   �� 5    "   $��0��6,   $��3��6<   $��Mã nhân viên��6I   $��Center=�6]   �� 5"   "   -   5        $��txtSoPX��5"   G   $��2��6*   $��0��6:   $��Center=�6V    �� 
IsReadOnly . 6q   (  "System.Windows.Controls.DatePicker  5#   "   -   5        $��
dpNgayXuat��5#   J   $��2��6-   $��1��6=   $��Center=�6\   �� 5$   "   -   5        $��cboMaKH��5$   H   $��2��6+   $��2��6;   $��Center=�6W    �� DisplayMemberPath$
 MaKH��6r   	 �� 
IsEditable	 . 6�   �� 5%   "   -   5        $��txtMaNV��5%   Y   $��2��6*   $��3��6:    . $��Center=�6h   5'      5(      �� 5)      $ 
Horizontal=�6%   .+�5*      �� -   5        $��btnTaoPX��5*   >   $��Tạo phiếu xuất��6%   
�������$��0q�6w   $	��5 5q�6�   $��30��6�   $	��114��6�   $��11(�6�   6�   �� 5+      -   5        $��btnLapHD��5+   ;   $��Lập hóa đơn��6%   
�������$��0q�6t   $��15 0 0 0q�6�   $��30��6�   $	��105��6�   $��11(�6�   {�.  6�   5,      5-      �� 5.      $
��10,0q�6!   $	��445��6/   .+�5/      �� $��Tìm kiếm��6#   $
 Dark=�65   .��50      �� -   5        $��	txtSearch��50   �   .  (MaterialDesignThemes.Wpf.TextFieldAssist
   HasClearButton
 . )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Mã phiếu xuất��6[    %  !MaterialDesignFloatingHintTextBox#��[  6�   $��Center=�6�   6�   51      �� 52      $��Danh sách phiếu xuất��6#   $
 Dark=�6A   $	��0,5q�6l   $	��200��6y   .��53      &   System.Windows.Controls.DataGrid  -	   5          Name$ dgDSPhieuXuat��53   '      AutoGenerateColumns .  $��	0,-6,0,-7q�6Z   $	��430��6m   $	��160��6y      
IsReadOnly .    Columns 54   "   0	  *System.Windows.Controls.DataGridTextColumn	  55   &   ,
  &System.Windows.Controls.DataGridColumn 
  Header$ Mã phiếu xuất��69   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6P   �� *MaPX+	  56   &   $ Mã khách hàng��69    6Q   �� *MaKH+	  57   &   $ Ngày xuất��69    
  Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6�    6L   �� *
NgayXuat+ �� StringFormat$ {0:dd/MM/yyyy}��6�   4  .System.Windows.Controls.DataGridTemplateColumn  58   &      CellTemplate 59   *   �� 5:   .   .R�5;   2   �� $��btnHuy��6G   -
   5        $��Hủy��5;   9   6U   5<   /   5>   '   5A      5B      5C      5D      �� 5E      .+�5F      �� $��Chi tiết phiếu xuất��6   $
 Dark=�6<   $	��293��6g   $��0,10,0,0q�6t   .��5G      �� $��0,0,0,-9q�6%   .+�5H      �  5I   "   �� 5J   &   �� 5K   &   $��2* �67   �� 5L   &   �� 5M   &   �� 5N   &    5P   "   �� 5Q   &   �� 5R   &   .+�5T   "   �� $��0��6,   $��0��69   $��Mã linh kiện��6I   �� 5U   "   $��0��6,   $��1��69   $��Tên linh kiện��6I   $
��10 0q�6^   �� 5V   "   $��0��6,   $��2��69   $��
Đơn giá��6I   $
��10 0q�6X   �� 5W   "   $��0��6,   $��3��69   $��Số lượng��6I   $
��10 0q�6Y   �� 5X   "   -   5        $��btnChon��5X   Z   $��1��6)   $��4��66   $��Chọn hàng��6F   $��10,5,0,5q�6   $
��Auto��6�   �� 5Y   "   -   5        $��	cmbMahang��5Y   H   $��1��6+   $��0��68   $��28��6Y   $��0,4,0,0q�6e   $
 MaLK��6v   $��Center=�6�   	 . 6�   �� 5Z   "   $��1��6*   $��1��67    . $
��10 0q�6Y   $��Center=�6�   ��6g   ��  �� ElementName$ 	cmbMahang�� �� Path$ SelectedItem.TenLK�6�   �� 5[   "   $��1��6*   $��2��67    . $
��10 0q�6Y   $��Center=�6�   ��6g   �� $ 	cmbMahang��$ SelectedItem.GiaBan�$ {0:C}�� �� ConverterCulture$ vi-VN��6�   �� 5\   "   -   5        $��
txtSoluong��5\   G   $��1��6*   $��3��67   $
��10 0q�6Y   $��Center=�6g   5]        5^      -   5        $��	dgChitiet��5^   '    .  $
��0 10q�6T   $	��156��6b   $	��685��6o    �� SelectedValuePath$
 MaLK��6|    5_   "   	  5`   &   $ Mã linh kiện��69    6O   �� *MaLK+ �� Mode$ OneWay=�	  5a   &   $ Tên linh kiện��69    6P   �� *TenLK+$ OneWay=�	  5b   &   $ 
Đơn giá��69    6J   �� *DonGia+$ OneWay=�$ {0:C}��$ vi-VN��	  5c   &   $ Số lượng��69    6K   �� *	SoLuong+$ OneWay=�	  5d   &   $ Thành tiền��69    6M   �� *	thanhtien+$ OneWay=�$ {0:C}��$ vi-VN��  5e   &    5f   *   �� 5g   .   .R�5h   2   �� $��btnXoa��6G   -   5        $
��Xóa��5h   9   6U   5i   /   5k   '   5m      � 5n       5o   "   �� 5p   &   �� 5q   &   �� 5r   &   �� 5s   &   �� 5t   &    5v   "   �� 5w   &   .+�5y   "   �� $��0��6,   $��3��69   $��Tổng tiền��6I   �� 5z   "   -   5        $��txtThanhtien��5z   G   $��0��6*   $��4��67    . $	��0đ��6m   5{      5|      5}      5~      5      5�      5�      5�      