   M S B A M L   `   `   `  ���� F  BBatchRename, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:BatchRenameBatchRename      BatchRename.MainWindow   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:BatchRename       � Title$  
MainWindow��$	��450��$	��800��.���  � RowDefinitions �� $��* � � ColumnDefinitions �� $	��275 ��� $��* �.+�� $��0��$��1�� �� $
��Auto ��� $
��Auto ��� �� .+�`� -   $��methodToolBarTray�� `� IsLocked$
 True��$��1��.�c� .@��� -   $��clearMethodMenuButton��.����  �� Orientation$ 
Horizontal=�.+��� $��/icon/clear.png��$��16��$��16���� $��5,0,0,0q�$��12(�Clear�� -   $��methodMenuTopButton��.���� $��/icon/top-arrow.png��$��16��$��16���� -   $��methodMenuUpButton��.���� $��/icon/up-arrow.png��$��16��$��16���� -   $��methodMenuDownButton��.���� $��/icon/down-arrow.png��$��16��$��16���� -   $��methodMenuBotButton��.���� $��/icon/bottom-arrow.png��$��16��$��16��`� $
 True��$��0��.�c� .@��� -   .���� $ 
Horizontal=�.+��� $��/icon/upload.png��$��16��$��16���� $��5,0,10,0q�$��12(�	Up preset�� -   .���� $ 
Horizontal=�.+��� $��/icon/download.png��$��16��$��16���� $��5,0,0,0q�$��12(�Save preset�� -	   $��lv_methodSelected��$��2�� J� 	AllowDrop$
 True��$��5,0,5,0q�$��Stretch=�$��Stretch=����� .R�� $��10,0,0,0q�.+��� $��LeftToRight=�$	��200��$��16(����� *Rule.RuleName+�� $��16��$��16��$��/icon/sub.png���� -
   $��	lv_method��$��3��$
 True��$��5,0,5,0q�$��Stretch=�$��Stretch=����� .R�� $��10,0,0,0q�.+��� $��LeftToRight=�$	��200��$��16(����� *
RuleName+�� $��16��$��16��$��/icon/plus.png���� -   $	��Tab��$��1��$��1��.@��� -   $
 True��$��Change Files��.���  �� $
��Auto ��� .+�`� $
 True��$��0��$��2��.�c� .@��� -   .���� $ 
Horizontal=�.+��� $��16��$��16��$��/icon/add_file.png��$��10,0,2,0q��� $	��Add��$��12(��� -   $��clearFileButton��.���� $ 
Horizontal=�.+��� $��/icon/clear.png��$��16��$��16��$��10,0,2,0q��� $��5,0,0,0q�$��12(�Clear�� -   .���� $ 
Horizontal=�.+��� $��16��$��16��$��/icon/play.png��$��10,0,2,0q��� $��Change��$��12(��� $
��Auto=�$
��Auto=�$
��True��$��1��$��2��.���� -   $��lv_files�� �� View �� .P��� $��Filename�� �� Width$	 100�� �� CellTemplate �� .R��� ���� *Name+�� $��New filename��$	 100�� �� .R��� ���� *	NewName+�� $
��Path��$ 80�� �� .R��� ���� *
FullPath+�� $��Error��$	 100�� �� .R��� ���� *Error+