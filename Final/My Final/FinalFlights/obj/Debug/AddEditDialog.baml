   M S B A M L   `   `   `  ����N  JDay09TodoWithDialog, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Day09TodoWithDialogDay09TodoWithDialog  5   	   '    !Day09TodoWithDialog.AddEditDialog   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Day09TodoWithDialog     5   	     � Title$  AddEditDialog��5   	   $	��300��6   $	��400��6,    � WindowStartupLocation$ CenterOwner=�68    � 
ResizeMode$ NoResize=�6\    � 	Resources 5	       �� 
TargetType �� Property �� Value��%R  '��       '�� �     �� 5
   
   " ��6   .�5      ��  � ��$ 14(�6)   �� 5       � ��$ Times New Roman)�6+   �� 5       � ��$
 Bold"�6+   5      �� 5   
   " ��6   .�5      ��  � ��$ 16(�6)   �� 5       � ��$ Times New Roman)�6+   �� 5       � ��$
 Bold"�6+   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��2* �6   6,   �� 5      $��5* �6   6,    � RowDefinitions 5   
   �� 5      $��1* �6   6*   �� 5      $��1* �6   6*   �� 5      $��1* �6   6*   �� 5      $��1* �6   6*   �� 5       $��1* �6   6*   .+�5#   
   �� $
��Task��6   $
��Left=�6   $��20,0,0,0q�6:   $��Center=�6L   �� 5$   
   $��
Difficulty��6   $
��Left=�6%   $��20,0,0,0q�6@   $��1��6R   $��Center=�6_   �� 5%   
   $��Due Date��6   $
��Left=�6#   $��20,0,0,0q�6>   $��2��6P   $��Center=�6]   �� 5&   
   $��Status��6   $
��Left=�6!   $��20,0,0,0q�6<   $��3��6N   $��Center=�6[   �� 5(   
   -   5        $��tbTask��5(      $��1��6    $��Right=�60   $��23��6L   $�� ��6Y   $��Center=�6a   $	��200��6|   	 �� 	MaxLength$		 100��6�   $��0,0,20,0q�6�   ]� 5)   
   $��Center=�6   $��1��60   $��1��6=   $��Right=�6M   $	��200��6i   $��0,0,20,0q�6u   .+�5*      �� $
��Left=�6�   
 �� TextAlignment$
 Center=�6�   $��20��6�   ��6   ��  �� StringFormat$	 {0}�� �� ElementName$ slDifficulty�� �� Path$ Value� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5+      -   5        $��slDifficulty��5+       � Maximum$ 5Q�6)    � Minimum$ 1Q�65    � Value$ 1Q�6B    �� TickPlacement$ BottomRight=�6L    �� TickFrequency$ 1Q�6h    �� IsSnapToTickEnabled . $	��170��6�   $��Right=�6�   5,      (  "System.Windows.Controls.DatePicker  5-   
   -   5        $��	dpDueDate��5-      $��1��6&   $��Right=�66   $��2��6S   $��Center=�6`   $	��200��6{   $��0,0,20,0q�6�   �� 5.   
   -   5        $��comboStatus��5.      $��1��6&   $��Right=�66   $��3��6S   $��Center=�6`   $	��200��6{   $��0,0,20,0q�6�   5/      �� 50   
    �� IsCancel . $��Cancel��6!   $��1��62   $��Right=�6B   $��0,0,20,0q�6`   $��4��6r   $��Center=�6   $	��100��6�   �� 51   
   -   5        $��btAction��51   (   $��Action��68   $��1��6I   $��Right=�6Y   $��	0,0,130,0q�6v   $��4��6�   $��Center=�6�   $	��100��6�   53      54      