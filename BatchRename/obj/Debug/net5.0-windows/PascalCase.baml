   M S B A M L   `   `   `  ����F  BBatchRename, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:BatchRenameBatchRename  5   	       BatchRename.PascalCase   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:BatchRename     5   	     � Title$  
PascalCase��5   	    � SizeToContent$ WidthAndHeight=�6    � WindowStartupLocation$ CenterScreen=�5	   
   .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��/icon/question.png��6   $��32��6,   $��32��67   $��2��6C   $��10,15q�6T   �� 5   
   -   5        $��lblQuestion��5      $��1��6#   $
��10,0q�63   .��6A   
Seperator:6M   �� 5   
   -   5        $��	txtAnswer��5      $��1��6#   $��1��63   $	��200��6@   $
��10,0q�6O   6`   � 5   
   $��2��6   $��2��6!   $��Right=�65   $��
0,15,20,10q�6Q   .+�5      �� -   5        $��btnDialogOk��5   &    �� 	IsDefault$
 True��6   $��60��6S   $��0,0,10,0q�6a   .��6s   _Ok6x   �� 5      -   5         �� IsCancel$
 True��5      $��60��6%   .��6Q   	_Cancel6Z   5      5      5      