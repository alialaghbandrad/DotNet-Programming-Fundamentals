   M S B A M L   `   `   `  ����I  EDay11TodoEFAli, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Day11TodoEFAliDay11TodoEFAli  5   	   "    Day11TodoEFAli.AddEditDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Day11TodoEFAli     5   	     � 
ResizeMode$  NoResize=�5       � Title$ AddEditDialog��5   	   $	��450��6   $	��800��6,   .��5	      � ���#232F3E � ColumnDefinitions 5
   
   �� 5      $
��0.6* �6   �� 5      $
��0.2* �6   �� 5      $
��1.8* �6    � RowDefinitions 5   
   �� 5      $
��0.6* �6   �� 5      $
��0.6* �6   �� 5      $
��0.6* �6   �� 5      $
��0.6* �6   �� 5      $��1* �6   .+�5   
   �� $��	Todo List��6   $��36(�6$   $
��Bold"�62   $��Center=�6D   $��49,10,324.6,10.4q�6a   $��Center=�6{   $��54��6�   $	��176��6�   $��Arial)�6�   $��2��6�   
��� ���6�   �� 5   
   $��Task:��6   $��28(�6    $��Center=�6.   $��Center=�6K   $��1��6f   $��Segoe UI Semibold)�6s   $��40,15.6,35,10q�6�   $��2��6�   $	��169��6�   
�������
�������6�   �� 5   
   -   5        $��tbTask��5      $��2��6    $��1��60   $��18(�6=   $��10,15.6,23.6,10.8q�6K   �� 5   
   $��	Due Date:��6   $��28(�6$   $��Center=�62   $��Center=�6O   $��2��6j   $��Segoe UI Semibold)�6w   $��40,15.6,35,10q�6�   $��2��6�   $	��169��6�   
�������
�������6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��	dpDueDate��5      $��2��6&   $��2��63   $��20(�6C   $��10,26.2,324.6,16.4q�6Q   �� 5   
   $��Status:��6   $��28(�6"   $��Center=�60   $��Center=�6M   $��3��6h   $��Segoe UI Semibold)�6u   $��40,16,35,10.4q�6�   $��2��6�   $	��169��6�   
�������
�������6�   �� 5   
   -   5        $��comboStatus��5      $��2��6&   $��3��66   $��10,9.6,324.6,16.8q�6C   �� 5   
   -   5        $��	btAddEdit��5      $��Add / Update��6:   $��2��6Q   $
��Left=�6a   $��20(�6|   $��317,39.2,0,0q�6�   $��4��6�   $	��Top=�6�   $	��176��6�   $��43��6�   �� 5   
   -   5        $��btCancel_Click��5      $��Cancel��6'    �� IsCancel . $��4��6H   $��2��6U   $��49,39.2,309.6,41q�6e   $��20(�6   $	��176��6�   $��43��6�   5      5       