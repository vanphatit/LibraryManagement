   M S B A M L   `   `   `  ���� L  HLibraryManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:LibraryManagementLibraryManagement  #    LibraryManagement.LoginWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:LibraryManagement     c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  V RMaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -   $��loginWindow��  � WindowStyle$
  None=� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=�   LoginVM � DataContext# [   � Title$ Đăng nhập��$	��340��$	��700��.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ MouseLeftButtonDown��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *MoveWindowCommand+	   CommandParameter	 �� 
 �� ElementName$
 loginWindow��.���  � RowDefinitions �� �� $
��169* �.+���  �� RadiusY$ 8�� �� RadiusX$ 8��
�������$��2���� $!��ResourcesImage/welcome.jpeg��$��	338,0,0,0q�$��UniformToFill=�$��2���� $��2������  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#CC935E12�� � Offset$ 1Q�� $ 	#CCEA4646��� $ 	#CCB89128��$ 0.566Q��� $��	2,2,362,2q�$��2��
�������.+��� $�� Đăng nhập��$��Segoe UI Black)�$��24(�$��
10,10,0,10q�$	��Top=�$
��Left=�$	��146���� $J��DĐăng nhập để tiếp tục quản lý thư viện của bạn!��$��WrapWithOverflow=�$��50��$��16(�$��	25,0,39,0q���  �� Orientation$ 
Horizontal=�$��10,0,0,0q�.+�'  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=null]]   Kind$ Account=�$��Center=����#707070$��25��$��25���� )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên tài khoản��$��14(�$	��250��$��5q����� *
UserName+�� $ 
Horizontal=�$
��auto��$��10,0,0,0q�.+�  $	 Key=�$��Center=����#707070$��25��$��25��G� -    G�Name$ FloatingPasswordBox��$ Mật khẩu��$	��250��$��14(�$��5q�   $ PasswordChanged��.    �� *PasswordChangedCommand+	 �� $
 FloatingPasswordBox��� $��20���� $��Center=�$��ĐĂNG NHẬP��$��Segoe UI Black)�$��18(�$	��200�� �� 	IsDefault . $��40�����	#FF307CD6���	#FF307CD6���� *Dang_nhapCommand+���� $
 loginWindow��� $��83���� $��338,27,0,10q�$��1��.+��� $��Phần mềm��$��WrapWithOverflow=�
��� ���$��Center=�$��30(�$��Champagne & Limousines)�$
��Bold"�$��	21,0,10,0q�$	��331���� $,��&Quản lý thư viện trường học��$��WrapWithOverflow=�
�������$��Center=�$��38(�$��Champagne & Limousines)�$
��Bold"�$��	21,0,10,0q�$	��331���� $x��rGiờ đây, việc quản lý thư viện trường học của bạn trở nên dễ dàng hơn bao giờ hết.��
�������$��Center=�$
��auto��$��24(�$��Champagne & Limousines)�$
��Wrap=� �� TextAlignment$
 Left=�$��0 30 0 0q��� $��30���� $��16(�$��Right=�$	��209��
�������© Copyright by �� 
������� �� Command �� *FaceBookRequest+.�Lê Văn Phát�� $��Bottom=�$
��Left=�
������ $��0q�
������ 
������ $��40��$	��117��$��	-13,0,0,0q�$��1��.���� $
��Left=�$��30��$ 
Horizontal=�.+�  $ CloseCircleOutline=�
���   �$��30��$��30���� $��Thoát��
���   �$��18(�$��Center=��� $��Bottom=�$
��Left=�
������ $��0q�
������ 
������ $��40��$	��117��$��	-13,0,0,0q�$��1������ *ThoatCommand+���� $
 loginWindow��.���� $
��Left=�$��30��$ 
Horizontal=�.+�  $ CloseCircleOutline=�
���   �$��30��$��30���� $��Thoát��
���   �$��18(�$��Center=�