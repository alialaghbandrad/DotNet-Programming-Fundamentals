   M S B A M L   `   `   `  ����N  JDay09TodoWithDialog, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Day09TodoWithDialogDay09TodoWithDialog  5   	   $    Day09TodoWithDialog.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Day09TodoWithDialog     5   	   -   5          � Title$  
MainWindow��5   	   $	��400��6    � SizeToContent$ Width=�6*    � 	Resources 5	       �� 
TargetType �� Property �� Value��%�   'm�       �� 5
   
   " m�6   .�5      ��  � ��$ 16(�6)   �� 5       � ��$ Times New Roman)�6+   5      5      .��5      ]� .+�5   
   o� $	��Top=�6   
�������.@�5      m� -   5        $��miFile��5      $
��File��6'   .@�5      m� -   5        $��miSaveSelected��5   5   $��Save selected Todos...��6K   �� 5      m� 5      -   5        $��miExit��5   -   $
��Exit��6;   5      m� 5      -   5        $��miEdit��5      $
��Edit��6%   .@�5      m� -   5        $��miAdd��5   0   $��Add Todo��6=   m� 5      -   5        $��miUpdate��5   3   $��	Edit Todo��6C   5      5      �� 5   
   $��Bottom=�6   
�������.@�5      �� -   5        $��	lblStatus��5      $��Data is loaded from file��6%   
�������6H   5      �� 5    
   -	   5        $��lvTodos��5    6    � ContextMenu 5!      �� 5"      .@�5#      m� -
   5        $��	Edit Todo��5#   7   �� 5$      m� 5%      -   5        $��Delete Todo��5%   7   5&       �� View 5(      �� 5)      .P�5*      �� $
��Task��6%    �� Width$	 200��63   	 �� DisplayMemberBinding	 6?   �� *Task+�� 5+      $��
Difficulty��6%   $
 Auto��69   	 6G   �� *
Difficulty+�� 5,      $��Due Date��6%   $	 100��67   	 6D   �� *DueDateCurrentCulture+�� 5-      $��Status��6%   $	 100��65   	 6B   �� *
TaskStatus+5.      50      51      52      