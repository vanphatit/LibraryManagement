   M S B A M L   `   `   `  ���� L  HLibraryManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:LibraryManagementLibraryManagement  W0clr-namespace:LibraryManagement.UserControlPteam"LibraryManagement.UserControlPteam  "    LibraryManagement.BorrowBook   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:LibraryManagement     V RMaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  A
controlbar0clr-namespace:LibraryManagement.UserControlPteam  c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  -   $��borrowbookWindow��  � WindowStyle$
  None=� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=�   BorrowBooksVM � DataContext# [   � Title$( "Danh sách các sách đã mượn��$	��450��$	��800��.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ Loaded��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *LoadWindowCommand+	   CommandParameter	 �� 
 �� ElementName$
 lsvMain��.���  � RowDefinitions �� $��50 ��� .+�5   /LibraryManagement.UserControlPteam.ControlBarPt  $��0��� $��1��$��5q� �� $��35 ��� $
��auto ��� $��50 ��� .+��� $��0��$��25(�$��Segoe UI)�$��Center=��� .�
Các sách �� .��� ���� *BorrowPerson+ �� .�đã mượn.� $��1�� �� �� .+�� $��0�� � ColumnDefinitions �� �� .+��� $��0��.+��� $��10���� $��16(�)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Tên sách��$��	10 0 10 0q�
���   � % !MaterialDesignFloatingHintTextBox#��[ ���� *
ObjectName+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=��� $��10���� $��16(�$ 
Tác giả��$��	10 0 10 0q�
���   �#��[ ���� *ObjectAuthor+$ PropertyChanged=�$ TwoWay=��� $��1��.+��� $��10���  �� �� .+��� $��0��$��16(�$ Số lượng��$��	10 0 10 0q�
���   �#��[ ���� *ObjectCount+$ PropertyChanged=�$ TwoWay=��� $��20���� $��1�� �� Orientation$ 
Horizontal=�$��Center=�.+���  / +MaterialDesignFloatingActionMiniLightButton#��[ ���	#FF086DD1
�������$��50��$��50�� � ToolTip$ Thêm tài khoản������ *ButtonAddCommand+.��'  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=null]]   Kind$
 Plus=�$��24��$��24���� $��10���� #��[ ���	#FF086DD1
�������$��50��$��50��$ Xoá tài khoản������ *ButtonDeleteCommand+.��  $ Delete=�$��24��$��24���� $��10���� #��[ ���	#FF086DD1
�������$��50��$��50��$ Sửa tài khoản������ *ButtonEditCommand+.��  $	 Pen=�$��24��$��24���� $��2��$ 
Horizontal=�.+�� $	��300�� �� $
��Auto ��� $��* �.+���   MaterialDesignToolButton#���  ���� *TxbSearchChangedCommand+���� $
 lsvMain��.��  $ Magnify=� J� Opacity$	 .56Q��� -   $��	txbSearch��$��1��$��8 0 0 0q�$' !Gõ từ cần tìm vào đây...��.	  (MaterialDesignThemes.Wpf.TextFieldAssist 	  DecorationVisibility$ Hidden=�$��0q�$��16(�$	��200��$��Center=����� *	txbSearch+�� $��10 0 0 0q� �� DisplayMemberPath$ Tname��$ Tìm theo...�� �� 
IsEditable . $��16(�$	��150������ *
ListSearch+ �� SelectedItem �� *SelectedSearch+$ TwoWay=�$ PropertyChanged=��� $��40��$��20(�$��	100 5 0 5q�
�������
��� � �
��� � ����� *ExportExcel10Command+���� $
 lsvMain��.��_Xuất excel� $��3��$��Stretch=�.+��� $
��Auto=�.���� -   $��lsvMain������ *ListBorrowBook+ �� *SelectedItem_BookBorrow+$ TwoWay=� �� View �� .P��� $��
Tên sách�� �� DisplayMemberBinding �� *Object.DisplayName+�� $��
Tác giả�� �� *Object.Author+�� $��Số lượng�� �� *Count+